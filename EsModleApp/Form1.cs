using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using System.Reflection.Emit;

namespace SolidWorksAddin
{
    public partial class TestForm : Form
    {
        private SldWorks _swApp;

        public TestForm(SldWorks swApp)
        {
            InitializeComponent();
            _swApp = swApp;
        }

        private void TestForm_Load(object sender, EventArgs e)
        {
            label1.Text = "这是插件窗体！";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("点击");
        }
    }
}
