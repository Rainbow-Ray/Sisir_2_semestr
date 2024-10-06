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
    public partial class JobPosotionForm : FormWithStripMenu, ISprav
    {
        public Form parentForm { get; set; }

        public JobPosotionForm(Form parent)
        {
            this.parentForm = parent;
            InitializeComponent();
        }

        public JobPosotionForm()
        {
            InitializeComponent();
        }

        public void AddEditDelButtonsDisable()
        {
            AddButton.Enabled = false;
            EditButton.Enabled = false;
            DeleteButton.Enabled = false;

        }

        public void AddEditDelButtonsEnable()
        {
            AddButton.Enabled = true;
            EditButton.Enabled = true;
            DeleteButton.Enabled = true;
        }

        public void AddFormCancel()
        {
            dataGridViewWorkers.Visible = true;
            groupBoxAddForm.Visible = false;
            AddEditDelButtonsEnable();

        }

        public void AddFormOkay()
        {
            dataGridViewWorkers.Visible = true;
            groupBoxAddForm.Visible = false;
        }

        public void ShowAddForm()
        {
            dataGridViewWorkers.Visible = false;
            groupBoxAddForm.Visible = true;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ShowAddForm();
            AddEditDelButtonsDisable();
        }

        private void OkButtonForm_Click(object sender, EventArgs e)
        {
            AddFormOkay();
            AddEditDelButtonsEnable();

        }

        private void CancelButoonForm_Click(object sender, EventArgs e)
        {
            AddFormCancel();
        }
        private void JobPosotionForm_Load(object sender, EventArgs e)
        {

        }

        private void OkButtonForm_Click_1(object sender, EventArgs e)
        {
            AddFormOkay();
            AddEditDelButtonsEnable();
        }

        private void CancelButoonForm_Click_1(object sender, EventArgs e)
        {
            AddFormCancel();
            AddEditDelButtonsEnable();
        }

        private void AddButton_Click_1(object sender, EventArgs e)
        {
            ShowAddForm();
            AddEditDelButtonsDisable();
        }

        private void должностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            JobPosotionForm f = new JobPosotionForm();
            f.Show();

        }

        private void сотрудникиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WorkersForm f = new WorkersForm();
            f.Show();


        }
    }
}
