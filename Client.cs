using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace BankCurse
{
    public class Client
    {
        public int ClientId { set; get; }
        public string FirstName { set; get; }
        public string LastNAme { set; get; }
        public string Gender { set; get; }
        public string Dob { set; get; }
        public double MonthlySalary { set; get; }
        public string Adress { set; get; }
        public string PassportId { set; get; }
        public string Phone { set; get; }
        public string Email { set; get; }
        public string ImgPath { set; get; }
        public bool IsChanged { set; get; }

        public Client(int clientId, string firstName, string lastNAme, string gender, string dob, double monthlySalary, string _adress, string passportId, string phone, string email, string imgPath)
        {
            ClientId = clientId;
            FirstName = firstName;
            LastNAme = lastNAme;
            Gender = gender;
            Dob = dob;
            Adress = _adress;
            MonthlySalary = monthlySalary;
            PassportId = passportId;
            Phone = phone;
            Email = email;
            ImgPath = imgPath;
            IsChanged = true;
        }

        public Client()
        {
            var df = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
            ImgPath = $@"{df}\UsersImg\defaultUserImg.png";
            IsChanged = false;
        }

    }
}
