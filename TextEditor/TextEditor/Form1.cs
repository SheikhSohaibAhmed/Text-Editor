using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        int indexatstart = 0, index = 0, length = 0, length_pri = 0, index_pri = 0;
        string Word = " ", Filename,Filepath, Filename_Font = Path.GetFullPath(@"C: \Users\Sohaib\Documents\Visual Studio 2017\Projects\TextEditor\TextEditor\Font.txt");
        public Form1()
        {
            InitializeComponent();
            if (TextFeild.Text == "")
            {
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                findToolStripMenuItem.Enabled = false;
                findNextToolStripMenuItem.Enabled = false;
            }
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextFeild.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextFeild.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextFeild.Paste();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextFeild.SelectAll();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextFeild.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextFeild.Redo();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cvt = new FontConverter();
            string Fontfamily = cvt.ConvertToString(TextFeild.SelectionFont);
            File.SetAttributes(Filename_Font, FileAttributes.Normal);
            File.WriteAllText(Filename_Font, Fontfamily);
            Fontfamily = cvt.ConvertToString(TextFeild);
            File.AppendAllText(Filename_Font, Fontfamily);
            Fontfamily = cvt.ConvertToString(TextFeild.SelectionLength);
            File.AppendAllText(Filename_Font, Fontfamily);
            Application.Exit();
            
            //Font f = cvt.ConvertFromString(s) as Font;

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextFeild.SelectedText = "";
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fontDialog1.ShowDialog() == DialogResult.OK)
            TextFeild.SelectionFont = fontDialog1.Font;
        }

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
                TextFeild.SelectionColor = colorDialog1.Color;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, TextFeild.Text);
                Filepath = saveFileDialog1.FileName;
                Filename = Path.GetFileName(Filepath);
                this.Text = Filename; 
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var cvt = new FontConverter();
                TextFeild.Text = File.ReadAllText(openFileDialog1.FileName);
                Filepath = openFileDialog1.FileName;
                Filename = Path.GetFileName(Filepath);
                this.Text = Filename;
                string Fontfamily = File.ReadAllText(Filename_Font);
                //Font f = cvt.ConvertFromString(Fontfamily) as Font;
                //TextFeild.SelectionFont = f;
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (Filepath != null)
            {
                File.SetAttributes(Filepath, FileAttributes.Normal);
                File.WriteAllText(Filepath, TextFeild.Text);
            }
            else if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, TextFeild.Text);
                Filepath = saveFileDialog1.FileName;
                Filename = Path.GetFileName(Filepath);
                this.Text = Filename;
            }

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextFeild.Text = "";
            Filename = null;
        }

        private void TextFeild_MouseClick(object sender, MouseEventArgs e)
        {
            int length_pri = 0, index_pri = 0;
            Text = TextFeild.Text;
            indexatstart = index = TextFeild.SelectionStart;
            if (Text.Contains(Word) && Word != "")
            {
                index = 0;
                while (index_pri != -1)
                {
                    length_pri = 0; index_pri = 0;
                    length_pri = Word.Length;
                    index_pri = Text.IndexOf(Word, index + length);
                    if (index_pri != -1)
                    {
                        TextFeild.Select(index_pri, length_pri);
                        TextFeild.SelectionBackColor = Color.White;
                    }
                    length = length_pri; index = index_pri;
                }
            }
            length = 0;
            string selectiontext = "";
            index = TextFeild.SelectionStart = indexatstart;
            index--;
            if (index < Text.Length)
                selectiontext = Text.Substring(index, 1);
            while (selectiontext != " " && selectiontext != "\n")
            {
                length++;
                index--;
                if (index >= 0)
                    selectiontext = Text.Substring(index, 1);
                else
                    selectiontext = "\n";
            }
            index = index + (length);
            index++;
            if (index < Text.Length)
                selectiontext = Text.Substring(index, 1);
            while (selectiontext != " " && selectiontext != "\n")
            {
                length++;
                index++;
                if (index < Text.Length)
                    selectiontext = Text.Substring(index, 1);
                else
                    selectiontext = "\n";
            }
            index = index - length;
            length_pri = 0; index_pri = 0;
            Word = Text.Substring(index, length);
            if (Text.Contains(Word) && Word != "")
            {
                index = 0;
                while (index_pri != -1)
                {
                    length_pri = 0; index_pri = 0;
                    length_pri = Word.Length;
                    index_pri = Text.IndexOf(Word, index + length);
                    if (index_pri != -1)
                    {
                            TextFeild.Select(index_pri, length_pri);
                            TextFeild.SelectionBackColor = Color.LightGray;
                    }
                    length = length_pri; index = index_pri;
                }
                TextFeild.SelectionStart = indexatstart;
                TextFeild.SelectionLength = 0;
            }
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find_Replace form = new Find_Replace(this);
            form.Show();
        }

        private void TextFeild_SelectionChanged(object sender, EventArgs e)
        {
           
        }

        private void findNextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find_Replace form = new Find_Replace(this);
            form.Show();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find_Replace form = new Find_Replace(this);
            form.Show();
        }

        private void TextFeild_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right || e.KeyCode == Keys.Left)
            {
                int length_pri = 0, index_pri = 0;
                Text = TextFeild.Text;
                indexatstart = index = TextFeild.SelectionStart;
                if (Text.Contains(Word) && Word != "")
                {
                    index = 0;
                    while (index_pri != -1)
                    {
                        length_pri = 0; index_pri = 0;
                        length_pri = Word.Length;
                        index_pri = Text.IndexOf(Word, index + length);
                        if (index_pri != -1)
                        {
                            TextFeild.Select(index_pri, length_pri);
                            TextFeild.SelectionBackColor = Color.White;
                        }
                        length = length_pri; index = index_pri;
                    }
                }
                length = 0;
                string selectiontext = "";
                if (e.KeyCode == Keys.Right)
                    indexatstart++;
                else if (e.KeyCode == Keys.Left)
                    indexatstart--;
                else if (e.KeyCode == Keys.Up)
                {
                    index = TextFeild.SelectionStart = indexatstart;
                    index--;
                    if (index < Text.Length)
                        selectiontext = Text.Substring(index, 1);
                    while (selectiontext != "\n")
                    {
                        length++;
                        index--;
                        if (index >= 0)
                            selectiontext = Text.Substring(index, 1);
                        else
                            selectiontext = "\n";
                    }
                    length++;
                    index--;
                    if (index < Text.Length)
                        selectiontext = Text.Substring(index, 1);
                    while (selectiontext != "\n")
                    {
                        index--;
                        if (index >= 0)
                            selectiontext = Text.Substring(index, 1);
                        else
                            selectiontext = "\n";
                    }
                    indexatstart = index + length;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    index = TextFeild.SelectionStart = indexatstart;
                    index--;
                    if (index < Text.Length)
                        selectiontext = Text.Substring(index, 1);
                    while (selectiontext != "\n")
                    {
                        length++;
                        index--;
                        if (index >= 0)
                            selectiontext = Text.Substring(index, 1);
                        else
                            selectiontext = "\n";
                    }
                    index++;
                    if (index < Text.Length)
                        selectiontext = Text.Substring(index, 1);
                    while (selectiontext != "\n")
                    {
                        index++;
                        if (index >= 0)
                            selectiontext = Text.Substring(index, 1);
                        else
                            selectiontext = "\n";
                    }
                    indexatstart = index + (length + 1);
                }
                length = 0;
                selectiontext = "";
                index = TextFeild.SelectionStart = indexatstart;
                index--;
                if (index < Text.Length)
                    selectiontext = Text.Substring(index, 1);
                while (selectiontext != " " && selectiontext != "\n")
                {
                    length++;
                    index--;
                    if (index >= 0)
                        selectiontext = Text.Substring(index, 1);
                    else
                        selectiontext = "\n";
                }
                index = index + (length);
                index++;
                if (index < Text.Length)
                    selectiontext = Text.Substring(index, 1);
                while (selectiontext != " " && selectiontext != "\n")
                {
                    length++;
                    index++;
                    if (index < Text.Length)
                        selectiontext = Text.Substring(index, 1);
                    else
                        selectiontext = "\n";
                }
                if (e.KeyCode == Keys.Right)
                    indexatstart--;
                else if (e.KeyCode == Keys.Left)
                    indexatstart++;
                else if (e.KeyCode == Keys.Down)
                    indexatstart = indexatstart - (length + 1);
                else if (e.KeyCode == Keys.Up)
                    indexatstart = indexatstart + (length + 1);
                index = index - length;
                length_pri = 0; index_pri = 0;
                if((index + length) <= Text.Length)
                Word = Text.Substring(index, length);
                if (Text.Contains(Word) && Word != "")
                {
                    index = 0;
                    while (index_pri != -1)
                    {
                        length_pri = 0; index_pri = 0;
                        length_pri = Word.Length;
                        index_pri = Text.IndexOf(Word, index + length);
                        if (index_pri != -1)
                        {
                            TextFeild.Select(index_pri, length_pri);
                            TextFeild.SelectionBackColor = Color.LightGray;
                        }
                        length = length_pri; index = index_pri;
                    }
                    TextFeild.SelectionStart = indexatstart;
                    TextFeild.SelectionLength = 0;
                }
            }
            else 
            {
                int length_pri = 0, index_pri = 0;
                Text = TextFeild.Text;
                indexatstart = index = TextFeild.SelectionStart;
                if (Text.Contains(Word) && Word != "")
                {
                    index = 0;
                    while (index_pri != -1)
                    {
                        length_pri = 0; index_pri = 0;
                        length_pri = Word.Length;
                        index_pri = Text.IndexOf(Word, index + length);
                        if (index_pri != -1)
                        {
                            TextFeild.Select(index_pri, length_pri);
                            TextFeild.SelectionBackColor = Color.White;
                        }
                        length = length_pri; index = index_pri;
                    }
                }
                TextFeild.SelectionStart = indexatstart;
                TextFeild.SelectionLength = 0;
            }
        }

        private void TextFeild_TextChanged(object sender, EventArgs e)
        {
            if (TextFeild.Text == "")
            {
                cutToolStripMenuItem.Enabled = false;
                cutToolStripMenuItem.Enabled = false;
                copyToolStripMenuItem.Enabled = false;
                deleteToolStripMenuItem.Enabled = false;
                findToolStripMenuItem.Enabled = false;
                findNextToolStripMenuItem.Enabled = false;
            }
            else
            {
                cutToolStripMenuItem.Enabled = true;
                copyToolStripMenuItem.Enabled = true;
                deleteToolStripMenuItem.Enabled = true;
                findToolStripMenuItem.Enabled = true;
                findNextToolStripMenuItem.Enabled = true;
            }
        }

        public string RichBoxText
        {
            get { return TextFeild.Text; }
            set { TextFeild.Text = value; }
        }
    }
}
