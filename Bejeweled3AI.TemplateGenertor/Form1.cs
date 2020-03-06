using Bejeweled3AI.Common;
using Bejeweled3AI.Common.Template;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Bejeweled3AI.TemplateGenertor
{
    public partial class Form1 : Form
    {
        private const int MaxGenerationCount = 200;
        private static readonly Pen SelectionPen = new Pen(Color.Red, 2);
        private static readonly Brush SelectionBrush = new SolidBrush(Color.FromArgb(128, Color.Red));

        private readonly ApplicationTracker tracker;
        private GameMode CurrentGameMode
        {
            get
            {
                var selectedIndex = this.cbModes.SelectedIndex;
                if (selectedIndex >= 0)
                    return (GameMode)this.cbModes.Items[selectedIndex];
                else
                    throw new Exception();
            }
        }

        private BlockType CurrentBlockType
        {
            get
            {
                var selectedIndex = this.cbBlockType.SelectedIndex;
                if (selectedIndex >= 0)
                    return (BlockType)this.cbBlockType.Items[selectedIndex];
                else
                    throw new Exception();
            }
        }

        private int CurrentColuna
        {
            get => this.cbColuna.SelectedIndex;
            set => this.cbColuna.SelectedIndex = value;
        }

        private int CurrentLinha
        {
            get => this.cbLinha.SelectedIndex;
            set => this.cbLinha.SelectedIndex = value;
        }

        private bool generating;
        private bool Generating
        {
            get => this.generating;
            set
            {
                this.generating = value;
               // this.progressBar1.Visible = value;
                this.btnGenerate.Enabled = !value;
                this.cbModes.Enabled = !value;
                this.cbColuna.Enabled = !value;
                this.cbLinha.Enabled = !value;
                this.cbBlockType.Enabled = !value;
                this.btnClearTemplates.Enabled = !value;
                this.btnSave.Enabled = !value;
                this.btnStop.Enabled = value;
            }
        }

        private int recordCount;

        private Dictionary<BlockType, BlockTemplate> templates;

        public Form1()
        {
            this.InitializeComponent();
            this.tracker = new ApplicationTracker();
            this.tracker.Init();

            this.progressBar1.Maximum = MaxGenerationCount;

            foreach (GameMode mode in Enum.GetValues(typeof(GameMode)))
                this.cbModes.Items.Add(mode);
            this.cbModes.SelectedIndex = 0;

            foreach (BlockType blockType in Enum.GetValues(typeof(BlockType)))
                if (blockType != BlockType.Desconhecido)
                    this.cbBlockType.Items.Add(blockType);

            this.cbBlockType.SelectedIndex = 0;

            for (var i = 0; i < Const.TotalColunas; i++)
                this.cbColuna.Items.Add(i);
            this.cbColuna.SelectedIndex = 0;

            for (var i = 0; i < Const.TotalLinhas; i++)
                this.cbLinha.Items.Add(i);
            this.cbLinha.SelectedIndex = 0;

            this.templates = new Dictionary<BlockType, BlockTemplate>();
        }

        private void SyncScreen(object sender, EventArgs e)
        {
            using (var screenshot = this.tracker.GetScreenshot())
            {
                this.pbScreen.Image = DrawSelection(GridUtil.GetGridFromScreeshot(screenshot, this.CurrentGameMode));
                this.pbSelected.Image = GridUtil.GetBlockFromScreenshot(screenshot, this.CurrentGameMode, this.CurrentColuna, this.CurrentLinha);

                var cropTemplate = GridUtil.GetTemplateCropFromBlock((Bitmap)this.pbSelected.Image);
                var cropTemplateDebug = new Bitmap(64, 64);
                var color = ColorUtil.AvgColor(cropTemplate);
                this.lblAvgColor.Text = "#" + color.Name;

                using (var g = Graphics.FromImage(cropTemplateDebug))
                {
                    g.FillRectangle(new SolidBrush(color), 0, 0, cropTemplateDebug.Width, cropTemplateDebug.Height);
                    g.DrawImage(cropTemplate, (cropTemplateDebug.Width / 2) - cropTemplate.Width / 2, (cropTemplateDebug.Height / 2) - cropTemplate.Height / 2);

                    //g.DrawRectangle(new Pen(Color.Black, 1), 0, 0, cropTemplateDebug.Width - 1, cropTemplateDebug.Height - 1);
                    //g.DrawLine(new Pen(Color.Black), cropTemplateDebug.Width / 2, 0, cropTemplateDebug.Width / 2, cropTemplateDebug.Height);
                    //g.DrawLine(new Pen(Color.Black), 0, cropTemplateDebug.Height/2, cropTemplateDebug.Width, cropTemplateDebug.Height/2);
                }

                this.pbCropTemplate.Image = cropTemplateDebug;
            }

            this.TickGeneration();
        }

        private void pbScreen_Click(object sender, EventArgs e)
        {
            if (this.Generating)
                return;

            var mouseEvent = (MouseEventArgs)e;

            this.CurrentColuna = (int)Math.Floor((decimal)mouseEvent.X / Const.BlockWidth);
            this.CurrentLinha = (int)Math.Floor((decimal)mouseEvent.Y / Const.BlockHeight);
        }

        private Bitmap DrawSelection(Bitmap grid)
        {
            using (var g = Graphics.FromImage(grid))
            {
                var rec = new Rectangle(Const.BlockWidth * this.CurrentColuna, Const.BlockHeight * this.CurrentLinha, Const.BlockWidth, Const.BlockHeight);
                g.DrawRectangle(SelectionPen, rec);
                g.FillRectangle(SelectionBrush, rec);
            }

            return grid;
        }

        private void GenerateTemplate(object sender, EventArgs e)
        {
            this.recordCount = 0;
            this.Generating = true;
            this.progressBar1.Value = 0;
            this.tracker.SetActive();
        }

        private void TickGeneration()
        {
            if (!this.Generating)
                return;

            //this.recordCount++;

            var blockType = this.CurrentBlockType;

            if (!this.templates.ContainsKey(blockType))
                this.templates.Add(blockType, new BlockTemplate(blockType));

            var templateCrop = GridUtil.GetTemplateCropFromBlock((Bitmap)this.pbSelected.Image);
            var color = ColorUtil.AvgColor(templateCrop);

            if (this.templates[blockType].AdicionarCor(color))
            {
                this.lbTemplate.Items.Add($"{blockType}: {color}");
                this.label5.Text = $"Template ({this.lbTemplate.Items.Count})";
            }

            //if (this.recordCount > MaxGenerationCount)
            //{
            //    this.Generating = false;
            //    var p = Process.GetCurrentProcess();
            //    ApplicationTracker.SetWindowActive(p.Handle, p.MainWindowHandle);
            //}
            //else
            //    this.progressBar1.Value = this.recordCount;
        }

        private void ClearTemplates(object sender, EventArgs e)
        {
            this.templates = new Dictionary<BlockType, BlockTemplate>();
            this.lbTemplate.Items.Clear();
            this.label5.Text = $"Template";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var dialog = new FolderBrowserDialog())
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var template in this.templates.Values)
                    {
                        var file = Path.Combine(dialog.SelectedPath, $"{template.BlockType}.json");
                        if (File.Exists(file))
                        {
                            var savedTemplate = JsonConvert.DeserializeObject<BlockTemplate>(File.ReadAllText(file));
                            if (savedTemplate.BlockType == template.BlockType)
                                foreach (var color in savedTemplate.Colors)
                                    template.AdicionarCor(color);
                        }

                        var json = JsonConvert.SerializeObject(template, Formatting.Indented);
                        File.WriteAllText(file, json);
                    }
                }
        }

        private void StopGeneration(object sender, EventArgs e)
        {
            this.Generating = false;
            var p = Process.GetCurrentProcess();
            ApplicationTracker.SetWindowActive(p.Handle, p.MainWindowHandle);
        }
    }
}