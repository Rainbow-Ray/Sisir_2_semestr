using Sisir.Sprav;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Sisir.Entity
{
    public class JobPos : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Zp { get; set; }

        private static DatabaseAdapter databaseAdapter = new DatabaseAdapter();

        private static RegexRules regRules = new RegexRules();

        private static string table = "job_position";

        public JobPos() { }

        public JobPos(string name, int zp)
        {
            Name = name;
            Zp = zp;
        }

        public JobPos(int id)
        {
            Id = id;
            var selectedJob = Select(id);

            if (selectedJob.Count > 0)
            {
                var jobData = selectedJob[0];
                Name = jobData["name"];
                int zp;
                if (int.TryParse(jobData["salary"], out zp))
                {
                    Zp = zp;
                }
                else
                {
                    MessageBox.Show("Произошла ошибка при вынимании Зар. платы из базы данных.");
                }
            }
            else
            {
                MessageBox.Show($"Произошла ошибка при получении данных о должности с идентификатором {id}");
            }
        }
        public JobPos(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public JobPos(int id, string name, int zp)
        {
            Id = id;
            var data = Select(id);
            if (data.Count > 0)
            {
                Name = name;
                Zp = zp;
            }
            else
            {
                MessageBox.Show($"Произошла проблема при поиске должности с идентификатором ({id})");
            }
        }

        public static List<JobPos> GetList()
        {
            var command = $"Select id, name from {table}";
            var dict = databaseAdapter.ExecuteCommand(command);
            var list = new List<JobPos>();
            foreach (var item in dict)
            {
                var j = new JobPos(int.Parse(item["id"]), item["name"]);
                list.Add(j);
            }
            return list;
        }

        public static DataSet GetDataSet()
        {
            return databaseAdapter.GetDataSet("Select * FROM job_position");
        }

        public ValidationResponse Validate()
        {
            var regRules = new RegexRules();
            var response = new ValidationResponse();

            if (string.IsNullOrEmpty(Name) || !isValid(Name, regRules.lettersOnly))
            {
                response.isValid = false;
                response.Message += "Поле Название должности должно быть не пустым и содержать только буквы.\n";
            }
            if (string.IsNullOrEmpty(Zp.ToString()) || !isValid(Zp.ToString(), regRules.numberOnly))
            {
                response.isValid = false;
                response.Message += "Введите правильную заработную плату. Например, 10000 \n";
            }
            return response;
        }

        private bool isValid(string field, Regex regex)
        {
            return regex.IsMatch(field);
        }

        public static List<Dictionary<string, string>> Select(int id)
        {
            var command = "SELECT id, name, salary " +
                 $" FROM public.job_position WHERE id={id};";

            var workerData = databaseAdapter.ExecuteCommand(command);

            return workerData;
        }

        public static bool IsIn(int id)
        {
            var data = Select(id);
            if (data.Count > 0)
            {
                return true;
            }
            return false;
        }

        public static DataSet UpdateDataSet()
        {
            var ds = GetDataSet();
            databaseAdapter.UpdateDataSet(ds.Tables[0], "Select * from job_position");
            return ds;
        }

        public void Insert()
        {
            var command = $"INSERT INTO public.job_position " +
                $"(name, salary)" +
                $"VALUES ('{Name}', '{Zp}');";

            databaseAdapter.ExecuteCommandNoReturn(command);


        }


        public bool Update()
        {
            var command = "UPDATE public.job_position" +
                $" SET name='{Name}', salary='{Zp}'" +
                $" WHERE id='{Id}';";

            try
            {
                databaseAdapter.ExecuteCommandNoReturn(command);
                return true;

            }
            catch (Npgsql.PostgresException)
            {
                MessageBox.Show("Произошла ошибка при обновлении данных должности.");
                return false;
            }


        }

        public void Delete()
        {
            try
            {
                var command = $"DELETE FROM public.job_position WHERE id={Id};";
                databaseAdapter.ExecuteCommandNoReturn(command);
            }
            catch (Npgsql.PostgresException)
            {
                MessageBox.Show("Эта должность установлена у сотрудника. Вы не можете ее удалить.");
            }

        }


    }
}
