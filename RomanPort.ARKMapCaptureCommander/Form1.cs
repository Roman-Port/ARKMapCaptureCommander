using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RomanPort.ARKMapCaptureCommander.Dialogs;
using RomanPort.ARKMapCaptureCommander.Framework.Communication.Entities;
using RomanPort.ARKMapCaptureCommander.Framework.Communication.QueryAllCmdReturn;
using RomanPort.ARKMapCaptureCommander.Framework.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RomanPort.ARKMapCaptureCommander
{
    public partial class ConfigForm : Form
    {
        public QueriedActorData[] actors;
        public List<QueriedActorData> searchedActors;
        public List<ARKCoverActor> covers;
        public bool[] captureAllowFlags; //Flags to check before allowing a user to continue

        public ConfigForm()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            ResetValuesToProfileDefault();
            captureAllowFlags = new bool[2];
            covers = new List<ARKCoverActor>();

            //Try to autodiscover process
            Program.process = null;
            var procs = Process.GetProcessesByName("ShooterGame");
            if (procs.Length == 1)
            {
                Program.process = procs[0];
                processStatus.Text = Program.process.ProcessName;
                processIdPicker.Value = Program.process.Id;
                SetEnableFlag(0);
            }

            //Try to autodiscover output
            if (Directory.Exists(Program.profile.output))
            {
                chooseOutputDirStatus.Text = Program.profile.output;
                SetEnableFlag(1);
            }

            //Send initial commands
            Program.comms.CmdMoveCamera(Program.profile.offsetX, Program.profile.offsetY, Program.profile.cameraHeight, Program.profile.rotation);
            Program.comms.CmdSetCameraProps(Program.profile.mapSize);
            Program.comms.CmdRemoveUnessessaryActors();
            Program.comms.CmdQueryAllActors((string data) =>
            {
                //Get actors
                actors = JsonConvert.DeserializeObject<QueryAllCmdResponse>(data).actors;

                Invoke((MethodInvoker)delegate
                {
                    //Refresh view
                    SearchActorList("");
                });
            });
        }

        public void SearchActorList(string query)
        {
            System.Windows.Forms.ListBox.ObjectCollection objs = new System.Windows.Forms.ListBox.ObjectCollection(actorList);
            searchedActors = new List<QueriedActorData>();
            foreach(var a in actors)
            {
                if(a.name.ToLower().Contains(query) || a.type.ToLower().Contains(query))
                {
                    objs.Add($"{a.type} - {a.name} ({a.index})");
                    searchedActors.Add(a);
                }
            }
            actorList.BeginUpdate();
            actorList.Items.Clear();
            actorList.Items.AddRange(objs);
            actorList.EndUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CaptureForm f = new CaptureForm();
            f.Show();
            Hide();
        }

        /// <summary>
        /// Resets UI values to their profile defaults
        /// </summary>
        public void ResetValuesToProfileDefault()
        {
            optionZoomLevels.Value = Program.profile.zoomLevels;
            optionCameraHeight.Value = Program.profile.cameraHeight;
            optionMapSize.Value = Program.profile.mapSize;
            optionOffsetX.Value = Program.profile.offsetX;
            optionOffsetY.Value = Program.profile.offsetY;
        }

        private void optionMapSize_ValueChanged(object sender, EventArgs e)
        {
            Program.profile.mapSize = (int)optionMapSize.Value;
            Program.comms.CmdSetCameraProps(Program.profile.mapSize);
        }

        private void optionCameraHeight_ValueChanged(object sender, EventArgs e)
        {
            Program.profile.cameraHeight = (int)optionCameraHeight.Value;
            Program.comms.CmdMoveCamera(Program.profile.offsetX, Program.profile.offsetY, Program.profile.cameraHeight, Program.profile.rotation);
        }

        private void optionOffsetX_ValueChanged(object sender, EventArgs e)
        {
            Program.profile.offsetX = (int)optionOffsetX.Value;
            Program.comms.CmdMoveCamera(Program.profile.offsetX, Program.profile.offsetY, Program.profile.cameraHeight, Program.profile.rotation);
        }

        private void optionOffsetY_ValueChanged(object sender, EventArgs e)
        {
            Program.profile.offsetY = (int)optionOffsetY.Value;
            Program.comms.CmdMoveCamera(Program.profile.offsetX, Program.profile.offsetY, Program.profile.cameraHeight, Program.profile.rotation);
        }

        private void processIdDiscoverButton_Click(object sender, EventArgs e)
        {
            try
            {
                Program.process = Process.GetProcessById((int)processIdPicker.Value);
            } catch
            {
                Program.process = null;
            }
            if(Program.process != null)
            {
                processStatus.Text = Program.process.ProcessName;
                SetEnableFlag(0);
            } else
            {
                processStatus.Text = "Process Not Found";
            }
        }

        private void actorListSearch_TextChanged(object sender, EventArgs e)
        {
            string query = actorListSearch.Text;
            if(query.Length == 0 || query.Length > 3)
                SearchActorList(query);
        }

        private void actorList_SelectedValueChanged(object sender, EventArgs e)
        {
            var d = searchedActors[actorList.SelectedIndex];
            actorName.Text = d.name;
            actorType.Text = d.type;
            actorApplyToAllType.Enabled = true;
            actorVisSetting.Enabled = true;
            actorVisSetting.Checked = !d.hidden;
            actorSaveType.Enabled = true;
            actorSaveName.Enabled = true;
            if(d.data_light == null)
            {
                actorLightInten.Enabled = false;
            } else
            {
                actorLightInten.Enabled = true;
                actorLightInten.Value = (decimal)d.data_light.intensity;
            }
            if(d.data_postprocess == null)
            {
                actorEditPostProcessProps.Enabled = false;
            } else
            {
                actorEditPostProcessProps.Enabled = true;
            }
        }

        public void UpdateElementServerside(QueriedActorData data)
        {
            Program.comms.CmdUpdateActorProps(data, data.index);
        }

        private void actorLightInten_ValueChanged(object sender, EventArgs e)
        {
            var d = searchedActors[actorList.SelectedIndex];
            d.data_light.intensity = (float)actorLightInten.Value;
            UpdateElementServerside(d);
        }

        private void actorApplyToAllType_Click(object sender, EventArgs e)
        {
            //Find all elements of this type and apply these props to them
            var d = searchedActors[actorList.SelectedIndex];
            foreach(var a in actors)
            {
                if(d.type == a.type)
                {
                    Program.comms.CmdUpdateActorProps(a, d.index);
                }
            }
        }

        private void actorVisSetting_CheckedChanged(object sender, EventArgs e)
        {
            var d = searchedActors[actorList.SelectedIndex];
            d.hidden = !actorVisSetting.Checked;
            UpdateElementServerside(d);
        }

        private void actorEditPostProcessProps_Click(object sender, EventArgs e)
        {
            var d = searchedActors[actorList.SelectedIndex];
            d.data_postprocess.Remove("postProcessAmbientSound");
            d.data_postprocess.Remove("blendables");
            d.data_postprocess.Remove("antiAliasingMethod");
            d.data_postprocess.Remove("depthOfFieldBokehShape");
            d.data_postprocess.Remove("depthOfFieldMethod");
            d.data_postprocess.Remove("colorGradingLUT");
            d.data_postprocess.Remove("lensFlareBokehShape");
            d.data_postprocess.Remove("ambientCubemap");
            d.data_postprocess.Remove("bloomDirtMask");
            RawJsonEditorForm<JObject>.PromptRawEditor(d.data_postprocess, (JObject data) =>
            {
                d.data_postprocess = data;
                UpdateElementServerside(d);
            });
        }

        private void optionZoomLevels_ValueChanged(object sender, EventArgs e)
        {
            Program.profile.zoomLevels = (int)optionZoomLevels.Value;
        }

        private void actorSaveName_Click(object sender, EventArgs e)
        {
            var d = searchedActors[actorList.SelectedIndex];
            SaveActorParams(d, d.name, 0);
        }

        private void actorSaveType_Click(object sender, EventArgs e)
        {
            var d = searchedActors[actorList.SelectedIndex];
            SaveActorParams(d, d.type, 1);
        }

        public void SaveActorParams(QueriedActorData data, string query, int queryType)
        {
            Program.profile.actors.Add(new Framework.CaptureProfileActorParams
            {
                query = query,
                queryType = queryType,
                hidden = data.hidden,
                data_light = data.data_light,
                data_postprocess = data.data_postprocess
            });
        }

        /// <summary>
        /// Sets a flag that allows a user to capture. When all flags are set, the capture but will become enabled
        /// </summary>
        /// <param name="index"></param>
        public void SetEnableFlag(int index)
        {
            captureAllowFlags[index] = true;
            for(int i = 0; i<captureAllowFlags.Length; i++)
            {
                if (!captureAllowFlags[i])
                    return;
            }
            captureBtn.Enabled = true;
        }

        private void btnChooseOutputDir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog d = new FolderBrowserDialog();
            DialogResult ar = d.ShowDialog();
            if(ar == DialogResult.OK)
            {
                Program.profile.output = d.SelectedPath;
                chooseOutputDirStatus.Text = Program.profile.output;
                SetEnableFlag(1);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Save the profile
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "ARK Capture Profile (.capprofile)|*.capprofile";
            var ar = save.ShowDialog();
            if(ar == DialogResult.OK)
            {
                File.WriteAllText(save.FileName, JsonConvert.SerializeObject(Program.profile, Formatting.Indented));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Load the profile
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "ARK Capture Profile (.capprofile)|*.capprofile";
            var ar = dialog.ShowDialog();
            if(ar == DialogResult.OK)
            {
                Program.profile = JsonConvert.DeserializeObject<Framework.CaptureProfile>(File.ReadAllText(dialog.FileName));
            }

            //Reinit
            Init();
        }

        private CoverTransform GetCoverTransformSettings()
        {
            var c = new CoverTransform();
            SetCoverTransformSettings(c);
            return c;
        }

        private void SetCoverTransformSettings(CoverTransform t)
        {
            t.destroy = false;
            t.pos_x = (float)coverTransformPosX.Value;
            t.pos_y = (float)coverTransformPosY.Value;
            t.pos_z = (float)coverTransformPosZ.Value;
            t.scale_x = (float)coverTransformScaleX.Value/10f;
            t.scale_y = (float)coverTransformScaleY.Value/10f;
            t.scale_z = 1;
            t.rotation = (float)coverTransformRotation.Value;
        }

        private void RefreshCoverList()
        {
            coverList.SuspendLayout();
            coverList.Items.Clear();
            foreach(var c in covers)
            {
                coverList.Items.Add(c.title);
            }
            coverList.ResumeLayout();
        }

        private void coverNewBtn_Click(object sender, EventArgs e)
        {
            //Prompt for name
            if (!CoverCreateDialog.PromptCreateName(out string title))
                return;
            
            //Create cover
            ARKCoverActor ca = new ARKCoverActor(Program.comms, title, GetCoverTransformSettings());
            covers.Add(ca);

            //Refresh
            RefreshCoverList();
            coverList.SelectedIndex = coverList.Items.Count - 1;
        }

        private void coverList_SelectedIndexChanged(object sender, EventArgs e)
        {
            coverDeleteBtn.Enabled = coverList.SelectedIndex != -1;
        }

        private void coverAttributeModified(object sender, EventArgs e)
        {
            if (coverList.SelectedIndex != -1)
            {
                var cover = covers[coverList.SelectedIndex];
                SetCoverTransformSettings(cover.transform);
                cover.UpdateTransform();
            }
        }

        private void coverDeleteBtn_Click(object sender, EventArgs e)
        {
            var cover = covers[coverList.SelectedIndex];
            cover.transform.destroy = true;
            cover.UpdateTransform();
            covers.Remove(cover);
            RefreshCoverList();
            coverList.SelectedIndex = coverList.Items.Count - 1;
        }
    }
}
