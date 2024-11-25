using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using System.Data;

namespace Sisir.Sprav

{ 

    public interface IEntity
    {
        ValidationResponse Validate();
        void Insert();

        void Update();

        void Delete();
    }

    
    public class Worker :IEntity
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronym { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Tg { get; set; }
        public string Phone { get; set; }
        public string PassSerie { get; set; }
        public string PassNum { get; set; }
        public DateTime PassDate { get; set; }
        public string AdressPass { get; set; }
        public string AdressFact { get; set; }
        public string PassWho { get; set; }
        public int Job { get; set; }
        public int QualLevel { get; set; }
        public int Id { get; set; }

        private static DatabaseAdapter databaseAdapter = new DatabaseAdapter();

        private static RegexRules regRules = new RegexRules();



        //public Worker(string surname, string name, string patronym,
        //    DateTime birthDate, string email, string tg, string phone,
        //    string passSerie, string passNum, DateTime passDate, string adressPass,
        //    string adressFact, string passWho, int job, int qualLevel
        //    )
        //{
        //    Surname = surname;
        //    Name = name;
        //    Patronym = patronym;
        //    BirthDate = birthDate;
        //    Email = email;
        //    Tg = tg;
        //    Phone = phone;
        //    PassSerie = passSerie;
        //    PassNum = passNum;
        //    PassDate = passDate;
        //    AdressPass = adressPass;
        //    AdressFact = adressFact;
        //    PassWho = passWho;
        //    Job = job;
        //    QualLevel = qualLevel;
        //}

        public Worker() { }

        public static DataSet GetDataSet()
        {
            return databaseAdapter.GetDataSet("Select * FROM worker");
        }

        public Worker(int id) {
            Id = id;
            var workerData = Select(id)[0];

            Surname = workerData["surname"];
            Name = workerData["name"];
            Patronym = workerData["patronym"];
            DateTime bday;
            if (DateTime.TryParse(workerData["birth_date"], out bday))
            {
                BirthDate = bday;
            }
            else
            {
                MessageBox.Show("Произошла ошибка при вынимании Даты рождения из базы данных.");
            }
            Email = workerData["email"];
            Tg = workerData["tg"];
            Phone = workerData["phone"];
            PassSerie = workerData["pass_serie"];
            PassNum = workerData["pass_num"];
            DateTime pday;
            if (DateTime.TryParse(workerData["pass_date"], out pday))
            {
                PassDate = pday;
            }
            else
            {
                MessageBox.Show("Произошла ошибка при вынимании Даты выдачи паспорта из базы данных.");
            }
            AdressPass = workerData["adress_pass"];
            AdressFact = workerData["adress_fact"];
            PassWho = workerData["pass_who"];

            int job;
            if (int.TryParse(workerData["job_position"], out job))
            {
                Job = job;
            }
            else
            {
                MessageBox.Show("Произошла ошибка при вынимании Должности из базы данных.");
            }

            int qual;
            if (int.TryParse(workerData["qual_level"], out qual))
            {
                QualLevel = qual;
            }
            else
            {
                MessageBox.Show("Произошла ошибка при вынимании Уровня квалификации из базы данных.");
            }
        }

        public Worker(string surname, string name, string passNum, DateTime passDate,
            string patronym = null,
            DateTime birthDate = new DateTime(), string email =null, string tg = null, string phone = null,
            string passSerie = null,   string adressPass = null,
            string adressFact = null, string passWho = null, int job = -1, int qualLevel = -1
            )
        {
            Surname = surname;
            Name = name;
            Patronym = patronym;
            BirthDate = birthDate;
            Email = email;
            Tg = tg;
            Phone = phone;
            PassSerie = passSerie;
            PassNum = passNum;
            PassDate = passDate;
            AdressPass = adressPass;
            AdressFact = adressFact;
            PassWho = passWho;
            Job = job;
            QualLevel = qualLevel;
        }


        private bool isValidName()
        {
            return !(string.IsNullOrEmpty(Name) || !isValid(Name, regRules.lettersOnly));
        }

        private bool isValidSurname()
        {
            return !(string.IsNullOrEmpty(Surname) || !isValid(Surname, regRules.lettersOnly));
        }

        private bool isValidPatronym()
        {
            return !(!string.IsNullOrEmpty(Patronym) && !isValid(Patronym, regRules.lettersOnly));
        }

        private bool isValidBirthDate()
        {
            return !(BirthDate >= DateTime.Now || BirthDate < new DateTime(1700, 01, 01));
        }

        private bool isValidEmail()
        {
            return !(!string.IsNullOrEmpty(Email) && !isValid(Email, regRules.email));
        }

        private bool isValidTg()
        {
            return !(!string.IsNullOrEmpty(Tg) && !isValid(Tg, regRules.tg));
        }

        private bool isValidPhone()
        {
            return !(!string.IsNullOrEmpty(Phone) && !isValid(Phone, regRules.phone));
        }

        private bool isValidPassSerie()
        {
            return !(!string.IsNullOrEmpty(PassSerie) && !isValid(PassSerie, regRules.passSerie));
        }

        private bool isValidPassNum()
        {
            return !(string.IsNullOrEmpty(PassNum) || !isValid(PassNum, regRules.numberOnly));
        }

        private bool isValidPassDate()
        {
            return !(PassDate >= DateTime.Now || BirthDate < new DateTime(1700, 01, 01));
        }

        private bool isValidAdressPass()
        {
            return !(!string.IsNullOrEmpty(AdressPass) && !isValid(AdressPass, regRules.adress));
        }

        private bool isValidAdressFact()
        {
            return !(!string.IsNullOrEmpty(AdressFact) && !isValid(AdressFact, regRules.adress));
        }

        private bool isValidPassWho()
        {
            return !(!string.IsNullOrEmpty(PassWho) && !isValid(PassWho, regRules.adress));
        }


        public ValidationResponse Validate()
        {
            var regRules = new RegexRules();
            var response = new ValidationResponse();

            if (string.IsNullOrEmpty(Surname) || !isValid(Surname, regRules.lettersOnly)) {
                response.isValid = false;
                response.Message += "Поле Фамилии должно быть не пустым и содержать только буквы.\n";
            }
            if (string.IsNullOrEmpty(Name) || !isValid(Name, regRules.lettersOnly))
            {
                response.isValid = false;
                response.Message += "Поле Имени должно быть не пустым и содержать только буквы.\n";
            }
            if(!string.IsNullOrEmpty(Patronym) && !isValid(Patronym, regRules.lettersOnly))
            {
                response.isValid = false;
                response.Message += "Поле Отчество должно содержать только буквы.\n";
            }
            if (BirthDate >= DateTime.Now || BirthDate < new DateTime(1700, 01,01))
            {
                response.isValid = false;
                response.Message += "Введите реальную дату рождения.\n";
            }
            if (!string.IsNullOrEmpty(Email) && !isValid(Email, regRules.email))
            {
                response.isValid = false; 
                response.Message += "Введите правильный email. Например, ivan_2@mail.ru \n";
            }
            if (!string.IsNullOrEmpty(Tg) && !isValid(Tg, regRules.tg))
            {
                response.isValid = false;
                response.Message += "Введите правильный ник Telegram. Например, @ivan \n";
            }
            if (!string.IsNullOrEmpty(Phone) && !isValid(Phone, regRules.phone))
            {
                response.isValid = false;
                response.Message += "Введите правильный номер телефона. Например, 89224443311 \n";
            }
            if (!string.IsNullOrEmpty(PassSerie) && !isValid(PassSerie, regRules.passSerie))
            {
                response.isValid = false;
                response.Message += "Введите правильную серию паспорта. Например, 1234 \n";
            }
            if (string.IsNullOrEmpty(PassNum) || !isValid(PassNum, regRules.numberOnly))
            {
                response.isValid = false;
                response.Message += "Введите правильный номер паспорта. Например, 123456 \n";
            }
            if (PassDate >= DateTime.Now || BirthDate < new DateTime(1700, 01, 01))
            {
                response.isValid = false;
                response.Message += "Введите реальную дату выдачи паспорта.\n";
            }
            if (!string.IsNullOrEmpty(AdressPass) && !isValid(AdressPass, regRules.adress))
            {
                response.isValid = false;
                response.Message += "Введите правильный адрес прописки. Например, г.Тюмень, ул. Пушкина 7 \n";
            }
            if (!string.IsNullOrEmpty(AdressFact) && !isValid(AdressFact, regRules.adress))
            {
                response.isValid = false;
                response.Message += "Введите правильный адрес проживания. Например, г.Тюмень, ул. Пушкина 7 \n";
            }
            if (!string.IsNullOrEmpty(PassWho) && !isValid(PassWho, regRules.adress))
            {
                response.isValid = false;
                response.Message += "Введите правильную информацию о выдаче паспорта. " +
                    "Например, УМВД России по Тюменской области \n";
            }
            return response;
        }

        private bool isValid(string field, Regex regex)
        {
            return regex.IsMatch(field);
        }

        public static List<Dictionary<string, string>> Select(int id)
        {
            var command = "SELECT id, surname, name, patronym, birth_date, email, tg, phone, " +
                "pass_serie, pass_num, pass_date, adress_pass, adress_fact, qual_level, job_position, pass_who"
                + $" FROM public.worker WHERE id={id};";

            var workerData = databaseAdapter.ExecuteCommand(command);

            return workerData;
        }


        public static DataSet UpdateDataSet()
        {
            var ds = GetDataSet();
            databaseAdapter.UpdateDataSet(ds.Tables[0], "Select * from worker");
            return ds;
        }

        public void Insert()
        {
            string job = Job == -1 ? "null" : Job.ToString();
            string qual = QualLevel == -1 ? "null" : QualLevel.ToString();
            string bday = BirthDate.ToString("yyyy-MM-dd");
            string pasdate = PassDate.ToString("yyyy-MM-dd");

            var command = $"INSERT INTO public.worker " +
                $"(surname, name, patronym, birth_date, email, tg, phone," +
                $"pass_serie, pass_num, pass_date, adress_pass, adress_fact, pass_who, job_position, qual_level)" +
                $"VALUES ('{Name}', '{Surname}', '{Patronym}', '{bday}', '{Email}', '{Tg}', '{Phone}', " +
                $"'{PassSerie}', '{PassNum}', '{pasdate}', '{AdressPass}', '{AdressFact}', '{PassWho}', {job}, {qual});";
            
            databaseAdapter.ExecuteCommandNoReturn(command);


        }

        public void Update()
        {
            var command = "UPDATE public.worker" +
                $"SET surname={Surname}, name={Name}, patronym={Patronym}, birth_date={BirthDate}, email={Email}, tg={Tg}, phone={Phone}," +
                $"pass_serie={PassSerie}, pass_num={PassNum}, pass_date={PassDate}, adress_pass={AdressPass}, adress_fact={AdressFact}," +
                $"qual_level={QualLevel}, job_position={Job}, pass_who={PassWho}" +
                $"WHERE id={Id};";


            databaseAdapter.ExecuteCommandNoReturn(command);


        }

        public void Delete()
        {

            var command = $"DELETE FROM public.worker WHERE id={Id};";
            databaseAdapter.ExecuteCommandNoReturn(command);

        }
    }

    public class ValidationResponse
    {
        public bool isValid { get; set; } = true;
        public string Message { get; set; } = string.Empty;

        public bool AbortOperation { get; set; }
    }

    public class JobPos
    {
        public string Name { get; set; }
        public int Zp { get; set; }
        public JobPos(string name, int zp)
        {
            Name = name;
            Zp = zp;
        }
    }
    public class itemSkill
    {
        public string Name { get; set; }

        public itemSkill(string name)
        {
            Name = name;
        }
    }

    public class QualLevel
    {
        public string Name { get; set; }
        public double Coef { get; set; }
        public QualLevel(string name, double coef)
        {
            Name = name;
            Coef = coef;
        }
    }



}
