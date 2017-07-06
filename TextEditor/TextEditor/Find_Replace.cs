using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor
{
    public partial class Find_Replace : Form
    {
        int clickcount = 0, length = 0, index = 0;
        public Find_Replace()
        {
            InitializeComponent();
        }
        private Form1 mainForm = null;
        public Find_Replace(Form callingForm)
        {
            mainForm = callingForm as Form1;
            InitializeComponent();
        }

        private void btnfindnext_Click(object sender, EventArgs e)
        {
            string Word;
            int length_pri = 0, index_pri = 0;
            Word = tbfind.Text;
            string Text = mainForm.TextFeild.Text;
            if (Text.Contains(Word))
            {
                for (int i = 0; i<=clickcount; i++)
                {
                    length_pri = Word.Length;
                    index_pri = Text.IndexOf(Word,index+length);
                    if (index_pri != -1)
                    {
                        mainForm.TextFeild.Select(index_pri, length_pri);
                        mainForm.TextFeild.HideSelection = false;
                    }
                }
            }
            clickcount++;
            length = length_pri; index = index_pri;
            length_pri = 0; index_pri = 0;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
             Close();
        }

        private void btnfindall_Click(object sender, EventArgs e)
        {
            string Word;
            int length_pri = 0, index_pri = 0;
            Word = tbfind.Text;
            string Text = mainForm.TextFeild.Text;
            if (Text.Contains(Word) && Word !="")
            {
                while (index_pri != -1)
                {
                    length_pri = 0; index_pri = 0;
                    length_pri = Word.Length;
                    index_pri = Text.IndexOf(Word, index + length);
                    if (index_pri != -1)
                    {
                        mainForm.TextFeild.Select(index_pri, length_pri);
                        mainForm.TextFeild.SelectionBackColor = Color.LightBlue;
                    }
                    length = length_pri; index = index_pri;
                }
            }
        }

        private void btnreplace_Click(object sender, EventArgs e)
        {
            string Word;
            //int length = 0, index = 0;
            Word = tbfind.Text;
            string Text = mainForm.TextFeild.Text;
            if (Text.Contains(Word))
            {
                //length = Word.Length;
                //index = Text.IndexOf(Word);
                Text = Text.Remove(index, length);
                Text = Text.Insert(index, tbreplace.Text);
                mainForm.TextFeild.Text = Text;
            }
        }

        private void btnreplaceall_Click(object sender, EventArgs e)
        {
            string Word;
            Word = tbfind.Text;
            string Text = mainForm.TextFeild.Text;
            if (Text.Contains(Word))
            {
                if (tbreplace.Text != "")
                {
                    Text = Text.Replace(Word, tbreplace.Text);
                    mainForm.TextFeild.Text = Text;
                }
            }
        }
    }
}
