using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sisir
{
    public partial class WorkersForm : Form
    {
        public WorkersForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void EditButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            dataGridViewWorkers.Visible = false;
            groupBoxAddForm.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form info = new InfoWorkerForm();
            info.ShowDialog();
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void OkButtonForm_Click(object sender, EventArgs e)
        {
            dataGridViewWorkers.Visible = true;
            groupBoxAddForm.Visible = false;

        }

        private void CancelButoonForm_Click(object sender, EventArgs e)
        {
            dataGridViewWorkers.Visible = true;
            groupBoxAddForm.Visible = false;

        }
    }
}
