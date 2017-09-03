using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LitJson;

namespace TWx_Creator
{
    public partial class MainField : Form
    {
        public MainField()
        {
            InitializeComponent();
        }

        private bool TextModified = false;

        private void OpenFileBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = OpenDialog.ShowDialog();
            if(result.Equals(DialogResult.OK))
            {
                Stream stream = OpenDialog.OpenFile();
                StreamReader reader = new StreamReader(stream, Encoding.Unicode);
                InputField.Text = reader.ReadToEnd();
                reader.Close();
                stream.Close();
                UpdateLog("Successfully loaded project.");
                TextModified = false;
            }
        }

        private void InputField_TextChanged(object sender, EventArgs e)
        {
            TextModified = true;
        }

        private void CreateNewBtn_Click(object sender, EventArgs e)
        {
            if (!TextModified)
            {
                InputField.Clear();
                LogList.Items.Clear();
            }
            else
            {
                DialogResult result = MessageBox.Show("Project has been changed. Changes will be lost unless you save it." + Environment.NewLine + "Do you want to create new project?", "Warning", MessageBoxButtons.YesNo);
                if(result.Equals(DialogResult.Yes))
                {
                    InputField.Clear();
                    LogList.Items.Clear();
                    TextModified = false;
                }
            }
        }

        private void SaveFileBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = SaveDialog.ShowDialog();
            if(result.Equals(DialogResult.OK))
            {
                Stream stream = SaveDialog.OpenFile();
                StreamWriter writer = new StreamWriter(stream, Encoding.Unicode);
                writer.Write(InputField.Text);
                writer.Close();
                stream.Close();
                MessageBox.Show("Saved.");
                UpdateLog("Project has been saved as: " + SaveDialog.FileName);
                TextModified = false;
            }
        }

        private void ProgramInfoBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TWx Creator 0.1.3 with TWx 1.0b and TWxScript 0.1" + Environment.NewLine + Environment.NewLine + "Check the update and new information via Twitter '@Tempest_Wave'.", "Program Info");
        }

        private void CompileBtn_Click(object sender, EventArgs e)
        {
            int mod = 6;
            if (TW2.Checked)
            {
                mod = 2;
                ExportDialog.DefaultExt = "tw2";
                ExportDialog.Filter = "2Lane TWx Beatmap Format (*.tw2)|*.tw2";
            }
            else if (TW4.Checked)
            {
                mod = 4;
                ExportDialog.DefaultExt = "tw4";
                ExportDialog.Filter = "4Lane TWx Beatmap Format (*.tw4)|*.tw4";
            }
            else if (TW5.Checked)
            {
                mod = 5;
                ExportDialog.DefaultExt = "tw5";
                ExportDialog.Filter = "5Lane TWx Beatmap Format (*.tw5)|*.tw5";
            }
            else if (TW6.Checked)
            {
                mod = 6;
                ExportDialog.DefaultExt = "tw6";
                ExportDialog.Filter = "6Lane TWx Beatmap Format (*.tw6)|*.tw6";
            }
            else
            {
                UpdateLog("Error: Please select the export format.");
                return;
            }

            ExportDialog.FileName = "New Beatmap";
            DialogResult res = ExportDialog.ShowDialog();
            if(res.Equals(DialogResult.OK))
            {
                UpdateLog("Start generating...");
                string twxString;
                NoteData noteData = new NoteData();
                if (TWxScript.Checked)
                {
                    try
                    {
                        noteData.notes = ParseAsTWxScript(mod).ToArray();
                        twxString = JsonMapper.ToJson(noteData);

                        Stream stream = ExportDialog.OpenFile();
                        StreamWriter writer = new StreamWriter(stream, Encoding.Unicode);
                        writer.Write(twxString);
                        writer.Close();
                        stream.Close();
                        UpdateLog("Successfully generated. File has been saved as: " + ExportDialog.FileName);
                    }
                    catch(Exception ex)
                    {
                        UpdateLog("Error: " + ex.Message);
                        return;
                    }
                }
                else { UpdateLog("Error: Please select the script parsing method."); }
            }
        }

        private void MainField_Load(object sender, EventArgs e)
        {
            LogList.Items.Add("Welcome to TWx Creator!");
        }

        private List<Note> ParseAsTWxScript(int mode)
        {
            List<Note> NoteList = new List<Note>();
            char[] divSpace = new char[] { ' ' }, divEqual = new char[] { '=' }, divComma = new char[] { ',' };

            StaticBlockData Field = new StaticBlockData();
            BlockData block = null;
            int curCount = 1, i = 0, bp4 = 4, curMeasure = 0;
            byte[] color = new byte[4] { 255, 255, 255, 255 };
            double BPM = 0, speed = 1.0f, curTime = 0;

            for (i = 0; i < InputField.Lines.Length; i++)
            {
                string[] MainData = InputField.Lines[i].Split(divSpace, StringSplitOptions.RemoveEmptyEntries);
                if (MainData.Length > 0)
                {
                    if (MainData[0].Equals("#"))
                    {

                        if (block != null && block.IsAdded)
                        {
                            Note[] noteBlock = block.ParseBlockData(ref curCount, ref curTime, mode, ref Field);
                            for (int j = 0; j < noteBlock.Length; j++)
                            {
                                NoteList.Add(noteBlock[j]);
                            }
                        }
                        else if(block != null) { curTime += (60 * bp4) / BPM; }
                        curMeasure++;
                        block = new BlockData();
                        block.BeatPer4 = bp4;
                        block.BPM = BPM;
                        block.Measure = curMeasure;
                    }
                    else if (MainData[0].ToUpper().Equals("BPM"))
                    {
                        if (block != null && block.IsAdded) { throw new Exception("Line" + (i + 1).ToString() + " - Cannot change BPM after adding data to block."); }
                        double bpm;
                        if (double.TryParse(MainData[1], out bpm).Equals(false)) { throw new Exception("Line" + (i + 1).ToString() + " - Cannot read BPM value."); }
                        BPM = bpm;
                        if (block != null) { block.BPM = BPM; }
                    }
                    else if (MainData[0].ToUpper().Equals("COLOR"))
                    {
                        byte[] co = new byte[4];
                        string[] ColorData = MainData[1].Split(divComma);
                        if (ColorData.Length < 3) { throw new Exception("Line" + (i + 1).ToString() + " - Not enough information for color key."); }
                        else if (ColorData.Length.Equals(3)) { co[3] = 255; }
                        for(int j = 0; j < ColorData.Length; j++)
                        {
                            if (j >= 4) { break; }
                            if (byte.TryParse(ColorData[j], out co[j]).Equals(false)) { throw new Exception("Line" + (i + 1).ToString() + " - Cannot read color key value."); }
                            color[j] = co[j];
                        }
                    }
                    else if (MainData[0].ToUpper().Equals("SPEED"))
                    {
                        double sp;
                        if (double.TryParse(MainData[1], out sp).Equals(false)) { throw new Exception("Line" + (i + 1).ToString() + " - Cannot read speed value."); }
                        speed = sp;
                    }
                    else if(MainData[0].ToUpper().Equals("BEATS"))
                    {
                        if(block != null && block.IsAdded) { throw new Exception("Line" + (i + 1).ToString() + "- Cannot change beats after adding data to block."); }
                        int tbp;
                        if (int.TryParse(MainData[1], out tbp).Equals(false)) { throw new Exception("Line" + (i + 1).ToString() + " - Cannot read beats value."); }
                        bp4 = tbp;
                        if (block != null) { block.BeatPer4 = bp4; }
                    }
                    else if(MainData[0].ToUpper().Equals("STARTTIME"))
                    {
                        if (block != null) { throw new Exception("Line " + (i + 1).ToString() + " - Cannot set start time after defining blocks."); }
                        if (double.TryParse(MainData[1], out double tst).Equals(false)) { throw new Exception("Line " + (i + 1).ToString() + " - Cannot read start time value."); }
                        curTime = tst / 1000f;
                    }
                    else
                    {
                        if(BPM <= 0) { throw new Exception("Line" + (i + 1).ToString() + " - Data defined without defining BPM."); }
                        string[] SubData = MainData[0].Split(divEqual);
                        if(SubData.Length < 2) { throw new Exception("Line" + (i + 1).ToString() + " - No data. "); }
                        int channel;
                        if(int.TryParse(SubData[0], out channel).Equals(false)) { throw new Exception("Line" + (i + 1).ToString() + " - Cannot read channel value."); }
                        if(block == null) { throw new Exception("Line" + (i + 1).ToString() + " - Data defined without defining block."); }
                        block.DataLines.Add(SubData[1]);
                        block.Channel.Add(channel);
                        block.Color.Add(color);
                        block.Speed.Add(speed);
                        if (!block.IsAdded) { block.IsAdded = true; }
                    }
                }
            }
            if (block != null && block.IsAdded)
            {
                Note[] noteBlock = block.ParseBlockData(ref curCount, ref curTime, mode, ref Field);
                for (int j = 0; j < noteBlock.Length; j++)
                {
                    NoteList.Add(noteBlock[j]);
                }
            }
            else { curTime += (60 * (bp4 / 4d)) / BPM; }

            return NoteList;
        }

        private void UpdateLog(string text)
        {
            LogList.Items.Add(text);
            LogList.TopIndex = LogList.Items.Count - 1;
        }

        private void MainField_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(TextModified)
            {
                DialogResult res = MessageBox.Show("Project has been changed. Changes will be lost unless you save it." + Environment.NewLine + "Do you want to close TWx Creator?", "Warining", MessageBoxButtons.YesNo);
                if (res.Equals(DialogResult.No)) { e.Cancel = true; }
            }
        }

        private void PreviewBtn_Click(object sender, EventArgs e)
        {
            int mod = 6;
            if (TW2.Checked)
            {
                mod = 2;
                ExportDialog.DefaultExt = "tw2";
                ExportDialog.Filter = "2Lane TWx Beatmap Format (*.tw2)|*.tw2";
            }
            else if (TW4.Checked)
            {
                mod = 4;
                ExportDialog.DefaultExt = "tw4";
                ExportDialog.Filter = "4Lane TWx Beatmap Format (*.tw4)|*.tw4";
            }
            else if (TW5.Checked)
            {
                mod = 5;
                ExportDialog.DefaultExt = "tw5";
                ExportDialog.Filter = "5Lane TWx Beatmap Format (*.tw5)|*.tw5";
            }
            else if (TW6.Checked)
            {
                mod = 6;
                ExportDialog.DefaultExt = "tw6";
                ExportDialog.Filter = "6Lane TWx Beatmap Format (*.tw6)|*.tw6";
            }
            else
            {
                UpdateLog("Error: Please select the export format.");
                return;
            }

            UpdateLog("Start generating preview...");
            if (TWxScript.Checked)
            {
                try
                {
                    List<Note> NoteList = ParseAsTWxScript(mod);

                    PreviewForm prevForm = new PreviewForm(NoteList);
                    prevForm.Show();
                    UpdateLog("Successfully generated preview.");
                }
                catch (Exception ex)
                {
                    UpdateLog("Error: " + ex.Message);
                }
            }
        }
    }
}
