using Bejeweled3AI.Common;
using Bejeweled3AI.Common.Native;
using Bejeweled3AI.Common.Template;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

using C = Bejeweled3AI.Common.Const;

namespace Bejeweled3AI.UI
{
    public partial class Form1 : Form
    {
        private static readonly Font font = new Font(FontFamily.GenericSansSerif, 10, FontStyle.Regular);
        private static readonly Brush fontBrush = new SolidBrush(Color.Fuchsia);

        private OverlayForm overlayForm;
        private readonly ApplicationTracker tracker;
        private readonly List<BlockTemplate> templates;
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

        private BlockType[,] lastGrid;

        public Form1()
        {
            this.InitializeComponent();
            this.tracker = new ApplicationTracker();
            this.tracker.Init();
            this.templates = new List<BlockTemplate>();

            foreach (GameMode mode in Enum.GetValues(typeof(GameMode)))
                this.cbModes.Items.Add(mode);
            this.cbModes.SelectedIndex = 0;
        }

        private void Tick(object sender, EventArgs e)
        {
            User32.GetCursorPos(out var p);
            this.Text = $"({p.X}, {p.Y})";

            using (var screenshot = this.tracker.GetScreenshot())
            {
                var grid = GridUtil.GetGridFromScreeshot(screenshot, this.CurrentGameMode);
                var blocks = Analizer.AnalizeGridImage(this.templates, grid);
                this.lastGrid = blocks;

                (var output, var overlay) = GenerateOutput(blocks);

                this.pcGrid.Image = grid;
                this.pcOutput.Image = output;

                if (this.overlayForm != null)
                {
                    this.overlayForm.SetImage(overlay);
                    var offset = GridLocator.LocateGrid(this.CurrentGameMode);
                    var rect = this.tracker.GetWindowRect();
                    this.overlayForm.Location = new Point(rect.Left + offset.X, rect.Top + offset.Y);
                }
            }
        }

        private (Bitmap output, Bitmap overlay) GenerateOutput(BlockType[,] grid)
        {
            var output = new Bitmap(C.TotalColunas * C.BlockWidth, C.TotalLinhas * C.BlockHeight);
            var overlay = new Bitmap(C.TotalColunas * C.BlockWidth, C.TotalLinhas * C.BlockHeight, PixelFormat.Format32bppArgb);

            using (var gOutput = Graphics.FromImage(output))
            using (var gOverlay = Graphics.FromImage(overlay))
            {
                gOverlay.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0, 0)), new Rectangle(0, 0, C.GridWidth, C.GridHeight));

                for (var c = 0; c < C.TotalColunas; c++)
                    for (var l = 0; l < C.TotalLinhas; l++)
                    {
                        var x = c * C.BlockHeight;
                        var y = l * C.BlockWidth;

                        if (grid[c, l] != BlockType.Desconhecido)
                        {
                            var color = ColorUtil.FromBlockType(grid[c, l]);
                            gOutput.FillRectangle(new SolidBrush(color), new Rectangle(c * C.BlockWidth, l * C.BlockHeight, C.BlockWidth, C.BlockHeight));
                            //gOverlay.FillRectangle(new SolidBrush(color), new Rectangle(c * C.BlockWidth, l * C.BlockHeight, C.BlockWidth, C.BlockHeight));
                        }
                        else
                        {
                            gOutput.DrawLine(new Pen(Color.Red, 3), x, y, x + C.BlockHeight, y + C.BlockWidth);
                            gOutput.DrawLine(new Pen(Color.Red, 3), x + C.BlockHeight, y, x, y + C.BlockWidth);
                            //gOverlay.DrawLine(new Pen(Color.Red, 3), x, y, x + C.BlockHeight, y + C.BlockWidth);
                            //gOverlay.DrawLine(new Pen(Color.Red, 3), x + C.BlockHeight, y, x, y + C.BlockWidth);
                        }

                        gOutput.DrawRectangle(new Pen(Color.Black), new Rectangle(c * C.BlockWidth, l * C.BlockHeight, C.BlockWidth - 1, C.BlockHeight - 1));
                        //gOverlay.DrawRectangle(new Pen(Color.Black), new Rectangle(c * C.BlockWidth, l * C.BlockHeight, C.BlockWidth - 1, C.BlockHeight - 1));
                        // g.DrawString($"{c:D2}, {l:D2}", font, fontBrush, c * C.BlockWidth, l * C.BlockHeight);

                        if (grid[c, l] != BlockType.Desconhecido)
                        {
                            var dir = Mover.RecomendedMove(grid, c, l);
                            if (dir.HasValue)
                            {

                                var size = C.BlockHeight;
                                var arrowWidth = 4;
                                var arrowCapLength = 10;
                                var arrowHeight = C.BlockHeight / 2;
                                var pen = new Pen(Color.Black, arrowWidth);

                                PointF arrowStart, arrowEnd, cap1End, cap2End;
                                if (dir == Direction.Up)
                                {
                                    arrowStart = new PointF(x + (size / 2) - (arrowWidth / 2), y + (size / 2) - (arrowHeight / 2));
                                    arrowEnd = new PointF(arrowStart.X, arrowStart.Y + arrowHeight);
                                    cap1End = new PointF(arrowStart.X + arrowCapLength, arrowStart.Y + arrowCapLength);
                                    cap2End = new PointF(arrowStart.X - arrowCapLength, arrowStart.Y + arrowCapLength);
                                }
                                else if (dir == Direction.Down)
                                {
                                    arrowEnd = new PointF(x + (size / 2) - (arrowWidth / 2), y + (size / 2) - (arrowHeight / 2));
                                    arrowStart = new PointF(arrowEnd.X, arrowEnd.Y + arrowHeight);
                                    cap1End = new PointF(arrowStart.X - arrowCapLength, arrowStart.Y - arrowCapLength);
                                    cap2End = new PointF(arrowStart.X + arrowCapLength, arrowStart.Y - arrowCapLength);
                                }
                                else if (dir == Direction.Left)
                                {
                                    arrowStart = new PointF(x + (size / 2) - (arrowHeight / 2), y + (size / 2) - (arrowWidth / 2));
                                    arrowEnd = new PointF(arrowStart.X + arrowHeight, arrowStart.Y);
                                    cap1End = new PointF(arrowStart.X + arrowCapLength, arrowStart.Y + arrowCapLength);
                                    cap2End = new PointF(arrowStart.X + arrowCapLength, arrowStart.Y - arrowCapLength);
                                }
                                else if (dir == Direction.Right)
                                {
                                    arrowEnd = new PointF(x + (size / 2) - (arrowHeight / 2), y + (size / 2) - (arrowWidth / 2));
                                    arrowStart = new PointF(arrowEnd.X + arrowHeight, arrowEnd.Y);
                                    cap1End = new PointF(arrowStart.X - arrowCapLength, arrowStart.Y - arrowCapLength);
                                    cap2End = new PointF(arrowStart.X - arrowCapLength, arrowStart.Y + arrowCapLength);
                                }
                                else
                                    throw new Exception();

                                gOutput.DrawLine(pen, arrowStart, arrowEnd);
                                gOutput.DrawLine(pen, arrowStart, cap1End);
                                gOutput.DrawLine(pen, arrowStart, cap2End);

                                gOverlay.DrawLine(pen, arrowStart, arrowEnd);
                                gOverlay.DrawLine(pen, arrowStart, cap1End);
                                gOverlay.DrawLine(pen, arrowStart, cap2End);
                            }
                        }
                    }
            }

            return (output, overlay);
        }

        private void LoadTemplates(object sender, EventArgs e)
        {
            using (var dialog = new OpenFileDialog { Multiselect = true, Filter = "JSON (*.json)|*.json" })
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.templates.Clear();
                    this.lbTemplates.Items.Clear();
                    foreach (var arquivo in dialog.FileNames)
                    {
                        var json = File.ReadAllText(arquivo);
                        this.templates.Add(JsonConvert.DeserializeObject<BlockTemplate>(json));
                        this.lbTemplates.Items.Add(Path.GetFileName(arquivo));
                    }
                }
        }

        private void ToggleOverlay(object sender, EventArgs e)
        {
            if (this.overlayForm == null)
            {
                this.overlayForm = new OverlayForm();
                this.overlayForm.Show();
            }
            else
            {
                this.overlayForm.Close();
                this.overlayForm = null;
            }
        }

        private void pcOutput_Click(object sender, EventArgs e)
        {
            var mouseEvent = (MouseEventArgs)e;

            var coluna = (int)Math.Floor((decimal)mouseEvent.X / C.BlockWidth);
            var linha = (int)Math.Floor((decimal)mouseEvent.Y / C.BlockHeight);
            var window = this.tracker.GetWindowRect();
            var offset = GridLocator.LocateGrid(this.CurrentGameMode);

            var x = (window.X + offset.X + (coluna * C.BlockWidth)) + C.BlockWidth / 2;
            var y = (window.Y + offset.Y + (linha * C.BlockHeight)) + C.BlockHeight / 2;

            Debug.WriteLine($"Click at ({x}, {y})");

            var old = Cursor.Position;
            Cursor.Position = new Point(x, y);

            this.tracker.SetActive();
            User32.MouserEvent((int)User32.MouseEventFlags.LeftDown, (uint)x, (uint)y, 0, 0);
            User32.MouserEvent((int)User32.MouseEventFlags.LeftUp, (uint)x, (uint)y, 0, 0);

            Cursor.Position = old;
            //var p = Process.GetCurrentProcess();
            //ApplicationTracker.SetWindowActive(p.Handle, p.MainWindowHandle);
        }
    }
}