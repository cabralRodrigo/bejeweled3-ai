namespace Bejeweled3AI.UI
{
    public partial class Form1
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
            this.pcGrid = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pcOutput = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLoadTemplates = new System.Windows.Forms.Button();
            this.MainTimer = new System.Windows.Forms.Timer(this.components);
            this.lbTemplates = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbModes = new System.Windows.Forms.ComboBox();
            this.btnToggleOverlay = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pcGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // pcGrid
            // 
            this.pcGrid.Location = new System.Drawing.Point(15, 25);
            this.pcGrid.Name = "pcGrid";
            this.pcGrid.Size = new System.Drawing.Size(512, 512);
            this.pcGrid.TabIndex = 0;
            this.pcGrid.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Grid";
            // 
            // pcOutput
            // 
            this.pcOutput.Location = new System.Drawing.Point(533, 25);
            this.pcOutput.Name = "pcOutput";
            this.pcOutput.Size = new System.Drawing.Size(512, 512);
            this.pcOutput.TabIndex = 3;
            this.pcOutput.TabStop = false;
            this.pcOutput.Click += new System.EventHandler(this.pcOutput_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output";
            // 
            // btnLoadTemplates
            // 
            this.btnLoadTemplates.Location = new System.Drawing.Point(1051, 296);
            this.btnLoadTemplates.Name = "btnLoadTemplates";
            this.btnLoadTemplates.Size = new System.Drawing.Size(107, 23);
            this.btnLoadTemplates.TabIndex = 5;
            this.btnLoadTemplates.Text = "Carregar Templates";
            this.btnLoadTemplates.UseVisualStyleBackColor = true;
            this.btnLoadTemplates.Click += new System.EventHandler(this.LoadTemplates);
            // 
            // MainTimer
            // 
            this.MainTimer.Enabled = true;
            this.MainTimer.Interval = 20;
            this.MainTimer.Tick += new System.EventHandler(this.Tick);
            // 
            // lbTemplates
            // 
            this.lbTemplates.FormattingEnabled = true;
            this.lbTemplates.Location = new System.Drawing.Point(1049, 65);
            this.lbTemplates.Name = "lbTemplates";
            this.lbTemplates.Size = new System.Drawing.Size(107, 225);
            this.lbTemplates.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1051, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Templates";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1051, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Mode";
            // 
            // cbModes
            // 
            this.cbModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbModes.FormattingEnabled = true;
            this.cbModes.Location = new System.Drawing.Point(1049, 25);
            this.cbModes.Name = "cbModes";
            this.cbModes.Size = new System.Drawing.Size(107, 21);
            this.cbModes.TabIndex = 9;
            // 
            // btnToggleOverlay
            // 
            this.btnToggleOverlay.Location = new System.Drawing.Point(1054, 325);
            this.btnToggleOverlay.Name = "btnToggleOverlay";
            this.btnToggleOverlay.Size = new System.Drawing.Size(102, 23);
            this.btnToggleOverlay.TabIndex = 10;
            this.btnToggleOverlay.Text = "Toggle Overlay";
            this.btnToggleOverlay.UseVisualStyleBackColor = true;
            this.btnToggleOverlay.Click += new System.EventHandler(this.ToggleOverlay);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1168, 552);
            this.Controls.Add(this.btnToggleOverlay);
            this.Controls.Add(this.cbModes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbTemplates);
            this.Controls.Add(this.btnLoadTemplates);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pcOutput);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pcGrid);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pcGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcOutput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pcGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pcOutput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLoadTemplates;
        private System.Windows.Forms.Timer MainTimer;
        private System.Windows.Forms.ListBox lbTemplates;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbModes;
        private System.Windows.Forms.Button btnToggleOverlay;
    }
}

