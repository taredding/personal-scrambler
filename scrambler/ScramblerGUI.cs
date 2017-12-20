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
    /// <summary>
    /// This is the GUI used to communicate user requests to the Scrambler class.
    /// </summary>
    public partial class ScramblerGUI : Form
    {
        /// <summary>
        /// Creates a new instance of the Scrambler GUI
        /// </summary>
        public ScramblerGUI() => InitializeComponent();

        /// <summary>
        /// Calls the appropriate methods to scramble a file
        /// </summary>
        /// <param name="sender">The object that raised the event (unused)</param>
        /// <param name="e">The arguments needed to execute the event (unused)</param>
        private void button_encrypt_Click(object sender, EventArgs e)
        {
            
            label_error.Text = "";
            if (!validateOverwrite(out_file_textBox.Text)) {
                return;
            }
            try
            {
                Scrambler.scramble(in_file_textbox.Text, out_file_textBox.Text, textBox_key.Text);
                label_error.Text = "File scrambled successfully.";
            }
            catch (Exception ex) {
                label_error.Text = "Error scrambling file: " + ex.Message;
            }
        }
        /// <summary>
        /// Calls the appropriate methods to unscramble a file
        /// </summary>
        /// <param name="sender">The object that raised the event (unused)</param>
        /// <param name="e">The arguments needed to execute the event (unused)</param>
        private void button_decrypt_Click(object sender, EventArgs e)
        {
            label_error.Text = "";
            if (!validateOverwrite(out_file_textBox.Text))
            {
                return;
            }
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
        /// <summary>
        /// This method verifies the user is willing to overwrite a file
        /// </summary>
        /// <param name="filename">The file the user should consider overwriting</param>
        /// <returns>Returns true if the user agrees to overwrite the file or the file doesn't exist. Otherwise returns false.</returns>
        private Boolean validateOverwrite(String filename) {
            Boolean valid = true;
            if (System.IO.File.Exists(filename)) {
                valid = (MessageBox.Show("Are you sure you want to overwrite " + filename + "?", "File already exists", MessageBoxButtons.YesNo) == DialogResult.Yes);
            }
            return valid;
        }

        /// <summary>
        /// Handles input file selection via file menu
        /// </summary>
        /// <param name="sender">The sender of the event request (unused)</param>
        /// <param name="e">The arguments relevant to the event request (unused)</param>
        private void button_input_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                in_file_textbox.Text = file.FileName;
            }
        }
        /// <summary>
        /// Disables the output directory auto fill button if the input file text is empty, otherwise enables it.
        /// </summary>
        /// <param name="sender">The sender of the event request (unused)</param>
        /// <param name="e">The arguments relevant to the event request (unused)</param>
        private void in_file_textbox_TextChanged(object sender, EventArgs e)
        {
            if (in_file_textbox.Text.Length == 0)
            {
                button_auto_fill.Enabled = false;
            }
            else {
                button_auto_fill.Enabled = true;
            }
        }
        /// <summary>
        /// Fills the output file text box with the contents of the input file text box, but removes the text past the last '/' or '\'
        /// </summary>
        /// <param name="sender">The sender of the event request (unused)</param>
        /// <param name="e">The arguments relevant to the event request (unused)</param>
        private void button_auto_fill_Click(object sender, EventArgs e)
        {
            String dir = in_file_textbox.Text;
            int trimPos = Math.Max(in_file_textbox.Text.LastIndexOf("\\"), in_file_textbox.Text.LastIndexOf("/"));
            if (trimPos > 0) {
                dir = dir.Substring(0, trimPos + 1);
            }
            out_file_textBox.Text = dir;
        }
    }
}
