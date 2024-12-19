using Npgsql;
using Sisir.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Sisir.Sprav
{
    public partial class SkillForm : FormWithStripMenu, ISprav
    {
        public Form parentForm { get; set; }

        private NpgsqlDataSource dataSource;
        private DataSet levelDS = new DataSet();


        private List<Control> textFieldList = new List<Control>();

        public int SelectedSkill;

        public WorkerSkill WorkerSkill { get; set; } = null;


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
            PrepareAddForm();

        }

        public void ShowHelperSprav<T>() where T : Form, ISprav, new()
        {
            throw new NotImplementedException();
        }

        private void Skill_Load(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                this.menuStrip.Visible = false;
                this.menuStrip.Enabled = false;
                dataGridView1.CellDoubleClick += dataGridView1_CellDoubleClick;
            }

            var qualDS = Skill.GetDataSet();

            dataGridView1.DataSource = qualDS.Tables[0];
            dataGridView1.Update();

        }

        private void OkButtonForm_Click(object sender, EventArgs e)
        {

            try
            {
                var isAdded = false;
                if (idLabel.Text != "")
                {
                    var id = int.Parse(idLabel.Text);

                    var skill = new Skill(id);
                    skill.Name = nameTextBox.Text;
                    isAdded = skill.Update();
                }
                else
                {
                    var skill = new Skill(nameTextBox.Text);

                    var validRes = skill.Validate();

                    if (validRes.isValid)
                    {
                        skill.Insert();
                        isAdded = true;
                    }
                    else
                    {
                        MessageBox.Show(validRes.Message);
                        isAdded = false;
                    }
                }

                UpdateDataSource();

                if (isAdded)
                {
                    dataGridView1.Visible = true;
                    groupBoxAddForm.Visible = false;
                    AddFormOkay();
                    AddEditDelButtonsEnable();
                }
                else
                {
                    //MessageBox.Show("Произошла ошибка при добавлении навыка в базу данных." +
                    //    "Попробуйте еще раз.");
                }

                UpdateDataSource();

            }
            catch (Exception)
            {
                MessageBox.Show("Имя должно быть не пустым полем.");
            }


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
                var level = new WorkerSkill(SelectedSkill, leveltextBox.Text);
                var response = level.Validate();
                if (response.isValid)
                {
                    WorkerSkill = level;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(response.Message);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Введите уровень в виде целочисленного числа от 0 до 10");
            }



        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            AddEditDelButtonsDisable();
            var level = GetSkill();

            if (level != null)
            {
                ShowAddForm();
                FillData(level);
            }
            else
            {
                MessageBox.Show("Выберите навык в таблице навыков " +
                    " (Кликните один раз по любой ячейке ряда интересующий вас навык).");
            }

        }

        private Skill GetSkill()
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                var row = dataGridView1.SelectedCells[0].RowIndex;
                var column = dataGridView1.Columns["id"].Index;
                var _id = dataGridView1.Rows[row].Cells[column].Value;
                int id;
                if (_id != null && int.TryParse(_id.ToString(), out id))
                {
                    id = int.Parse(_id.ToString());
                    var skill = new Skill(id);
                    return skill;
                }
            }
            return null;
        }

        private void FillData(Skill level)
        {
            nameTextBox.Text = level.Name;
            idLabel.Text = level.Id.ToString();
        }

        private void PrepareAddForm()
        {
            nameTextBox.Text = string.Empty;
            idLabel.Text = string.Empty;
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
            if (parentForm != null)
            {
                var value = CellDoubleClicK(dataGridView1, e);
                if (value != "")
                {
                    SelectedSkill = int.Parse(value.ToString());
                    labelBox.Visible = true;
                }
            }
        }

        public void UpdateDataSource()
        {
            levelDS = Skill.UpdateDataSet();
            var q = levelDS.Tables[0];
            dataGridView1.DataSource = q;
            dataGridView1.Update();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var skill = GetSkill();

            if (skill != null)
            {
                skill.Delete();
            }
            else
            {
                MessageBox.Show("Выберите навык в таблице уровней " +
                    " (Кликните один раз по любой ячейке ряда интересующего вас навыка).");
            }

            UpdateDataSource();

        }

        private void levelCancel_Click(object sender, EventArgs e)
        {
            labelBox.Visible = false;
        }

        private void CancelButoonForm_Click(object sender, EventArgs e)
        {
            groupBoxAddForm.Visible = false;
            AddEditDelButtonsEnable();
            dataGridView1.Visible = true;
            groupBoxAddForm.Visible = false;

        }
    }


}
