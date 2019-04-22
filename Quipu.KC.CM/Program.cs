using Kofax.Capture.DBLite;
using Kofax.Capture.SDK.CustomModule;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quipu.KC.CM
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, eventArgs) => KcAssemblyResolver.Resolve(eventArgs);
            Run(args);
            return;
        }


        static void Run(string[] args)
        {
            // start processing here
            // todo encapsulate this to a separate class!

            // login to KC
            var login = new Login();
            login.EnableSecurityBoost = true;
            login.Login();
            login.ApplicationName = "Quipu.KC.CM";
            login.Version = "1.0";
            login.ValidateUser("Quipu.KC.CM.exe", false, "", "");

            var session = login.RuntimeSession;

            // todo add timer-based polling here (note: mutex!)
            var activeBatch = session.NextBatchGet(login.ProcessID);

            Console.WriteLine(activeBatch.Name);

            activeBatch.BatchClose(
                KfxDbState.KfxDbBatchReady,
                KfxDbQueue.KfxDbQueueNext,
                0,
                "");

            session.Dispose();
            login.Logout();

        }
    }
}
