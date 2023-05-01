namespace B32Assembler
{
    public partial class frmMainForm : Form
    {
        private string SourceProgram; // holds our program in memory
        private System.Collections.Hashtable LabelTable; // holds our labes
        private int CurrentNdx; // will be an index pointer to the current location in the file
        private ushort AsLength;// will be unsigned 16-bit variable that will keep track of how big our binary program is  
        private bool IsEnd; // simply flag to determine if the end of the program has been reached
        private ushort ExecutionAddress; // will hold the value of our execution adress
        private enum Registers
        {
            Unknown = 0,
            A = 4,
            B = 2,
            D = 1,
            X = 16,
            Y = 8
        }
        public frmMainForm()
        {
            InitializeComponent();
            this.LabelTable = new System.Collections.Hashtable(50);
            this.CurrentNdx = 0;
            this.AsLength = 0;
            this.ExecutionAddress = 0;
            this.IsEnd = false;
            this.SourceProgram = "";
            this.txtOrigin.Text = "1000";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSourceBrowse_Click(object sender, EventArgs e)
        {
            this.fdSourceFile.ShowDialog();
            this.txtSourceFileName.Text = fdSourceFile.FileName;
        }

        private void txtOutputFileName_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmMainForm_Load(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void btnOutputBrowse_Click(object sender, EventArgs e)
        {
            this.fdDestinationFile.ShowDialog();
            this.txtOutputFileName.Text = fdDestinationFile.FileName;
        }

        private void btnAssemble_Click(object sender, EventArgs e)
        {
            AsLength = Convert.ToUInt16(this.txtOrigin.Text, 16);
            System.IO.BinaryWriter output;
            System.IO.TextReader input;
            System.IO.FileStream fs = new
            System.IO.FileStream(this.txtOutputFileName.Text, System.IO.FileMode.Create);
            output = new System.IO.BinaryWriter(fs);
            input = System.IO.File.OpenText(this.txtSourceFileName.Text);
            SourceProgram = input.ReadToEnd();
            input.Close();
            output.Write('B');
            output.Write('3');
            output.Write('2');
            output.Write(Convert.ToUInt16(this.txtOrigin.Text, 16));
            output.Write((ushort)0);
            this.Parse(output);
            output.Seek(5, System.IO.SeekOrigin.Begin);
            output.Write(ExecutionAddress);
            output.Close();
            fs.Close();
            MessageBox.Show("Done!");
        }

        #region Interpret Functions
        private void Parse(System.IO.BinaryWriter OutputFile)
        {
            CurrentNdx = 0;
            while (IsEnd == false)
                LabelScan(OutputFile, true);
            IsEnd = false;
            CurrentNdx = 0;
            AsLength = Convert.ToUInt16(this.txtOrigin.Text, 16);
            while (IsEnd == false)
                LabelScan(OutputFile, false);
        }

        private void LabelScan(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            if (char.IsLetter(SourceProgram[CurrentNdx]))
            {
                // Must be a label
                if (IsLabelScan) LabelTable.Add(GetLabelName(), AsLength);
                while (SourceProgram[CurrentNdx] != '\n')
                    CurrentNdx++;
                CurrentNdx++;
                return;
            }
            EatWhiteSpaces();
            ReadMneumonic(OutputFile, IsLabelScan);
        }
        private void ReadMneumonic(System.IO.BinaryWriter OutputFile, bool
IsLabelScan)
        {
            string Mneumonic = "";
            while (!(char.IsWhiteSpace(SourceProgram[CurrentNdx])))
            {
                Mneumonic = Mneumonic + SourceProgram[CurrentNdx];
                CurrentNdx++;
            }
            if (Mneumonic.ToUpper() == "LDX") InterpretLDX(OutputFile,
            IsLabelScan);
            if (Mneumonic.ToUpper() == "LDA") InterpretLDA(OutputFile,
            IsLabelScan);
            if (Mneumonic.ToUpper() == "STA") InterpretSTA(OutputFile,
            IsLabelScan);
            if (Mneumonic.ToUpper() == "CMPA") InterpretCMPA(OutputFile,
IsLabelScan);
            if (Mneumonic.ToUpper() == "CMPB") InterpretCMPB(OutputFile,
            IsLabelScan);
            if (Mneumonic.ToUpper() == "CMPX") InterpretCMPX(OutputFile,
            IsLabelScan);
            if (Mneumonic.ToUpper() == "CMPY") InterpretCMPY(OutputFile,
            IsLabelScan);
            if (Mneumonic.ToUpper() == "CMPD") InterpretCMPD(OutputFile,
            IsLabelScan);
            if (Mneumonic.ToUpper() == "JMP") InterpretJMP(OutputFile,
            IsLabelScan);
            if (Mneumonic.ToUpper() == "JEQ") InterpretJEQ(OutputFile,
            IsLabelScan);
            if (Mneumonic.ToUpper() == "JNE") InterpretJNE(OutputFile,
            IsLabelScan);
            if (Mneumonic.ToUpper() == "JGT") InterpretJGT(OutputFile,
            IsLabelScan);
            if (Mneumonic.ToUpper() == "JLT") InterpretJLT(OutputFile,
            IsLabelScan);
            if (Mneumonic.ToUpper() == "END")
            {
                IsEnd = true;
                DoEnd(OutputFile, IsLabelScan); EatWhiteSpaces(); ExecutionAddress = (ushort)LabelTable[(GetLabelName())];
                return;
            }
            while (SourceProgram[CurrentNdx] != '\n')
            {
                CurrentNdx++;
            }
            CurrentNdx++;
        }

        private void InterpretLDA(System.IO.BinaryWriter OutputFile, bool
IsLabelScan)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == '#')
            {
                CurrentNdx++;
                byte val = ReadByteValue();
                AsLength += 2;
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x01);
                    OutputFile.Write(val);
                }
            }
        }
        private void InterpretLDX(System.IO.BinaryWriter OutputFile, bool
IsLabelScan)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == '#')
            {
                CurrentNdx++;
                ushort val = ReadWordValue();
                AsLength += 3;
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x02);
                    OutputFile.Write(val);
                }
            }
        }

        private void InterpretSTA(System.IO.BinaryWriter OutputFile, bool
IsLabelScan)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == ',')
            {
                Registers r;
                byte opcode = 0x00;
                CurrentNdx++;
                EatWhiteSpaces();
                r = ReadRegister();
                switch (r)
                {
                    case Registers.X:
                        opcode = 0x03;
                        break;
                }
                AsLength += 1;
                if (!IsLabelScan)
                {
                    OutputFile.Write(opcode);
                }
            }
        }
        private void InterpretCMPA(System.IO.BinaryWriter OutputFile, bool
IsLabelScan)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == '#')
            {
                CurrentNdx++;
                byte val = ReadByteValue();
                AsLength += 2;
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x05);
                    OutputFile.Write(val);
                }
            }
        }
        private void InterpretCMPB(System.IO.BinaryWriter OutputFile, bool
        IsLabelScan)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == '#')
            {
                CurrentNdx++;
                byte val = ReadByteValue();
                AsLength += 2;
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x06);
                    OutputFile.Write(val);
                }
            }
        }
        private void InterpretCMPX(System.IO.BinaryWriter OutputFile, bool
IsLabelScan)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == '#')
            {
                CurrentNdx++;
                ushort val = ReadWordValue();
                AsLength += 3;
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x07);
                    OutputFile.Write(val);
                }
            }
        }



        private void InterpretCMPY(System.IO.BinaryWriter OutputFile, bool
IsLabelScan)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == '#')
            {
                CurrentNdx++;
                ushort val = ReadWordValue();
                AsLength += 3;
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x08);
                    OutputFile.Write(val);
                }
            }
        }
        private void InterpretCMPD(System.IO.BinaryWriter OutputFile, bool
        IsLabelScan)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == '#')
            {
                CurrentNdx++;
                ushort val = ReadWordValue();
                AsLength += 3;
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x09);
                    OutputFile.Write(val);
                }
            }
        }
        private void InterpretJMP(System.IO.BinaryWriter OutputFile, bool
IsLabelScan)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == '#')
            {
                CurrentNdx++;
                AsLength += 3;
                if (IsLabelScan) return;
                ushort val = ReadWordValue();
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x0A);
                    OutputFile.Write(val);
                }
            }
        }
        private void InterpretJEQ(System.IO.BinaryWriter OutputFile, bool
        IsLabelScan)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == '#')
            {
                CurrentNdx++;
                AsLength += 3;
                if (IsLabelScan) return;
                ushort val = ReadWordValue();
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x0B);
                    OutputFile.Write(val);
                }
            }
        }
        private void InterpretJNE(System.IO.BinaryWriter OutputFile, bool
        IsLabelScan)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == '#')
            {
                CurrentNdx++;
                AsLength += 3;
                if (IsLabelScan) return;
                ushort val = ReadWordValue();
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x0C);
                    OutputFile.Write(val);
                }
            }
        }

        private void InterpretJGT(System.IO.BinaryWriter OutputFile, bool
IsLabelScan)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == '#')
            {
                CurrentNdx++;
                AsLength += 3;
                if (IsLabelScan) return;
                ushort val = ReadWordValue();
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x0D);
                    OutputFile.Write(val);
                }
            }
        }
        private void InterpretJLT(System.IO.BinaryWriter OutputFile, bool
        IsLabelScan)
        {
            EatWhiteSpaces();
            if (SourceProgram[CurrentNdx] == '#')
            {
                CurrentNdx++;
                AsLength += 3;
                if (IsLabelScan) return;
                ushort val = ReadWordValue();
                if (!IsLabelScan)
                {
                    OutputFile.Write((byte)0x0E);
                    OutputFile.Write(val);
                }
            }
        }
        private void DoEnd(System.IO.BinaryWriter OutputFile, bool IsLabelScan)
        {
            AsLength++;
            if (!IsLabelScan)
            {
                OutputFile.Write((byte)0x04);
            }
        }
        #endregion

        #region Helper Functions
        private Registers ReadRegister()
        {
            Registers r = Registers.Unknown;
            if ((SourceProgram[CurrentNdx] == 'X') ||
            (SourceProgram[CurrentNdx] == 'x')) r = Registers.X;
            if ((SourceProgram[CurrentNdx] == 'Y') ||
            (SourceProgram[CurrentNdx] == 'y')) r = Registers.Y;
            if ((SourceProgram[CurrentNdx] == 'D') ||
            (SourceProgram[CurrentNdx] == 'd')) r = Registers.D;
            if ((SourceProgram[CurrentNdx] == 'A') ||
            (SourceProgram[CurrentNdx] == 'a')) r = Registers.A;
            if ((SourceProgram[CurrentNdx] == 'B') ||
            (SourceProgram[CurrentNdx] == 'b')) r = Registers.B;
            CurrentNdx++;
            return r;
        }

        private ushort ReadWordValue()
        {
            ushort val = 0;
            bool IsHex = false;
            string sval = "";
            if (SourceProgram[CurrentNdx] == '$')
            {
                CurrentNdx++;
                IsHex = true;
            }
            if ((IsHex == false) &&
(char.IsLetter(SourceProgram[CurrentNdx])))
            {
                val = (ushort)LabelTable[GetLabelName()];
                return val;
            }
            while (char.IsLetterOrDigit(SourceProgram[CurrentNdx]))
            {
                sval = sval + SourceProgram[CurrentNdx];
                CurrentNdx++;
            }
            if (IsHex)
            {
                val = Convert.ToUInt16(sval, 16);
            }
            else
            {
                val = ushort.Parse(sval);
            }
            return val;
        }
        private byte ReadByteValue()
        {
            byte val = 0;
            bool IsHex = false;
            string sval = "";
            if (SourceProgram[CurrentNdx] == '$')
            {
                CurrentNdx++;
                IsHex = true;
            }
            while (char.IsLetterOrDigit(SourceProgram[CurrentNdx]))
            {
                sval = sval + SourceProgram[CurrentNdx];
                CurrentNdx++;
            }
            if (IsHex)
            {
                val = Convert.ToByte(sval, 16);
            }
            else
            {
                val = byte.Parse(sval);
            }
            return val;
        }
        private void EatWhiteSpaces()
        {
            while (char.IsWhiteSpace(SourceProgram[CurrentNdx]))
            {
                CurrentNdx++;
            }
        }
        private string GetLabelName()
        {
            string lblname = "";
            while (char.IsLetterOrDigit(SourceProgram[CurrentNdx]))
            {
                if (SourceProgram[CurrentNdx] == ':')
                {
                    CurrentNdx++;
                    break;
                }
                lblname = lblname + SourceProgram[CurrentNdx];
                CurrentNdx++;
            }
            return lblname.ToUpper();
        }

        #endregion
    }


}