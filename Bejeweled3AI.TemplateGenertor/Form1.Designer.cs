namespace Bejeweled3AI.TemplateGenertor
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.pbScreen = new System.Windows.Forms.PictureBox();
            this.pbSelected = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SyncScreenTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.cbModes = new System.Windows.Forms.ComboBox();
            this.cbColuna = new System.Windows.Forms.ComboBox();
            this.cbLinha = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.lblBlock = new System.Windows.Forms.Label();
            this.cbBlockType = new System.Windows.Forms.ComboBox();
            this.lbTemplate = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pbCropTemplate = new System.Windows.Forms.PictureBox();
            this.btnClearTemplates = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblAvgColor = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnStop = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCropTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // pbScreen
            // 
            this.pbScreen.Location = new System.Drawing.Point(12, 28);
            this.pbScreen.Name = "pbScreen";
            this.pbScreen.Size = new System.Drawing.Size(512, 512);
            this.pbScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbScreen.TabIndex = 0;
            this.pbScreen.TabStop = false;
            this.pbScreen.Click += new System.EventHandler(this.pbScreen_Click);
            // 
            // pbSelected
            // 
            this.pbSelected.Location = new System.Drawing.Point(928, 115);
            this.pbSelected.Name = "pbSelected";
            this.pbSelected.Size = new System.Drawing.Size(64, 64);
            this.pbSelected.TabIndex = 1;
            this.pbSelected.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(925, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Selecionado";
            // 
            // SyncScreenTimer
            // 
            this.SyncScreenTimer.Enabled = true;
            this.SyncScreenTimer.Interval = 20;
            this.SyncScreenTimer.Tick += new System.EventHandler(this.SyncScreen);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(925, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Game Mode";
            // 
            // cbModes
            // 
            this.cbModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModes.FormattingEnabled = true;
            this.cbModes.Location = new System.Drawing.Point(928, 28);
            this.cbModes.Name = "cbModes";
            this.cbModes.Size = new System.Drawing.Size(132, 21);
            this.cbModes.TabIndex = 4;
            // 
            // cbColuna
            // 
            this.cbColuna.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColuna.FormattingEnabled = true;
            this.cbColuna.Location = new System.Drawing.Point(1007, 71);
            this.cbColuna.Name = "cbColuna";
            this.cbColuna.Size = new System.Drawing.Size(53, 21);
            this.cbColuna.TabIndex = 5;
            // 
            // cbLinha
            // 
            this.cbLinha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLinha.FormattingEnabled = true;
            this.cbLinha.Location = new System.Drawing.Point(928, 71);
            this.cbLinha.Name = "cbLinha";
            this.cbLinha.Size = new System.Drawing.Size(62, 21);
            this.cbLinha.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1027, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Linha";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(925, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Coluna";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(928, 229);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(64, 23);
            this.btnGenerate.TabIndex = 9;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.GenerateTemplate);
            // 
            // lblBlock
            // 
            this.lblBlock.AutoSize = true;
            this.lblBlock.Location = new System.Drawing.Point(925, 186);
            this.lblBlock.Name = "lblBlock";
            this.lblBlock.Size = new System.Drawing.Size(92, 13);
            this.lblBlock.TabIndex = 10;
            this.lblBlock.Text = "Gema selecinada:";
            // 
            // cbBlockType
            // 
            this.cbBlockType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBlockType.FormattingEnabled = true;
            this.cbBlockType.Location = new System.Drawing.Point(928, 202);
            this.cbBlockType.Name = "cbBlockType";
            this.cbBlockType.Size = new System.Drawing.Size(132, 21);
            this.cbBlockType.TabIndex = 11;
            // 
            // lbTemplate
            // 
            this.lbTemplate.FormattingEnabled = true;
            this.lbTemplate.Location = new System.Drawing.Point(530, 28);
            this.lbTemplate.Name = "lbTemplate";
            this.lbTemplate.Size = new System.Drawing.Size(389, 511);
            this.lbTemplate.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(530, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Template";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Grid";
            // 
            // pbCropTemplate
            // 
            this.pbCropTemplate.Location = new System.Drawing.Point(996, 115);
            this.pbCropTemplate.Name = "pbCropTemplate";
            this.pbCropTemplate.Size = new System.Drawing.Size(64, 64);
            this.pbCropTemplate.TabIndex = 15;
            this.pbCropTemplate.TabStop = false;
            // 
            // btnClearTemplates
            // 
            this.btnClearTemplates.Location = new System.Drawing.Point(996, 516);
            this.btnClearTemplates.Name = "btnClearTemplates";
            this.btnClearTemplates.Size = new System.Drawing.Size(64, 23);
            this.btnClearTemplates.TabIndex = 16;
            this.btnClearTemplates.Text = "Clear";
            this.btnClearTemplates.UseVisualStyleBackColor = true;
            this.btnClearTemplates.Click += new System.EventHandler(this.ClearTemplates);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(928, 515);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(64, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblAvgColor
            // 
            this.lblAvgColor.AutoSize = true;
            this.lblAvgColor.Location = new System.Drawing.Point(993, 99);
            this.lblAvgColor.Name = "lblAvgColor";
            this.lblAvgColor.Size = new System.Drawing.Size(53, 13);
            this.lblAvgColor.TabIndex = 18;
            this.lblAvgColor.Text = "Avg Color";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(928, 258);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(132, 23);
            this.progressBar1.TabIndex = 19;
            this.progressBar1.Visible = false;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(998, 229);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(64, 23);
            this.btnStop.TabIndex = 20;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.StopGeneration);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 550);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblAvgColor);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClearTemplates);
            this.Controls.Add(this.pbCropTemplate);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lbTemplate);
            this.Controls.Add(this.cbBlockType);
            this.Controls.Add(this.lblBlock);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbLinha);
            this.Controls.Add(this.cbColuna);
            this.Controls.Add(this.cbModes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbSelected);
            this.Controls.Add(this.pbScreen);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCropTemplate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbScreen;
        private System.Windows.Forms.PictureBox pbSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer SyncScreenTimer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbModes;
        private System.Windows.Forms.ComboBox cbColuna;
        private System.Windows.Forms.ComboBox cbLinha;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblBlock;
        private System.Windows.Forms.ComboBox cbBlockType;
        private System.Windows.Forms.ListBox lbTemplate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pbCropTemplate;
        private System.Windows.Forms.Button btnClearTemplates;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblAvgColor;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnStop;
    }
}

