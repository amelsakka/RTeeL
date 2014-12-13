using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace RTeeL
{
    public partial class Form_Main : Form
    {
        RTeeL rtl;

        public Form_Main()
        {
            InitializeComponent();
            this.rtl = new RTeeL();
        }

        private void button_fixText_Click(object sender, EventArgs e)
        {
            textBox_fixed.Text = rtl.fixRTeeL(textBox_input.Text);
        }

        private void textBox_fixed_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
        }

        private void textBox_input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.A))
            {
                if (sender != null)
                    ((TextBox)sender).SelectAll();
                e.Handled = true;
            }
            else if (e.Alt && (e.KeyCode == Keys.Enter))
            {
                button_fixText_Click(sender, null);
            }
            else if (e.Control && (e.KeyCode == Keys.O))
            {
                button_fixFile_Click(sender, null);
            }
        }

        private void Form_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && (e.KeyCode == Keys.O))
            {
                button_fixFile_Click(sender, null);
            }
        }

        private void button_fixFile_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK && openFileDialog1.FileName != "") // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    string oldText = File.ReadAllText(file, Encoding.UTF8);
                    size = oldText.Length;
                    string fixedText = this.rtl.fixRTeeL(oldText);
                    if (SaveFile(fixedText))
                        MessageBox.Show("Your file was successfully fixed and saved.", "Success");
                    else
                    {
                        textBox_fixed.Text = fixedText;
                        MessageBox.Show("Error occured, unable to save to disk.\nAlternatively, the fixed text is now in the fixed text box.", "Error");
                    }
                }
                catch (IOException er)
                {
                    Console.WriteLine(er.Message);
                }
            }
        }

        private bool SaveFile(string txt) {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = saveFileDialog1.FileName;
                if (file != "")
                {
                    try
                    {
                        File.WriteAllText(file, txt, Encoding.UTF8);
                        return true;
                    }
                    catch (IOException er)
                    {
                        Console.WriteLine(er.Message);
                        return false;
                    }
                }
                else
                    return false;
            }
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.Show();
            about = null;
        }

    }

}
