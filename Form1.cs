using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tesselation
{
    public partial class Form1 : Form
    {
        Graphics Canvas;
        Pen pen;
        Polygone datapoints;
        Triangle tri;

        public Form1()
        {
            InitializeComponent();
            Canvas = this.CreateGraphics();
            pen = new Pen(Color.Black);
            datapoints = new Polygone();
        }
        
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Point dest = new Point(e.X, e.Y);

                if (!datapoints.Zero())
                {
                    Point src = datapoints.Last();
                    Canvas.DrawLine(pen, src, dest);
                }
                datapoints.AddPoint(dest);
            }
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (!datapoints.Zero())
            {
                Canvas.DrawLines(pen, datapoints.GetPoints());
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void earTrimmingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TesselationAlgo algo = new TesselationAlgo(datapoints.GetList());
            algo.EarTrimming(Canvas);
            algo.DrawTriangles(Canvas);
        }

        private void closePoligoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datapoints.Close();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datapoints.Clear();
            Canvas.Clear(this.BackColor);
        }

    }
}
