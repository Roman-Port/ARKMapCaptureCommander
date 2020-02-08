using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.ARKMapCaptureCommander
{
    public delegate void OnRawJsonEditorUpdated<T>(T data);
    
    public partial class RawJsonEditorForm<T> : Form
    {
        public OnRawJsonEditorUpdated<T> callback;

        public RawJsonEditorForm(T data, OnRawJsonEditorUpdated<T> callback)
        {
            InitializeComponent();
            this.callback = callback;
            this.editorBox.Text = JsonConvert.SerializeObject(data, Formatting.Indented);
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            T data;
            try
            {
                data = JsonConvert.DeserializeObject<T>(editorBox.Text);
            } catch
            {
                return;
            }
            callback(data);
            Close();
        }

        public static void PromptRawEditor(T data, OnRawJsonEditorUpdated<T> callback)
        {
            var f = new RawJsonEditorForm<T>(data, callback);
            f.Show();
        }
    }
}
