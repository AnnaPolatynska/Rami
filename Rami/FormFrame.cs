using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Rami
{
    /// <summary>
    /// okno informacji o zapisie pliku.
    /// </summary>
    public partial class Frame : Form
    {
        private string _s;
        /// <summary>
        /// konstruktor
        /// </summary>
        /// <param name="s">Treść w oknie.</param>
        
            public Frame(string s)
        {
            InitializeComponent();
            _s = s;
        }// Frame

        private void Frame_Paint(object sender, PaintEventArgs e)
        {
            FontFamily fontFam = new FontFamily("Microsoft Sans Serif");
            Brush brush = new SolidBrush(Color.DarkGreen);
            Font font = new Font(fontFam, 20, FontStyle.Bold, GraphicsUnit.Pixel);
            Size size = TextRenderer.MeasureText(_s, font);
            e.Graphics.DrawString(_s, font, brush, new PointF((float)((e.ClipRectangle.Width - size.Width)/2), (float)(e.ClipRectangle.Height - size.Height)/2));
        }//Frame_Paint

        //private void Frame_Load(object sender, EventArgs e)
        //{

        //}// private void frame_Load
    }// public partial class Frame : Form
}// Rami
