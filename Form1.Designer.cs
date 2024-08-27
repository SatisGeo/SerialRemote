namespace SerialRemote
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            l_field = new Label();
            label1 = new Label();
            l_error = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            l_decay = new Label();
            l_amplitude = new Label();
            l_downfield = new Label();
            l_upfield = new Label();
            r_single = new RadioButton();
            groupBox1 = new GroupBox();
            r_gradient = new RadioButton();
            groupBox2 = new GroupBox();
            c_aut = new CheckBox();
            label6 = new Label();
            n_tunedown = new NumericUpDown();
            label2 = new Label();
            n_tuneup = new NumericUpDown();
            b_set = new Button();
            b_measure = new Button();
            n_serialport = new NumericUpDown();
            label7 = new Label();
            b_open_close = new Button();
            label8 = new Label();
            l_timestamp = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)n_tunedown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)n_tuneup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)n_serialport).BeginInit();
            SuspendLayout();
            // 
            // l_field
            // 
            l_field.AutoSize = true;
            l_field.Font = new Font("Segoe UI", 32F);
            l_field.Location = new Point(62, 84);
            l_field.Name = "l_field";
            l_field.Size = new Size(195, 59);
            l_field.TabIndex = 0;
            l_field.Text = "99999.99";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(62, 170);
            label1.Name = "label1";
            label1.Size = new Size(85, 25);
            label1.TabIndex = 1;
            label1.Text = "Up Field:";
            // 
            // l_error
            // 
            l_error.AutoSize = true;
            l_error.Font = new Font("Segoe UI", 14F);
            l_error.Location = new Point(253, 111);
            l_error.Name = "l_error";
            l_error.Size = new Size(80, 25);
            l_error.TabIndex = 2;
            l_error.Text = "±99.9nT";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F);
            label3.Location = new Point(62, 195);
            label3.Name = "label3";
            label3.Size = new Size(110, 25);
            label3.TabIndex = 4;
            label3.Text = "Down Field:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.Location = new Point(62, 220);
            label4.Name = "label4";
            label4.Size = new Size(103, 25);
            label4.TabIndex = 5;
            label4.Text = "Amplitude:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(62, 245);
            label5.Name = "label5";
            label5.Size = new Size(67, 25);
            label5.TabIndex = 6;
            label5.Text = "Decay:";
            // 
            // l_decay
            // 
            l_decay.AutoSize = true;
            l_decay.Font = new Font("Segoe UI", 14F);
            l_decay.Location = new Point(190, 245);
            l_decay.Name = "l_decay";
            l_decay.Size = new Size(49, 25);
            l_decay.TabIndex = 10;
            l_decay.Text = "0.6 s";
            // 
            // l_amplitude
            // 
            l_amplitude.AutoSize = true;
            l_amplitude.Font = new Font("Segoe UI", 14F);
            l_amplitude.Location = new Point(190, 220);
            l_amplitude.Name = "l_amplitude";
            l_amplitude.Size = new Size(32, 25);
            l_amplitude.TabIndex = 9;
            l_amplitude.Text = "10";
            // 
            // l_downfield
            // 
            l_downfield.AutoSize = true;
            l_downfield.Font = new Font("Segoe UI", 14F);
            l_downfield.Location = new Point(190, 195);
            l_downfield.Name = "l_downfield";
            l_downfield.Size = new Size(149, 25);
            l_downfield.TabIndex = 8;
            l_downfield.Text = "99999.9 ±99.9nT";
            // 
            // l_upfield
            // 
            l_upfield.AutoSize = true;
            l_upfield.Font = new Font("Segoe UI", 14F);
            l_upfield.Location = new Point(190, 170);
            l_upfield.Name = "l_upfield";
            l_upfield.Size = new Size(149, 25);
            l_upfield.TabIndex = 7;
            l_upfield.Text = "99999.9 ±99.9nT";
            // 
            // r_single
            // 
            r_single.AutoSize = true;
            r_single.Checked = true;
            r_single.Location = new Point(6, 22);
            r_single.Name = "r_single";
            r_single.Size = new Size(57, 19);
            r_single.TabIndex = 11;
            r_single.TabStop = true;
            r_single.Text = "Single";
            r_single.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(r_gradient);
            groupBox1.Controls.Add(r_single);
            groupBox1.Location = new Point(385, 84);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(108, 79);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            groupBox1.Text = "Mode";
            // 
            // r_gradient
            // 
            r_gradient.AutoSize = true;
            r_gradient.Location = new Point(6, 47);
            r_gradient.Name = "r_gradient";
            r_gradient.Size = new Size(70, 19);
            r_gradient.TabIndex = 12;
            r_gradient.Text = "Gradient";
            r_gradient.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(c_aut);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(n_tunedown);
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(n_tuneup);
            groupBox2.Location = new Point(385, 170);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(110, 165);
            groupBox2.TabIndex = 13;
            groupBox2.TabStop = false;
            groupBox2.Text = "Tune";
            // 
            // c_aut
            // 
            c_aut.AutoSize = true;
            c_aut.Checked = true;
            c_aut.CheckState = CheckState.Checked;
            c_aut.Location = new Point(6, 22);
            c_aut.Name = "c_aut";
            c_aut.Size = new Size(52, 19);
            c_aut.TabIndex = 17;
            c_aut.Text = "Auto";
            c_aut.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 102);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 16;
            label6.Text = "Down Sensor";
            // 
            // n_tunedown
            // 
            n_tunedown.Location = new Point(6, 120);
            n_tunedown.Maximum = new decimal(new int[] { 99990, 0, 0, 0 });
            n_tunedown.Minimum = new decimal(new int[] { 20000, 0, 0, 0 });
            n_tunedown.Name = "n_tunedown";
            n_tunedown.Size = new Size(83, 23);
            n_tunedown.TabIndex = 15;
            n_tunedown.Value = new decimal(new int[] { 45739, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 53);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 14;
            label2.Text = "Up Sensor";
            // 
            // n_tuneup
            // 
            n_tuneup.Location = new Point(6, 71);
            n_tuneup.Maximum = new decimal(new int[] { 99990, 0, 0, 0 });
            n_tuneup.Minimum = new decimal(new int[] { 20000, 0, 0, 0 });
            n_tuneup.Name = "n_tuneup";
            n_tuneup.Size = new Size(83, 23);
            n_tuneup.TabIndex = 13;
            n_tuneup.Value = new decimal(new int[] { 45739, 0, 0, 0 });
            // 
            // b_set
            // 
            b_set.Enabled = false;
            b_set.Location = new Point(399, 353);
            b_set.Name = "b_set";
            b_set.Size = new Size(75, 23);
            b_set.TabIndex = 14;
            b_set.Text = "Set";
            b_set.UseVisualStyleBackColor = true;
            b_set.Click += b_set_Click;
            // 
            // b_measure
            // 
            b_measure.Enabled = false;
            b_measure.Location = new Point(62, 353);
            b_measure.Name = "b_measure";
            b_measure.Size = new Size(75, 23);
            b_measure.TabIndex = 15;
            b_measure.Text = "Measure";
            b_measure.UseVisualStyleBackColor = true;
            b_measure.Click += b_measure_Click;
            // 
            // n_serialport
            // 
            n_serialport.Location = new Point(72, 23);
            n_serialport.Name = "n_serialport";
            n_serialport.Size = new Size(83, 23);
            n_serialport.TabIndex = 18;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(72, 5);
            label7.Name = "label7";
            label7.Size = new Size(80, 15);
            label7.TabIndex = 18;
            label7.Text = "Serial Port no.";
            // 
            // b_open_close
            // 
            b_open_close.Location = new Point(181, 21);
            b_open_close.Name = "b_open_close";
            b_open_close.Size = new Size(75, 23);
            b_open_close.TabIndex = 19;
            b_open_close.Text = "Open";
            b_open_close.UseVisualStyleBackColor = true;
            b_open_close.Click += b_open_close_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F);
            label8.Location = new Point(62, 145);
            label8.Name = "label8";
            label8.Size = new Size(114, 25);
            label8.TabIndex = 20;
            label8.Text = "Time Stamp:";
            // 
            // l_timestamp
            // 
            l_timestamp.AutoSize = true;
            l_timestamp.Font = new Font("Segoe UI", 14F);
            l_timestamp.Location = new Point(190, 145);
            l_timestamp.Name = "l_timestamp";
            l_timestamp.Size = new Size(90, 25);
            l_timestamp.TabIndex = 21;
            l_timestamp.Text = "12.3.2024";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(569, 440);
            Controls.Add(l_timestamp);
            Controls.Add(label8);
            Controls.Add(b_open_close);
            Controls.Add(label7);
            Controls.Add(n_serialport);
            Controls.Add(b_measure);
            Controls.Add(b_set);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(l_decay);
            Controls.Add(l_amplitude);
            Controls.Add(l_downfield);
            Controls.Add(l_upfield);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(l_error);
            Controls.Add(label1);
            Controls.Add(l_field);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            Text = "Serial Remote Example";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)n_tunedown).EndInit();
            ((System.ComponentModel.ISupportInitialize)n_tuneup).EndInit();
            ((System.ComponentModel.ISupportInitialize)n_serialport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label l_field;
        private Label label1;
        private Label l_error;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label l_decay;
        private Label l_amplitude;
        private Label l_downfield;
        private Label l_upfield;
        private RadioButton r_single;
        private GroupBox groupBox1;
        private RadioButton r_gradient;
        private GroupBox groupBox2;
        private CheckBox c_aut;
        private Label label6;
        private NumericUpDown n_tunedown;
        private Label label2;
        private NumericUpDown n_tuneup;
        private Button b_set;
        private Button b_measure;
        private NumericUpDown n_serialport;
        private Label label7;
        private Button b_open_close;
        private Label label8;
        private Label l_timestamp;
    }
}
