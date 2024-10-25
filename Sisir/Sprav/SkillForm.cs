using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;

namespace Sisir.Sprav
{
    public partial class SkillForm : FormWithStripMenu, ISprav
    {
        public Form parentForm { get; set; }
        public int level { get; set; }    
        public string skill { get; set; }

        public itemSkill skillSkill { get; set; }
        public BindingList<itemSkill> items = new BindingList<itemSkill>();

        public SkillForm()
        {
            InitializeComponent();
        }
        public SkillForm(Form parent)
        {
            InitializeComponent();
            this.parentForm = parent;
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
            dataGridView1.Visible = true;
            groupBoxAddForm.Visible = false;
        }

        public void AddFormOkay()
        {
            dataGridView1.Visible = true;
            groupBoxAddForm.Visible = false;
        }

        public void ShowAddForm()
        {
            dataGridView1.Visible = false;
            groupBoxAddForm.Visible = true;
        }

        public void ShowHelperSprav<T>() where T : Form, ISprav, new()
        {
            throw new NotImplementedException();
        }

        private void Skill_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].DataPropertyName = "Name";
            dataGridView1.DataSource = items;
            dataGridView1.Update();

        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var a = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            if (a != null)
            {
                levelLabel.Text += a.ToString();
                skill = a.ToString();
            }
            labelBox.Visible = true;

        }

        private void OkButtonForm_Click(object sender, EventArgs e)
        {

            items.Add(new itemSkill(textBox20.Text));
            dataGridView1.Update();

            AddFormOkay();
            AddEditDelButtonsEnable();


        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ShowAddForm();
            AddEditDelButtonsDisable();

        }

        private void levelOkButton_Click(object sender, EventArgs e)
        {
            try
            {
                this.level = int.Parse(leveltextBox.Text);
                this.skill = levelLabel.Text.Substring(7);
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Введите уровень в виде целочисленного числа от 0 до 10");
            }



        }

        private void EditButton_Click(object sender, EventArgs e)
        {

        }

        private void SkillForm_ParentChanged(object sender, EventArgs e)
        {
            this.menuStrip.Visible = false;
        }

        private void SkillForm_Activated(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                this.menuStrip.Visible = false;
                this.menuStrip.Enabled = false;
                dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            }


        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }


}
