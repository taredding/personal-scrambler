namespace Scrambler
{
    partial class ScramblerGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.button_input = new System.Windows.Forms.Button();
            this.in_file_textbox = new System.Windows.Forms.TextBox();
            this.label_error = new System.Windows.Forms.Label();
            this.textBox_key = new System.Windows.Forms.TextBox();
            this.out_file_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_auto_fill = new System.Windows.Forms.Button();
            this.button_decrypt = new System.Windows.Forms.Button();
            this.button_encrypt = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_input
            // 
            this.button_input.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_input.Location = new System.Drawing.Point(520, 16);
            this.button_input.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_input.Name = "button_input";
            this.button_input.Size = new System.Drawing.Size(87, 24);
            this.button_input.TabIndex = 1;
            this.button_input.Text = "Browse";
            this.button_input.UseVisualStyleBackColor = true;
            this.button_input.Click += new System.EventHandler(this.button_input_Click);
            // 
            // in_file_textbox
            // 
            this.in_file_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.in_file_textbox.Location = new System.Drawing.Point(113, 16);
            this.in_file_textbox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.in_file_textbox.Name = "in_file_textbox";
            this.in_file_textbox.Size = new System.Drawing.Size(402, 26);
            this.in_file_textbox.TabIndex = 0;
            this.in_file_textbox.TextChanged += new System.EventHandler(this.in_file_textbox_TextChanged);
            // 
            // label_error
            // 
            this.label_error.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_error.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_error.Location = new System.Drawing.Point(259, 156);
            this.label_error.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_error.Name = "label_error";
            this.label_error.Size = new System.Drawing.Size(352, 159);
            this.label_error.TabIndex = 4;
            // 
            // textBox_key
            // 
            this.textBox_key.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_key.Location = new System.Drawing.Point(113, 75);
            this.textBox_key.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_key.Name = "textBox_key";
            this.textBox_key.Size = new System.Drawing.Size(402, 26);
            this.textBox_key.TabIndex = 4;
            // 
            // out_file_textBox
            // 
            this.out_file_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.out_file_textBox.Location = new System.Drawing.Point(113, 46);
            this.out_file_textBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.out_file_textBox.Name = "out_file_textBox";
            this.out_file_textBox.Size = new System.Drawing.Size(402, 26);
            this.out_file_textBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 24);
            this.label1.TabIndex = 7;
            this.label1.Text = "Input File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 46);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 24);
            this.label2.TabIndex = 8;
            this.label2.Text = "Output File:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(64, 75);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "Key:";
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.Controls.Add(this.button_auto_fill);
            this.panel1.Controls.Add(this.in_file_textbox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.button_input);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBox_key);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.out_file_textBox);
            this.panel1.Location = new System.Drawing.Point(9, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(609, 119);
            this.panel1.TabIndex = 10;
            // 
            // button_auto_fill
            // 
            this.button_auto_fill.Enabled = false;
            this.button_auto_fill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_auto_fill.Location = new System.Drawing.Point(520, 46);
            this.button_auto_fill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_auto_fill.Name = "button_auto_fill";
            this.button_auto_fill.Size = new System.Drawing.Size(87, 24);
            this.button_auto_fill.TabIndex = 3;
            this.button_auto_fill.Text = "Same Dir.";
            this.button_auto_fill.UseVisualStyleBackColor = true;
            this.button_auto_fill.Click += new System.EventHandler(this.button_auto_fill_Click);
            // 
            // button_decrypt
            // 
            this.button_decrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_decrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_decrypt.Location = new System.Drawing.Point(129, 14);
            this.button_decrypt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_decrypt.Name = "button_decrypt";
            this.button_decrypt.Size = new System.Drawing.Size(106, 38);
            this.button_decrypt.TabIndex = 6;
            this.button_decrypt.Text = "Unscramble";
            this.button_decrypt.UseVisualStyleBackColor = true;
            this.button_decrypt.Click += new System.EventHandler(this.button_decrypt_Click);
            // 
            // button_encrypt
            // 
            this.button_encrypt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_encrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_encrypt.Location = new System.Drawing.Point(2, 14);
            this.button_encrypt.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_encrypt.Name = "button_encrypt";
            this.button_encrypt.Size = new System.Drawing.Size(106, 38);
            this.button_encrypt.TabIndex = 5;
            this.button_encrypt.Text = "Scramble";
            this.button_encrypt.UseVisualStyleBackColor = true;
            this.button_encrypt.Click += new System.EventHandler(this.button_encrypt_Click);
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.panel2.Controls.Add(this.button_encrypt);
            this.panel2.Controls.Add(this.button_decrypt);
            this.panel2.Location = new System.Drawing.Point(19, 142);
            this.panel2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(238, 63);
            this.panel2.TabIndex = 11;
            // 
            // ScramblerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 222);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_error);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MinimumSize = new System.Drawing.Size(637, 261);
            this.Name = "ScramblerGUI";
            this.Text = "Scrambler";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.Button button_input;
        private System.Windows.Forms.TextBox in_file_textbox;
        private System.Windows.Forms.Label label_error;
        private System.Windows.Forms.TextBox textBox_key;
        private System.Windows.Forms.TextBox out_file_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_decrypt;
        private System.Windows.Forms.Button button_encrypt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_auto_fill;
    }
}

