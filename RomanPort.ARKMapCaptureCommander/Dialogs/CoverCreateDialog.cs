using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.ARKMapCaptureCommander.Dialogs
{
    public partial class CoverCreateDialog : Form
    {
        public CoverCreateDialog()
        {
            InitializeComponent();
            DialogResult = DialogResult.Cancel;
        }

        public string submitted_name;

        private void createBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            submitted_name = coverName.Text;
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void coverName_TextChanged(object sender, EventArgs e)
        {
            createBtn.Enabled = coverName.Text.Length > 0;
        }

        public static bool PromptCreateName(out string name)
        {
            CoverCreateDialog d = new CoverCreateDialog();
            var result = d.ShowDialog();
            name = d.submitted_name;
            return result == DialogResult.OK;
        }
    }
}
