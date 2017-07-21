using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWx_Creator
{
    public class StaticBlockData
    {
        public Dictionary<int, List<int[]>> ConnectorPrev = new Dictionary<int, List<int[]>>(6);
        public Dictionary<int, float> BeforeTime = new Dictionary<int, float>();
        public Dictionary<int, int> TailPrev = new Dictionary<int, int>(), BeforeFlickData = new Dictionary<int, int>();
        public Dictionary<double, int> HoldPrev = new Dictionary<double, int>();
    }

    public class BlockData
    {
        public List<string> DataLines { get; set; }
        public List<int> Channel { get; set; }
        public List<byte[]> Color { get; set; }
        public List<double> Speed { get; set; }
        public int Measure { get; set; }
        public int BeatPer4 { get; set; }
        public double BPM { get; set; }
        public bool IsAdded { get; set; }

        public BlockData()
        {
            DataLines = new List<string>();
            Channel = new List<int>();
            Color = new List<byte[]>(4);
            Speed = new List<double>();
            IsAdded = false;
            BeatPer4 = 4;
        }

        public Note[] ParseBlockData(ref int count, ref double time, int twxMode, ref StaticBlockData field)
        {
            List<Note> NoteList = new List<Note>();
            List<int> beforeI = new List<int>(), currentI = new List<int>(), StartEnd = new List<int>();
            char[] divColon = new char[] { ':' }, divComma = new char[] { ',' };
            List<string[]> Data = new List<string[]>(), StartPos = new List<string[]>(), EndPos = new List<string[]>();

            int BeatDivide = 1;
            for(int i = 0; i < DataLines.Count; i++)
            {
                Data.Add(DataLines[i].Split(divColon));
                beforeI.Add(-1);
                currentI.Add(0);
                StartEnd.Add(0);
                BeatDivide = LCM(BeatDivide, Data[i][0].Length);
                StartPos.Add(Data[i].Length >= 2 ? Data[i][1].Split(divComma) : new string[1]);
                EndPos.Add(Data[i].Length >= 3 ? Data[i][2].Split(divComma) : new string[1]);
            }
            for(int i = 0; i < BeatDivide; i++)
            {
                for(int j = 0; j < Data.Count; j++)
                {
                    currentI[j] = (int)Math.Floor(i / ((float)BeatDivide / Data[j][0].Length));
                    if(beforeI[j] < currentI[j])
                    {
                        beforeI[j] = currentI[j];
                        string noteData = Data[j][0].Substring(currentI[j], 1);
                        
                        if(!noteData.Equals("-"))
                        {
                            int mode = 0, size = 0, flick = 0;
                            if (noteData.ToUpper().Equals("N") || noteData.ToUpper().Equals("T"))
                            {
                                mode = 0;
                                if (noteData.Equals("n") || noteData.Equals("t")) { size = 0; }
                                else if (noteData.Equals("N") || noteData.Equals("T")) { size = 1; }
                            }
                            else if (noteData.ToUpper().Equals("H"))
                            {
                                mode = 1;
                                if (noteData.Equals("h")) { size = 0; }
                                else if (noteData.Equals("H")) { size = 1; }
                            }
                            else if (noteData.ToUpper().Equals("S"))
                            {
                                mode = 2;
                                if (noteData.Equals("s")) { size = 0; }
                                else if (noteData.Equals("S")) { size = 1; }
                            }
                            else if (noteData.ToUpper().Equals("M"))
                            {
                                mode = 3;
                                if (noteData.Equals("m")) { size = 0; }
                                else if (noteData.Equals("M")) { size = 1; }
                            }
                            else if (noteData.ToUpper().Equals("I"))
                            {
                                mode = 4;
                                if (noteData.Equals("i")) { size = 0; }
                                else if (noteData.Equals("I")) { size = 1; }
                            }
                            else if(noteData.ToUpper().Equals("L") || noteData.ToUpper().Equals("R") || noteData.ToUpper().Equals("U") || noteData.ToUpper().Equals("D"))
                            {
                                mode = 0;
                                if(noteData.ToUpper().Equals("L"))
                                {
                                    flick = 1;
                                    if (noteData.Equals("l")) { size = 0; }
                                    else if (noteData.Equals("L")) { size = 1; }
                                }
                                else if(noteData.ToUpper().Equals("R"))
                                {
                                    flick = 2;
                                    if (noteData.Equals("r")) { size = 0; }
                                    else if (noteData.Equals("R")) { size = 1; }
                                }
                                else if(noteData.ToUpper().Equals("U"))
                                {
                                    flick = 3;
                                    if (noteData.Equals("u")) { size = 0; }
                                    else if (noteData.Equals("U")) { size = 1; }
                                }
                                else if(noteData.ToUpper().Equals("D"))
                                {
                                    flick = 4;
                                    if (noteData.Equals("d")) { size = 0; }
                                    else if (noteData.Equals("D")) { size = 1; }
                                }
                            }
                            else if(noteData.ToUpper().Equals("P"))
                            {
                                mode = 0;
                                size = 2;
                                flick = 0;
                            }
                            else { throw new Exception("Block " + Measure.ToString() + ", Data line " + (j + 1).ToString() + ", Note data #" + (currentI[j] + 1).ToString() + " (value: '" + noteData + "') - Wrong value."); }

                            if(StartPos[j].Length <= StartEnd[j]) { throw new Exception("Block " + Measure.ToString() + ", Data line " + (j + 1).ToString() + " - Not enough start point data."); }
                            double startPos;
                            if (Data[j].Length < 2) { startPos = 3; }
                            else
                            {
                                if (double.TryParse(StartPos[j][StartEnd[j]], out startPos).Equals(false))
                                {
                                    throw new Exception("Block " + Measure.ToString() + ", Data line " + (j + 1).ToString() + ", Start point data #" + (StartEnd[j] + 1).ToString() + " (value: '" + StartPos[j][StartEnd[j]].ToString() + "') - Wrong value.");
                                }
                            }
                            if(twxMode.Equals(5) && (startPos < 1 || startPos > 5)) { throw new Exception("Block " + Measure.ToString() + ", Data line " + (j + 1).ToString() + ", Start point data #" + (StartEnd[j] + 1).ToString() + " (value: '" + StartPos[j][StartEnd[j]].ToString() + "') - Value is not between minimum line and maximum line."); }

                            if (EndPos[j].Length <= StartEnd[j]) { throw new Exception("Block " + Measure.ToString() + ", Data line " + (j + 1).ToString() + " - Not enough end point data."); }
                            double endPos;
                            if (Data[j].Length < 3) { endPos = 3; }
                            else
                            {
                                if (double.TryParse(EndPos[j][StartEnd[j]], out endPos).Equals(false))
                                {
                                    throw new Exception("Block " + Measure.ToString() + ", Data line " + (j + 1).ToString() + ", Start point data #" + (StartEnd[j] + 1).ToString() + " (value: '" + EndPos[j][StartEnd[j]].ToString() + "') - Wrong value.");
                                }
                            }
                            if(twxMode.Equals(5) && (endPos < 1 || endPos > 5)) { throw new Exception("Block " + Measure.ToString() + ", Data line " + (j + 1).ToString() + ", Start point data #" + (StartEnd[j] + 1).ToString() + " (value: '" + EndPos[j][StartEnd[j]].ToString() + "') - Value is not between minimum line and maximum line."); }

                            List<int> prevs = new List<int>();

                            if (mode.Equals(1))
                            {
                                if (field.HoldPrev.ContainsKey(endPos))
                                {
                                    if (field.HoldPrev[endPos] > 0) { throw new Exception("Block " + Measure.ToString() + ", Data line " + (j + 1).ToString() + ", Note data #" + (currentI[j] + 1).ToString() + " - Hold note start already exists."); }
                                    else { field.HoldPrev[endPos] = count; }
                                }
                                else { field.HoldPrev.Add(endPos, count); }
                            }
                            else if (mode.Equals(2))
                            {
                                if (field.TailPrev.ContainsKey(Channel[j]))
                                {
                                    if (field.TailPrev[Channel[j]] > 0) { prevs.Add(field.TailPrev[Channel[j]]); }
                                    field.TailPrev[Channel[j]] = count;
                                }
                                else { field.TailPrev.Add(Channel[j], count); }
                            }
                            else if (mode.Equals(0) || mode.Equals(3) || mode.Equals(4))
                            {
                                int check = 0;
                                if (mode.Equals(0) && field.HoldPrev.ContainsKey(endPos) && field.HoldPrev[endPos] > 0)
                                {
                                    mode = 1;
                                    check++;
                                    prevs.Add(field.HoldPrev[endPos]);
                                    field.HoldPrev[endPos] = 0;
                                }
                                if(mode.Equals(0) && field.TailPrev.ContainsKey(Channel[j]) && field.TailPrev[Channel[j]] > 0)
                                {
                                    mode = 2;
                                    check++;
                                    prevs.Add(field.TailPrev[Channel[j]]);
                                    field.TailPrev[Channel[j]] = 0;
                                }
                                if(check >= 2) { throw new Exception("Block " + Measure.ToString() + ", Data line " + (j + 1).ToString() + ", Note data #" + (currentI[j] + 1).ToString() + " - Both Hold note and Slide note exist."); }
                                if(twxMode.Equals(5) && flick.Equals(0) && field.BeforeFlickData.ContainsKey(Channel[j]) && field.BeforeFlickData[Channel[j]] > 0)
                                {
                                    field.ConnectorPrev[Channel[j]].Clear();
                                    field.BeforeFlickData[Channel[j]] = 0;
                                }
                            }

                            if(twxMode.Equals(5) && flick > 0)
                            {
                                if(field.ConnectorPrev.ContainsKey(Channel[j]) && field.ConnectorPrev[Channel[j]].Count > 0)
                                {
                                    for(int k = 0; k < field.ConnectorPrev[Channel[j]].Count; k++)
                                    {
                                        if(field.ConnectorPrev[Channel[j]][k][(int)endPos - 1] > 0) { prevs.Add(field.ConnectorPrev[Channel[j]][k][(int)endPos - 1]); }
                                    }
                                }
                                field.BeforeFlickData[Channel[j]] = flick;
                                int[] temp = new int[6];
                                if (Channel[j] % 4 == 0 || Channel[j] % 4 == 1)
                                {
                                    if(flick.Equals(1))
                                    {
                                        for(int k = 0; k < (int)endPos - 1; k++)
                                        {
                                            temp[k] = count;
                                        }
                                    }
                                    else if(flick.Equals(2))
                                    {
                                        for(int k = (int)endPos; k < 6; k++)
                                        {
                                            temp[k] = count;
                                        }
                                    }
                                }
                                else if(Channel[j] % 4 == 2 || Channel[j] % 4 == 3)
                                {
                                    for(int k = 0; k < 6; k++)
                                    {
                                        temp[k] = count;
                                    }
                                }
                                field.ConnectorPrev[Channel[j]].Add(temp);
                            }

                            int pCount = 1;
                            if(prevs.Count > 0) { pCount = prevs.Count; }
                            Note note = new Note(pCount);
                            note.CreateNote(count, size, Color[j], mode, flick, time, Speed[j], startPos, endPos, prevs.Count > 0 ? prevs.ToArray() : new int[] { 0 });
                            NoteList.Add(note);

                            StartEnd[j]++;
                            count++;
                        }
                    }
                }
                time += ((60 * BeatPer4) / BPM) / BeatDivide;
            }

            return NoteList.ToArray();
        }

        private int LCM(int a, int b)
        {
            int p = a, q = b, r;
            while(q != 0)
            {
                r = p % q;
                p = q;
                q = r;
            }
            return (a * b) / p;
        }
    }
}
