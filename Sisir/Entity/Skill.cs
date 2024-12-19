using Sisir.Sprav;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Sisir.Entity
{
    public class Skill : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }


        private static DatabaseAdapter databaseAdapter = new DatabaseAdapter();

        private static RegexRules regRules = new RegexRules();

        private static string table = "skill";

        public Skill()
        {
        }

        public Skill(string name)
        {
            Name = name;
        }

        public Skill(int id)
        {
            Id = id;
            var selectedLevel = Select(id);

            if (selectedLevel.Count > 0)
            {
                var levelData = selectedLevel[0];
                Name = levelData["name"];
            }
            else
            {
                MessageBox.Show($"Произошла ошибка при получении данных о должности с идентификатором {id}");
            }
        }

        public static DataSet GetDataSet()
        {
            return databaseAdapter.GetDataSet($"Select * FROM {table}");
        }

        public ValidationResponse Validate()
        {
            var regRules = new RegexRules();
            var response = new ValidationResponse();

            if (string.IsNullOrEmpty(Name))
            {
                response.isValid = false;
                response.Message += "Поле Название навыка должно быть не пустым.\n";
            }
            return response;
        }
        private bool isValid(string field, Regex regex)
        {
            return regex.IsMatch(field);
        }
        public static List<Dictionary<string, string>> Select(int id)
        {
            var command = "SELECT id, name " +
                 $" FROM public.{table} WHERE id={id};";

            var skillData = databaseAdapter.ExecuteCommand(command);

            return skillData;
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
            databaseAdapter.UpdateDataSet(ds.Tables[0], $"Select * from {table}");
            return ds;
        }

        public void Insert()
        {
            try
            {
                var command = $"INSERT INTO public.{table} " +
                    $"(name)" +
                    $" VALUES ('{Name}');";

                databaseAdapter.ExecuteCommandNoReturn(command);

            }
            catch (Npgsql.PostgresException)
            {
                MessageBox.Show("Произошла ошибка при добавлении навыка.");
            }
        }

        public bool Update()
        {

            var command = $"UPDATE public.{table}" +
                $" SET name='{Name}' " +
                $" WHERE id={Id};";

            try
            {
                databaseAdapter.ExecuteCommandNoReturn(command);
                return true;

            }
            catch (Exception)
            {
                return false;
            }

        }

        public void Delete()
        {
            try
            {
                var command = $"DELETE FROM public.{table} WHERE id={Id};";
                databaseAdapter.ExecuteCommandNoReturn(command);

            }
            catch (Npgsql.PostgresException)
            {
                MessageBox.Show("Данный навык назначен сотруднику. Вы не можете удалить его.");
            }
        }

    }


}
