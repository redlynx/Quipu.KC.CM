using Kofax.Capture.AdminModule.InteropServices;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Quipu.KC.CM
{
    [InterfaceType(ComInterfaceType.InterfaceIsIDispatch)]
    public interface ISetupForm
    {
        [DispId(1)]
        AdminApplication Application { set; }
        [DispId(2)]
        void ActionEvent(int EventNumber, object Argument, out int Cancel);
    }

    [ClassInterface(ClassInterfaceType.None)]
    [ProgId("Quipu.KC.CM.Setup")]
    public class SetupUserControl : UserControl, ISetupForm
    {
        private AdminApplication adminApplication;

        public AdminApplication Application
        {
            set
            {
                value.AddMenu("Quipu.KC.CM.Setup", "Quipu.KC.CM - Setup", "BatchClass");
                adminApplication = value;
            }
        }

        public void ActionEvent(int EventNumber, object Argument, out int Cancel)
        {
            Cancel = 0;

            if ((KfxOcxEvent)EventNumber == KfxOcxEvent.KfxOcxEventMenuClicked && (string)Argument == "Quipu.KC.CM.Setup")
            {
                SetupForm form = new SetupForm();
                form.ShowDialog(adminApplication.ActiveBatchClass);
            }
        }

    }
}
