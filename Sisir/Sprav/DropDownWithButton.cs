using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sisir.Sprav
{
    public partial class DropDownWithButton: UserControl
    {
        public Form parentForm;
        public Form childForm;
        
        public DropDownWithButton(Form pForm,int width = 195)
        {
            InitializeComponent();
            this.comboBox1.Width = width;
            parentForm = pForm;
            childForm = pForm;
        }

        public DropDownWithButton()
        {

        }

        private void SetChildClass<T>() where T : Form, ISprav, new()
        {
            this.comboBox1.DataSource = new List<T>();

            button_Click<T>();

        }

        private void DropDownWithButton_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button_Click<WorkersForm>();
        }

        private void button_Click<T>() where T : Form, ISprav, new()
        {
            ISprav f = new T();
            f.parentForm = parentForm;
            (f as Form).Show();
        }
    }
}
