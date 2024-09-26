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
    public partial class QualificationForm : Form, ISprav
    {
        public QualificationForm()
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

        private void Qualification_Load(object sender, EventArgs e)
        {

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
    }
}
