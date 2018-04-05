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
using System.Drawing.Printing;
using System.Windows.Forms.VisualStyles;


namespace Notepad
{
    public partial class Notepad : Form
    {
        private uint printPageNumber;
        private StringReader myReader;
        string[] filter = { ".bmp", "GIF", ".gif", ".jpg", ".jpeg", ".png", ".tif", ".tiff" };
        public Notepad()
        {
            InitializeComponent();

        }

        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textBox.Clear();
        }

        private void MenuFileOpen()
        {
            if (openFileDialog.ShowDialog() ==
                System.Windows.Forms.DialogResult.OK &&
                openFileDialog.FileName.Length > 0 )
            {
                try
                {
                    textBox.LoadFile(openFileDialog.FileName,
                        RichTextBoxStreamType.RichText);
                }
                catch (System.ArgumentException ex)
                {
                    textBox.LoadFile(openFileDialog.FileName,
                        RichTextBoxStreamType.PlainText);
                }

                this.Text = "Файл [" + openFileDialog.FileName + "]";
            }
            

            else if (openFileDialog.Filter.EndsWith(".png") )
            {
                    Image img= Image.FromFile(openFileDialog.FileName);
                    pictureBox.Visible = true;
                    pictureBox.Image = img;
            }
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuFileOpen();
        }
        private void MenuFileSaveAs()
        {
            if (saveFileDialog1.ShowDialog() ==
                System.Windows.Forms.DialogResult.OK &&
                saveFileDialog1.FileName.Length > 0)
            {
                textBox.SaveFile(saveFileDialog1.FileName);
                this.Text = "Файл [" + saveFileDialog1.FileName + "]";
            }
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuFileSaveAs();
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuFileSaveAs();
        }


        private void MenuFilePrint()
        {
            printPageNumber = 1;

            string strText = this.textBox.Text;
            myReader = new StringReader(strText);

            Margins margins = new Margins(100, 50, 50, 50);
            printDocument1.DefaultPageSettings.Margins = margins;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
            myReader.Close();
        }

        private void PrintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuFilePrint();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

   }
}
