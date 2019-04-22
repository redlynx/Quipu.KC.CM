using Kofax.Capture.AdminModule.InteropServices;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;

namespace Quipu.KC.CM
{
    public partial class SetupForm : Form
    {
        public IBatchClass BatchClass;
        public SetupForm()
        {
            InitializeComponent();
        }

        public DialogResult ShowDialog(IBatchClass batchClass)
        {
            BatchClass = batchClass;
            // load previous settings
            return this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // check and save settings
                this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
