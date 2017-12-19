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

namespace Scrambler
{
    public partial class ScramblerGUI : Form
    {
        String inputFile;
        String outputFile;
        public ScramblerGUI()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button_encrypt_Click(object sender, EventArgs e)
        {
            label_error.Text = "";
            try
            {
                Scrambler.scramble(in_file_textbox.Text, out_file_textBox.Text, textBox_key.Text);
                label_error.Text = "File scrambled successfully.";
            }
            catch (Exception ex) {
                label_error.Text = "Error scrambling file: " + ex.Message;
            }
        }

        private void button_decrypt_Click(object sender, EventArgs e)
        {
            label_error.Text = "";
            try
            {
                Scrambler.unscramble(in_file_textbox.Text, out_file_textBox.Text, textBox_key.Text);
                label_error.Text = "File unscrambled successfully.";
            }
            catch (Exception ex)
            {
                label_error.Text = "Error unscrambling file: " + ex.Message;
            }
        }


        private void button_input_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                in_file_textbox.Text = file.FileName;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
