using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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

        public Worker(string surname, string name, string patronym,
            DateTime birthDate, string email, string tg, string phone,
            string passSerie, string passNum, DateTime passDate, string adressPass,
            string adressFact, string passWho, int job, int qualLevel
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

        public void Insert()
        {
            var command = "INSERT INTO public.worker " +
                "(surname, name, patronym, birth_date, email, tg, phone," +
                "pass_serie, pass_num, pass_date, adress_pass, adress_fact)" +
                "VALUES ('Иванов', 'Иван', 'Иванович', '14-04-1990', 'a@mail.ru', 'ivan', '79224817888'," +
                "2586, 654253, '25-01-2015', 'Улица Пушкина', 'Дом Колотушкина');";
        }

        public void Update()
        {
            var command = "UPDATE public.worker" +
                "SET id=?, surname=?, name=?, patronym=?, birth_date=?, email=?, tg=?, phone=?," +
                "pass_serie=?, pass_num=?, pass_date=?, adress_pass=?, adress_fact=?, qual_level=?," +
                "job_position=?, pass_who=?" +
                "WHERE <condition>;";
        }

        public void Delete()
        {
            var command = "DELETE FROM public.worker WHERE <condition>;";
        }
    }

    public class ValidationResponse
    {
        public bool isValid { get; set; } = true;
        public string Message { get; set; } = string.Empty;
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
