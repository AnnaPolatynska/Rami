using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;

namespace Rami
{
    public partial class FormAbout : Form
    {
        public FormAbout(string plikLogo)
        {
            InitializeComponent();
            if (File.Exists(plikLogo))
            {
                pictureBoxLogo.Image = Image.FromFile(plikLogo);
            }
        }//FormAbout

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }//buttonOK_Click

    }//class FormAbout : Form

}//namespace Rami
