using DocumentFormat.OpenXml.Office2010.Excel;
using Sisir.Entity;
using Sisir.Templates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TemplateEngine.Docx;

namespace Sisir.Summary
{
    public partial class SummaryProjects : Summary
    {
        private string dateStart;
        private string dateEnd;

        DatabaseAdapter databaseAdapter = new DatabaseAdapter();


        public SummaryProjects()
        {
            InitializeComponent();
        }

        private void SummaryProjects_Load(object sender, EventArgs e)
        {
            var ds = Worker.GetFio().Tables[0];
            WorkerComboBox.ValueMember = "id";
            WorkerComboBox.DisplayMember = "FIO";
            WorkerComboBox.DataSource = ds;

        }
        internal class WorkL
        {
            internal int id;
            internal string fio;
            internal string job;
            internal int prCount =0;
            internal int prBad =0;
            internal decimal percent;
            public WorkL()
            {

            }
        }

        internal class ProjectL
        {
            internal int id;
            internal string name;
            internal DateTime sP;
            internal string sF;
            internal string fP;
            internal string fF;
            internal string durP;
            internal string durF;
            internal string badDay;
            internal string badWeek;
            public ProjectL() { }
        }

        private void PrepareData(List<Dictionary<string, string>> list)
        {
            var dateS = new FieldContent("Date_summary_start", StartDateTimePicker.Value.Date.ToShortDateString());
            var dateF = new FieldContent("Date_summary_finish", EndDateTimePicker.Value.Date.ToShortDateString());
            var tableW = new TableContent("Team");
            var tableP = new TableContent("Project");
            var kol = list.Count;
            var count = (int)(list.Count) / 10;

            var wrList = new Dictionary<int, WorkL>();
            var prList = new Dictionary<int, ProjectL>();
            var countW = 0;
            var countP = 0;

            foreach (var row in list)
            {
                var dsP = DateTime.Parse(row["date_start_p"].ToString());
                var dfP = DateTime.Parse(row["date_finish_p"].ToString());
                var date_now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                var dsF = row["date_start_f"].ToString() == "" ? date_now : DateTime.Parse(row["date_start_f"].ToString());
                var dfF = row["date_finish_f"].ToString() =="" ? date_now : DateTime.Parse(row["date_finish_f"].ToString());
                var planDur = (dfP - dsP);
                var factDur = (dfF - dsF);
                var isBad = dfF > dfP;
                var wId = int.Parse(row["worker"].ToString());

                    if (wrList.ContainsKey(wId))
                    {
                        wrList[wId].prCount += 1;
                    
                        if (isBad)
                        {

                            wrList[wId].prBad += 1;

                        }
                    }
                    else
                    {
                        var wk = new WorkL();
                        wk.fio = row["fio"].ToString();
                        wk.job = row["job"].ToString();
                        wk.prCount += 1;
                        if (isBad)
                        {

                            wk.prBad += 1;

                        }

                    wrList.Add(wId, wk);
                    }
                if (isBad)
                {
                    tableP.AddRow(
new FieldContent("Project_name", row["project"].ToString()),
new FieldContent("Date_start_p", dsP.ToShortDateString()),
new FieldContent("Date_finish_p", dfP.ToShortDateString()),
new FieldContent("Date_start_f", dsF.ToShortDateString()),
new FieldContent("Date_finish_f", dfF.ToShortDateString()),
new FieldContent("Duration_p", ((int)Math.Abs(planDur.TotalDays)).ToString()),
new FieldContent("Duration_f", ((int)Math.Abs(factDur.TotalDays)).ToString()),
new FieldContent("Fail_days", ((int)Math.Abs((factDur - planDur).TotalDays)).ToString())
);

                }
            }

            foreach (var id in wrList)
            {
                decimal percents = (decimal)id.Value.prBad / (decimal)id.Value.prCount * 100;
                tableW.AddRow(
  new FieldContent("FIO", id.Value.fio),
  new FieldContent("Job_pos", id.Value.job),
  new FieldContent("project_lead", id.Value.prCount.ToString()),
  new FieldContent("project_fail", id.Value.prBad.ToString()),
  new FieldContent("fail_perc", percents.ToString() + "%"))
  ;
            }
            var fail = new FieldContent("Fail_pr", "0");

            if (tableP.Rows != null)
            {
                fail = new FieldContent("Fail_pr", tableP.Rows.Count.ToString());
            }

            var dateForm = new FieldContent("Date_form", DateTime.Now.Date.ToShortDateString());
            var worker = new Worker(int.Parse(WorkerComboBox.SelectedValue.ToString()));
            var pos = new JobPos(worker.Job);
            var posF = new FieldContent("Job_form", pos.Name);

            var w = new FieldContent("FIO_form", WorkerComboBox.Text.ToString());

            var valuesToFill = new Content(dateS, dateF, tableW, tableP, dateForm, w, posF, fail);

            var filePath = "C:\\Users\\Вика\\Documents\\" + FileName() + ".docx";

            this.Fill(templates.Projects, valuesToFill, filePath);
        }
        private bool Validate()
        {
            var isValid = true;
            if (StartDateTimePicker.Value > EndDateTimePicker.Value)
            {
                MessageBox.Show("Конец периода формирования отчета должен быть раньше начала.");
                isValid = false;
            }
            if (WorkerComboBox.SelectedValue.ToString() == "")
            {
                MessageBox.Show("Выберите сотрудника, сформировавшего отчет.");
                isValid = false;
            }
            //if (summaryNameTextBox.Text == "")
            //{
            //    MessageBox.Show("Введите название отчета.");
            //    isValid = false;

            //}
            return isValid;
        }
        private List<Dictionary<string, string>> GetData(string start, string end)
        {
            string command = $"Select  worker.name || ' ' || worker.surname || ' ' || worker.patronym as fio, " +
                $"\r\njob_position.name as job, " +
                $" project.name as project, " +
                $" worker.id as worker, " +
                $" date_start_p, date_finish_p, date_start_f, date_finish_f " +
                $"\r\n\r\nfrom project_worker " +
                $"\r\ninner join project on project.id = project_worker.project_id  " +
                $"\r\ninner join worker on project_worker.worker_id = worker.id " +
                $"\r\ninner join job_position on job_position.id = worker.job_position " +
                $"\r\n\r\nwhere \r\n(((to_date(date_start_f, 'YYYY-MM-DD') >= '{start}' or  date_start_p >= '{start}') " +
                $"\r\nand ((to_date(date_finish_f, 'YYYY-MM-DD') <= '{end}' and to_date(date_finish_f, 'YYYY-MM-DD') >= '{end}') " +
                $"\r\nor  date_finish_p <= '{end}')) and is_fired=false and is_lead=true) " +
                $"\r\ngroup by worker_id, project_worker.id, project.id, worker.id, job_position.id"
                ;
            return databaseAdapter.ExecuteCommand(command);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (Validate())
            {
                var start = FormatDateForDB(StartDateTimePicker.Value);
                var end = FormatDateForDB(EndDateTimePicker.Value);
                var list = GetData(start, end);
                PrepareData(list);
            }

        }
    }
}
