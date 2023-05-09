using System.Windows.Forms;

namespace Sepia_projekt_JA
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUpload = new System.Windows.Forms.Button();
            this.radioASM = new System.Windows.Forms.RadioButton();
            this.radioCS = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.labelThreads = new System.Windows.Forms.Label();
            this.threadsTrackbar = new System.Windows.Forms.TrackBar();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.labelTime = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericIntensity = new System.Windows.Forms.NumericUpDown();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.picOriginal = new System.Windows.Forms.PictureBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.picModified = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threadsTrackbar)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericIntensity)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).BeginInit();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picModified)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpload
            // 
            this.btnUpload.Location = new System.Drawing.Point(6, 20);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(277, 28);
            this.btnUpload.TabIndex = 0;
            this.btnUpload.Text = "Choose image...";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.choose_Click);
            // 
            // radioASM
            // 
            this.radioASM.AutoSize = true;
            this.radioASM.Location = new System.Drawing.Point(34, 19);
            this.radioASM.Name = "radioASM";
            this.radioASM.Size = new System.Drawing.Size(48, 17);
            this.radioASM.TabIndex = 5;
            this.radioASM.TabStop = true;
            this.radioASM.Text = "ASM";
            this.radioASM.UseVisualStyleBackColor = true;
            // 
            // radioCS
            // 
            this.radioCS.AutoSize = true;
            this.radioCS.Location = new System.Drawing.Point(149, 19);
            this.radioCS.Name = "radioCS";
            this.radioCS.Size = new System.Drawing.Size(39, 17);
            this.radioCS.TabIndex = 6;
            this.radioCS.TabStop = true;
            this.radioCS.Text = "C#";
            this.radioCS.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(7, 54);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(276, 28);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save image as BMP...";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.save_Click);
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(7, 88);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(276, 28);
            this.btnApply.TabIndex = 9;
            this.btnApply.Text = "Apply effect";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.apply_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioASM);
            this.groupBox1.Controls.Add(this.radioCS);
            this.groupBox1.Location = new System.Drawing.Point(12, 320);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(221, 51);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Library";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnUpload);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnApply);
            this.groupBox2.Location = new System.Drawing.Point(607, 320);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(291, 125);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Image action";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.labelThreads);
            this.groupBox3.Controls.Add(this.threadsTrackbar);
            this.groupBox3.Location = new System.Drawing.Point(12, 377);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(587, 68);
            this.groupBox3.TabIndex = 12;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Used threads";
            // 
            // labelThreads
            // 
            this.labelThreads.AutoSize = true;
            this.labelThreads.Location = new System.Drawing.Point(293, 49);
            this.labelThreads.Name = "labelThreads";
            this.labelThreads.Size = new System.Drawing.Size(13, 13);
            this.labelThreads.TabIndex = 17;
            this.labelThreads.Text = "--";
            // 
            // threadsTrackbar
            // 
            this.threadsTrackbar.LargeChange = 4;
            this.threadsTrackbar.Location = new System.Drawing.Point(6, 17);
            this.threadsTrackbar.Maximum = 64;
            this.threadsTrackbar.Minimum = 1;
            this.threadsTrackbar.Name = "threadsTrackbar";
            this.threadsTrackbar.Size = new System.Drawing.Size(573, 45);
            this.threadsTrackbar.TabIndex = 16;
            this.threadsTrackbar.Value = 1;
            this.threadsTrackbar.Scroll += new System.EventHandler(this.threads_Scroll);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelTime);
            this.groupBox4.Location = new System.Drawing.Point(455, 320);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(146, 51);
            this.groupBox4.TabIndex = 13;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Time elapsed";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(58, 21);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(32, 13);
            this.labelTime.TabIndex = 15;
            this.labelTime.Text = "--- ms";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label4);
            this.groupBox5.Controls.Add(this.numericIntensity);
            this.groupBox5.Location = new System.Drawing.Point(239, 320);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(213, 51);
            this.groupBox5.TabIndex = 11;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Effect\'s intensity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "%";
            // 
            // numericIntensity
            // 
            this.numericIntensity.Location = new System.Drawing.Point(17, 19);
            this.numericIntensity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericIntensity.Name = "numericIntensity";
            this.numericIntensity.Size = new System.Drawing.Size(162, 20);
            this.numericIntensity.TabIndex = 0;
            this.numericIntensity.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.picOriginal);
            this.groupBox6.Location = new System.Drawing.Point(12, 12);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(440, 302);
            this.groupBox6.TabIndex = 14;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Original image";
            // 
            // picOriginal
            // 
            this.picOriginal.Location = new System.Drawing.Point(6, 19);
            this.picOriginal.Name = "picOriginal";
            this.picOriginal.Size = new System.Drawing.Size(428, 277);
            this.picOriginal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picOriginal.TabIndex = 0;
            this.picOriginal.TabStop = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.picModified);
            this.groupBox7.Location = new System.Drawing.Point(458, 12);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(440, 302);
            this.groupBox7.TabIndex = 15;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Modified image";
            // 
            // picModified
            // 
            this.picModified.Location = new System.Drawing.Point(6, 19);
            this.picModified.Name = "picModified";
            this.picModified.Size = new System.Drawing.Size(428, 277);
            this.picModified.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picModified.TabIndex = 1;
            this.picModified.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 457);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Sepia";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.threadsTrackbar)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericIntensity)).EndInit();
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picOriginal)).EndInit();
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picModified)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.RadioButton radioASM;
        private System.Windows.Forms.RadioButton radioCS;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnApply;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TrackBar threadsTrackbar;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericIntensity;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.PictureBox picOriginal;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.PictureBox picModified;
        private System.Windows.Forms.Label labelThreads;
    }
}

