using Sisir.Sprav;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Sisir.Entity
{
    public class Project : IEntity
    {
        private static string table = "project";
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateStartP { get; set; }
        public string DateStartF { get; set; }
        public DateTime DateFinishP { get; set; }
        public string DateFinishF { get; set; }


        private static DatabaseAdapter databaseAdapter = new DatabaseAdapter();

        private static RegexRules regRules = new RegexRules();

        public Project() { }

        private DateTime ParseDate(string column, Dictionary<string, string> projectData, string colName)
        {
            DateTime day = DateTime.Now;
            if (DateTime.TryParse(projectData[column], out day))
            {
                return day;
            }
            else
            {
                MessageBox.Show("Произошла ошибка при вынимании" + colName + "из базы данных.");
                return day;
            }

        }
        private string ParseFactDate(string column, Dictionary<string, string> projectData, string colName)
        {
            DateTime day = DateTime.Now;

            if (projectData[column] == "")
            {
                return "";
            }

            if (DateTime.TryParse(projectData[column], out day))
            {
                return day.ToShortDateString();
            }
            else
            {
                MessageBox.Show("Произошла ошибка при вынимании" + colName + "из базы данных.");
                return "";
            }

        }

        public Project(int id)
        {
            Id = id;
            var selectedProject = Select(id);

            if (selectedProject.Count > 0)
            {
                var projectData = selectedProject[0];
                Name = projectData["name"];
                Description = projectData["description"];
                DateCreated = ParseDate("date_created", projectData, "Даты создания");
                DateStartP = ParseDate("date_start_p", projectData, "Даты начала план");
                DateStartF = ParseFactDate("date_start_f", projectData, "Даты начала факт").ToString();
                DateFinishP = ParseDate("date_finish_p", projectData, "Даты конца план");
                DateFinishF = ParseFactDate("date_finish_f", projectData, "Даты конца факт").ToString();
            }
            else
            {
                MessageBox.Show($"Произошла ошибка при получении данных о проекте с идентификатором {id}");
            }
        }

        public Project(string name, DateTime dateCr, DateTime dateSP, DateTime dateFP,
            string desc = null,
            string dateSF = null, string dateFF = null
            )
        {
            Name = name;
            Description = desc;
            DateCreated = dateCr;
            DateStartP = dateSP;
            DateStartF = "";
            if (dateSF != null)
            {
                DateStartF = dateSF.ToString();
            }
            DateFinishP = dateFP;
            DateFinishF = "";
            if (dateFF != null)
            {
                DateFinishF = dateFF.ToString();
            }

        }
        public Project(int id, string name, DateTime dateCr, DateTime dateSP, DateTime dateFP,
            string desc = null,
            string dateSF = null, string dateFF = null
            )
        {
            Id = id;
            var data = Select(id);
            if (data.Count > 0)
            {
                Name = name;
                Description = desc;
                DateCreated = dateCr;
                DateStartP = dateSP;
                DateStartF = "";
                if (dateSF != null)
                {
                    DateStartF = dateSF.ToString();
                }
                DateFinishP = dateFP;
                DateFinishF = "";
                if (dateFF != null)
                {
                    DateFinishF = dateFF.ToString();
                }
            }
            else
            {
                MessageBox.Show($"Произошла проблема при поиске проекта с данным идентификатором ({id})");
            }
        }

        public static DataSet GetDataSet()
        {
            var projectsDS = databaseAdapter.GetDataSet(
               $"Select * from {table}"
               );

            return projectsDS;
        }



        public ValidationResponse Validate()
        {
            var regRules = new RegexRules();
            var response = new ValidationResponse();

            var def = new DateTime(1000, 01, 01);

            if (string.IsNullOrEmpty(Name))
            {
                response.isValid = false;
                response.Message += "Поле Названия должно быть не пустым.\n";
            }
            if ((DateStartF != "") && (DateFinishF != "") && (DateTime.Parse(DateStartF)) > DateTime.Parse(DateFinishF))
            {
                response.isValid = false;
                response.Message += "Дата завершения факт. должна быть позже даты начала.\n";
            }
            if (DateStartP > DateFinishP)
            {
                response.isValid = false;
                response.Message += "Дата завершения план. должна быть позже даты начала.\n";
            }
            return response;
        }

        private bool isValid(string field, Regex regex)
        {
            return regex.IsMatch(field);
        }

        public static List<Dictionary<string, string>> Select(int id)
        {
            var command = "SELECT * "
                + $" FROM public.{table} WHERE id={id};";

            var projectData = databaseAdapter.ExecuteCommand(command);

            return projectData;
        }
        private enum TableType
        {
            Job,
            Qual
        }

        private string PrepareDate(DateTime data)
        {
            string result = null;
            var d = DateTime.Parse(data.ToString());
            result = d.ToString("yyyy-MM-dd");

            return result;
        }


        public static DataSet UpdateDataSet()
        {
            try
            {
                var ds = GetDataSet();
                databaseAdapter.UpdateDataSet(ds.Tables[0],
                   $"Selcet * from {table}"
                    );
                return ds;
            }
            catch (Npgsql.NpgsqlException)
            {
                MessageBox.Show("Произошла ошибка при наполнении таблицы проекты.");
                return new DataSet();
            }
        }

        public void Insert()
        {
            try
            {
                string dCr = PrepareDate(DateCreated);
                string dSP = PrepareDate(DateStartP);
                string dSF = PrepareDate(DateTime.Parse(DateStartF));
                string dFF = dFF = PrepareDate(DateTime.Parse(DateFinishF));

                string dFP = PrepareDate(DateFinishP);

                var command = $"INSERT INTO public.project(name, description, date_created, " +
                    $"date_start_p, date_finish_p, date_start_f, date_finish_f) " +
                    $" VALUES ({Name}, {Description}, {dCr}, {dSP}, {dFP}, {dSF}, {dFF});";

                databaseAdapter.ExecuteCommandNoReturn(command);

            }
            catch (Npgsql.NpgsqlException)
            {
                MessageBox.Show("Произошла ошибка при добавлении проекта.");
            }

        }
        public ValidationResponse InsertWithReturn()
        {
            try
            {
                string dCr = PrepareDate(DateCreated);
                string dSP = PrepareDate(DateStartP);
                string dSF = "";
                if (DateStartF != "")
                {
                    dSF = PrepareDate(DateTime.Parse(DateStartF));
                }
                var dFF = "";
                if (DateFinishF != "")
                {
                    dFF = PrepareDate(DateTime.Parse(DateFinishF));
                }
                string dFP = PrepareDate(DateFinishP);

                var command = $"INSERT INTO public.project(name, description, date_created, " +
                    $"date_start_p, date_finish_p, date_start_f, date_finish_f) " +
                    $" VALUES ('{Name}', '{Description}', '{dCr}', '{dSP}', '{dFP}', '{dSF}', '{dFF}') " +
                    $"RETURNING project.id;";

                var sdffsfdsfd = 'd';

                var dict = databaseAdapter.ExecuteCommand(command);
                var id = dict[0]["id"];
                var response = new ValidationResponse();
                if (id != null)
                {
                    response.isValid = true;
                    response.Message = id;
                }
                else
                {
                    response.isValid = false;
                    response.Message = "Произошла ошибка при добавлении проекта.";
                }

                return response;

            }
            catch (Npgsql.NpgsqlException)
            {
                var response = new ValidationResponse();
                response.isValid = false;
                response.Message = "Произошла ошибка при добавлении проекта.";
                return response;
            }


        }


        public bool Update()
        {
            string dCr = PrepareDate(DateCreated);
            string dSP = PrepareDate(DateStartP);
            string dFP = PrepareDate(DateFinishP);


            string dSF = "";
            if (DateStartF != "")
            {
                dSF = PrepareDate(DateTime.Parse(DateStartF));
            }
            var dFF = "";
            if (DateFinishF != "")
            {
                dFF = PrepareDate(DateTime.Parse(DateFinishF));
            }

            var command = $"UPDATE public.project " +
                $"SET name='{Name}', description='{Description}', date_created='{DateCreated}', " +
                $"date_start_p='{DateStartP}', date_finish_p='{DateFinishP}', " +
                $"date_start_f='{dSF}', date_finish_f='{dFF}' " +
                $"WHERE id={Id};";

            //try
            //{
            databaseAdapter.ExecuteCommandNoReturn(command);
            return true;

            //}
            //catch (Exception)
            //{
            //    return false;
            //}

        }

        public void Delete()
        {
            var command = $"DELETE FROM public.project WHERE id = {Id};";

            databaseAdapter.ExecuteCommandNoReturn(command);

        }
    }

}
