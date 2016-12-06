using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//CefSharp references
using CefSharp;
using CefSharp.WinForms;


namespace Downloader
{
    public partial class HtmlForm : Form
    {
        public HtmlForm(FormLogic.Logic logic)
        {
            logic.form = this;

            InitializeComponent();
        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
