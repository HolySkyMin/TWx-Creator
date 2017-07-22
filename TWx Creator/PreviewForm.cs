using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TWx_Creator
{
    public partial class PreviewForm : Form
    {
        private List<Note> NoteList = new List<Note>();
        private Dictionary<int, PictureBox> PicturesDic = new Dictionary<int, PictureBox>();
        private int basePos = 0;

        public PreviewForm(List<Note> noteList)
        {
            NoteList = noteList;

            this.MaximumSize = new Size(500, Screen.PrimaryScreen.WorkingArea.Height);
            InitializeComponent();
        }

        private void PreviewForm_Load(object sender, EventArgs e)
        {
            DrawNotes(0);
        }

        private void DrawNotes(int startPosY)
        {
            int anchor = ((int)Math.Round(NoteList[NoteList.Count - 1].Time * 400) + 47) + startPosY;
            for (int i = 0; i < NoteList.Count; i++)
            {
                if (NoteList[i].Mode <= 4)
                {
                    PictureBox noteDisplayer = new PictureBox();
                    if (NoteList[i].Flick.Equals(0))
                    {
                        if (NoteList[i].Mode.Equals(3)) { noteDisplayer.Image = Properties.Resources.damage; }
                        else if (NoteList[i].Mode.Equals(4)) { noteDisplayer.Image = Properties.Resources.trueslide_checkpoint; }
                        else
                        {
                            if (NoteList[i].Size.Equals(2)) { noteDisplayer.Image = Properties.Resources.XLNoteMonotonBlack; }
                            else { noteDisplayer.Image = Properties.Resources.testnote; }
                        }
                    }
                    else if (NoteList[i].Flick.Equals(1)) { noteDisplayer.Image = Properties.Resources.slide_note_left; }
                    else if (NoteList[i].Flick.Equals(2)) { noteDisplayer.Image = Properties.Resources.slide_note_right; }
                    else if (NoteList[i].Flick.Equals(3)) { noteDisplayer.Image = Properties.Resources.slide_note_up; }
                    else if (NoteList[i].Flick.Equals(4)) { noteDisplayer.Image = Properties.Resources.slide_note_down; }
                    noteDisplayer.SizeMode = PictureBoxSizeMode.StretchImage;
                    if (NoteList[i].Size.Equals(0)) { noteDisplayer.Size = new Size(40, 40); }
                    else if (NoteList[i].Size.Equals(1)) { noteDisplayer.Size = new Size(55, 55); }
                    else if (NoteList[i].Size.Equals(2)) { noteDisplayer.Size = new Size(80, 80); }
                    noteDisplayer.Parent = NotePanel;
                    noteDisplayer.BackColor = Color.Transparent;
                    noteDisplayer.Location = new Point(37 + 70 * (int)Math.Round(NoteList[i].EndLine - 1) - (noteDisplayer.Size.Width / 2), anchor - (int)Math.Round(NoteList[i].Time * 400) - (noteDisplayer.Size.Height / 2));
                    if(noteDisplayer.Location.Y >= 0 && noteDisplayer.Location.Y < 32767)
                    {
                        PicturesDic.Add(NoteList[i].ID, noteDisplayer);
                        PicturesDic[NoteList[i].ID].Show();
                    }
                }
            }

            NotePanel.Paint += new PaintEventHandler(NotePanel_Paint);
        }

        private void NotePanel_Paint(object sender, PaintEventArgs e)
        {
            int leftPos = 0, rightPos = 0, curY = 0;
            double befTime = 0;

            for (int i = 0; i < NoteList.Count; i++)
            {
                if (PicturesDic.ContainsKey(NoteList[i].ID))
                {
                    if(befTime != NoteList[i].Time)
                    {
                        if (rightPos > 0 && i > 0)
                        {
                            using (Pen pen = new Pen(Color.White, 5))
                            {
                                e.Graphics.DrawLine(pen, new Point(leftPos, curY), new Point(rightPos, curY));
                            }
                        }
                        befTime = NoteList[i].Time;
                        leftPos = PicturesDic[NoteList[i].ID].Location.X + (PicturesDic[NoteList[i].ID].Size.Width / 2);
                        rightPos = 0;
                        curY = PicturesDic[NoteList[i].ID].Location.Y + (PicturesDic[NoteList[i].ID].Size.Height / 2);
                    }
                    else { rightPos = PicturesDic[NoteList[i].ID].Location.X + (PicturesDic[NoteList[i].ID].Size.Width / 2); }
                    if(NoteList[i].PrevIDs.Length > 0)
                    {
                        for (int j = 0; j < NoteList[i].PrevIDs.Length; j++)
                        {
                            if (NoteList[i].PrevIDs[j] > 0 && PicturesDic.ContainsKey(NoteList[i].PrevIDs[j]))
                            {
                                using (Pen pen = new Pen(Color.Yellow, 35))
                                {
                                    e.Graphics.DrawLine(pen, new Point(PicturesDic[NoteList[i].ID].Location.X + (PicturesDic[NoteList[i].ID].Size.Width / 2), PicturesDic[NoteList[i].ID].Location.Y + (PicturesDic[NoteList[i].ID].Size.Height / 2)), new Point(PicturesDic[NoteList[i].PrevIDs[j]].Location.X + (PicturesDic[NoteList[i].PrevIDs[j]].Size.Width / 2), PicturesDic[NoteList[i].PrevIDs[j]].Location.Y + (PicturesDic[NoteList[i].PrevIDs[j]].Size.Height / 2)));
                                }
                            }
                        }
                    }
                }
            }
        }

        private void RedrawBtn_Click(object sender, EventArgs e)
        {
            basePos += NotePanel.AutoScrollPosition.Y;
            NotePanel.Controls.Clear();
            PicturesDic.Clear();
            DrawNotes(basePos);
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            basePos = 0;
            NotePanel.Controls.Clear();
            PicturesDic.Clear();
            DrawNotes(basePos);
        }

        private void bottomBtn_Click(object sender, EventArgs e)
        {
            NotePanel.VerticalScroll.Value = NotePanel.VerticalScroll.Maximum;
        }
    }
}
