using Npgsql;
using Sisir.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Sisir
{
    public partial class QualificationForm : FormWithStripMenu, ISprav
    {
        public Form parentForm { get; set; }

        private NpgsqlDataSource dataSource;
        private DataSet levelDS = new DataSet();


        private List<Control> textFieldList = new List<Control>();

        public string SelectedLevel;

        public QualificationForm(Form parent)
        {
            this.parentForm = parent;
            InitializeComponent();
        }

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
            PrepareAddForm();
        }

        private void Qualification_Load(object sender, EventArgs e)
        {
            if (parentForm != null)
            {
                this.menuStrip.Visible = false;
                this.menuStrip.Enabled = false;
                dataGridViewWorkers.CellDoubleClick += dataGridViewWorkers_CellDoubleClick;
            }

            var qualDS = QualLevel.GetDataSet();

            dataGridViewWorkers.DataSource = qualDS.Tables[0];
            dataGridViewWorkers.Update();

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            ShowAddForm();
            AddEditDelButtonsDisable();

        }

        private void OkButtonForm_Click(object sender, EventArgs e)
        {
            try
            {
                var isAdded = false;
                if (idLabel.Text != "")
                {
                    var id = int.Parse(idLabel.Text);

                    var level = new QualLevel(id);
                    level.Name = nameTextBox.Text;
                    level.Coeff = salaryNumericUpDown.Value;
                    isAdded = level.Update();
                }
                else
                {
                    var level = new QualLevel(nameTextBox.Text, salaryNumericUpDown.Value);

                    var validRes = level.Validate();

                    if (validRes.isValid)
                    {
                        level.Insert();
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
                    dataGridViewWorkers.Visible = true;
                    groupBoxAddForm.Visible = false;
                    AddFormOkay();
                    AddEditDelButtonsEnable();
                }
                else
                {
                    //MessageBox.Show("Произошла ошибка при добавлении уровня в базу данных." +
                    //    "Попробуйте еще раз.");
                }

                UpdateDataSource();

            }
            catch (Exception)
            {
                MessageBox.Show("Коэффициент должна быть указана в виде целого числа");
            }

        }

        private void CancelButoonForm_Click(object sender, EventArgs e)
        {
            AddFormCancel();
        }

        public void ShowHelperSprav<T>() where T : Form, ISprav, new()
        {
            throw new NotImplementedException();
        }

        private void QualificationForm_ParentChanged(object sender, EventArgs e)
        {
            this.menuStrip.Visible = false;
        }

        private void dataGridViewWorkers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (parentForm != null)
            {
                var value = CellDoubleClicK(dataGridViewWorkers, e);
                if (value != "")
                {
                    SelectedLevel = value.ToString();
                    this.Close();
                }
            }


        }

        private void QualificationForm_Activated(object sender, EventArgs e)
        {


            if (parentForm != null)
            {
                this.menuStrip.Visible = false;
                this.menuStrip.Enabled = false;
                dataGridViewWorkers.CellDoubleClick += dataGridViewWorkers_CellDoubleClick;
            }

        }

        public void UpdateDataSource()
        {
            levelDS = QualLevel.UpdateDataSet();
            var q = levelDS.Tables[0];
            dataGridViewWorkers.DataSource = q;
            dataGridViewWorkers.Update();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            var level = GetLevel();

            if (level != null)
            {
                ShowAddForm();
                FillData(level);
            }
            else
            {
                MessageBox.Show("Выберите уровень квалификации в таблице уровней " +
                    " (Кликните один раз по любой ячейке ряда интересующего вас уровня).");
            }

        }


        private QualLevel GetLevel()
        {
            if (dataGridViewWorkers.SelectedCells.Count > 0)
            {
                var row = dataGridViewWorkers.SelectedCells[0].RowIndex;
                var column = dataGridViewWorkers.Columns["id"].Index;
                var _id = dataGridViewWorkers.Rows[row].Cells[column].Value;
                int id;
                if (_id != null && int.TryParse(_id.ToString(), out id))
                {
                    id = int.Parse(_id.ToString());
                    var level = new QualLevel(id);
                    return level;
                }
            }
            return null;
        }


        private void FillData(QualLevel level)
        {
            nameTextBox.Text = level.Name;
            salaryNumericUpDown.Value = (decimal)level.Coeff;
            idLabel.Text = level.Id.ToString();
        }

        private void PrepareAddForm()
        {
            nameTextBox.Text = string.Empty;
            salaryNumericUpDown.Value = 1;
            idLabel.Text = string.Empty;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            var level = GetLevel();

            if (level != null)
            {
                level.Delete();
            }
            else
            {
                MessageBox.Show("Выберите уровень квалификации в таблице уровней " +
                    " (Кликните один раз по любой ячейке ряда интересующего вас уровня).");
            }

            UpdateDataSource();

        }

        private void dataGridViewWorkers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectRow(dataGridViewWorkers, e);
        }
    }
}
