using Sisir.Sprav;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using System.Diagnostics;

namespace Sisir
{
    public partial class WorkersForm : FormWithStripMenu, ISprav
    {
        public Form parentForm { get; set; }
        public BindingList<itemSkill> skillList  = new BindingList<itemSkill>();
        public BindingList<Worker> workerList  = new BindingList<Worker>();
        public Worker worker = null;
        private NpgsqlDataSource dataSource;
        private DataSet workersDS = new DataSet();


        public class itemSkill
        {
            public string name { get; set; }
            public int level { get; set; }

            public itemSkill(string name, int level)
            {
                this.name = name;
                this.level = level;
            }
        }

        public WorkersForm()
        {
            InitializeComponent();
        }

        public WorkersForm(Form parentForm)
        {
            this.parentForm = parentForm;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var conn = ConnectToDb();

            var adapter = new NpgsqlDataAdapter("Select * From worker", conn);

            adapter.Fill(workersDS);

            //var reader = dataSource.CreateCommand("Select * From 'worker'").ExecuteReader();

            //workersDS.Load(reader, LoadOption.Upsert, "worker");

            dataGridView1.Columns[0].DataPropertyName = "name";
            dataGridView1.Columns[1].DataPropertyName = "level";
            this.dataGridView1.DataSource = dataSource;

            //dataGridViewWorkers.Columns[0].DataPropertyName = "name";
            //dataGridViewWorkers.Columns[1].DataPropertyName = "surname";
            //dataGridViewWorkers.Columns[2].DataPropertyName = "patronym";
            //dataGridViewWorkers.AutoGenerateColumns = true;

            //dataGridViewWorkers.DataSource = workerList;

            dataGridViewWorkers.DataSource = workersDS.Tables[0];
            Adjust_Columns();
            //dataGridViewWorkers.Update();
        }

        private void FillTable() { }

        private void Adjust_Columns()
        {
            dataGridViewWorkers.Columns["name"].DisplayIndex = 0;
            dataGridViewWorkers.Columns["surname"].DisplayIndex = 1;
            dataGridViewWorkers.Columns["patronym"].DisplayIndex = 2;
            dataGridViewWorkers.Columns["job_position"].DisplayIndex = 3;
            dataGridViewWorkers.Columns["qual_level"].DisplayIndex = 4;
            dataGridViewWorkers.Columns["birth_date"].DisplayIndex = 5;
            dataGridViewWorkers.Columns["pass_serie"].DisplayIndex = 6;
            dataGridViewWorkers.Columns["pass_num"].DisplayIndex = 7;
            dataGridViewWorkers.Columns["pass_date"].DisplayIndex = 8;
            dataGridViewWorkers.Columns["pass_who"].DisplayIndex = 8;
            dataGridViewWorkers.Columns["adress_pass"].DisplayIndex = 9;
            dataGridViewWorkers.Columns["adress_fact"].DisplayIndex = 10;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void OkButtonForm_Click(object sender, EventArgs e)
        {
            AddFormOkay();
            AddEditDelButtonsEnable();

        }

        private void CancelButoonForm_Click(object sender, EventArgs e)
        {
            AddFormCancel();
            AddEditDelButtonsEnable();
        }

        public void AddEditDelButtonsEnable()
        {
            AddButton.Enabled = true;
            EditButton.Enabled = true;
            DeleteButton.Enabled = true;
        }

        public void AddEditDelButtonsDisable()
        {
            AddButton.Enabled = false;
            EditButton.Enabled = false;
            DeleteButton.Enabled = false;
        }

        public void ShowAddForm()
        {
            dataGridViewWorkers.Visible = false;
            groupBoxAddForm.Visible = true;
        }

        public void AddFormOkay()
        {
            dataGridViewWorkers.Visible = true;
            groupBoxAddForm.Visible = false;

            var wk = new Worker(textBox2.Text, textBox1.Text, textBox3.Text, comboBox3.Text);
            workerList.Add(wk);
            dataGridViewWorkers.Update();
        }

        public void AddFormCancel()
        {
            dataGridViewWorkers.Visible = true;
            groupBoxAddForm.Visible = false;
        }

        private void уровниКвалификацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }


        private void должностиToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            //JobPosotionForm f = new JobPosotionForm();
            //f.Show();
        }

        private void уровеньКвалификацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        private void JobTitleButtonEtc_Click(object sender, EventArgs e)
        {
            var f = OpenSprav<JobPosotionForm>(true);
            var a = f.click;
            comboBox3.Text = a;
        }

        private void QualButtonEtc_Click(object sender, EventArgs e)
        {
            var f = OpenSprav<QualificationForm>(true);
            var a = f.click;
            comboBox1.Text = a;
            
        }

        public void ShowHelperSprav<T>() where T : Form, ISprav, new()
        {
            T f = new T();
            f.parentForm = this;
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var f = OpenSprav<SkillForm>(true);
            var skill = f.skill;
            var level = f.level;
            var item = new itemSkill(skill, level);
            skillList.Add(item);
            dataGridView1.Update();

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ShowAddForm();
            AddEditDelButtonsDisable();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {

        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void WorkersForm_ParentChanged(object sender, EventArgs e)
        {

        }

        private void WorkersForm_Activated(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                this.menuStrip.Visible = false;
                this.menuStrip.Enabled = false;
                //dataGridViewWorkers.CellDoubleClick += DataGridViewWorkers_CellDoubleClick;
            }

        }
    }



}
