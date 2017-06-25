using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace chsarp07payrollsoftware
{
    //Staff Class
    class Staff
    {
        private float hourlyRate;
        private int hWorked;

        public float TotalPay { get; protected set; }
        public float BasicPay { get; private set; }
        public string NameOfStaff { get; private set; }

        public int HoursWorked
        {
            get
            {
                return hWorked;    
            }
            set
            {
                if (value > 0){
                    hWorked = value;
                } else {
                    hWorked = 0;
                }

            }
        }

        public Staff(string name, float rate)
        {
            NameOfStaff = name;
            hourlyRate = rate;
        }

        //virtual methods can be overriden by child class methods
        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;

        }

        public override string ToString()
        {
            return string.Format("[Staff:\n -TotalPay={0},\n -BasicPay={1},\n -NameOfStaff={2},\n -HoursWorked={3}]", TotalPay, BasicPay, NameOfStaff, HoursWorked);
        }
    }//End Staff Class


    //Manager : Staff
    class Manager : Staff
    {   
        //constants must be assigned a variable when defined
        private const float managerHourlyRate = 50;

        public int Allowance { get; private set; }

        //pass name parameter and managerHourlyRate constant to Staff constructor, empty code block
        public Manager(string name) : base(name, managerHourlyRate){}

        //overrides virtual method of staff
        public override void CalculatePay()
        {
            base.CalculatePay();
            Allowance = 1000;
            if (HoursWorked > 160){
                TotalPay = BasicPay + 1000;
            } else {
                TotalPay = BasicPay;
            }
        }

        public override string ToString()
        {
            return string.Format("[Manager:\n -Allowance={0}]", Allowance);
        }
    }//End Manager Child Class


    //Admin : Staff Class
    class Admin : Staff
    {
        private const float overtimeRate = 15.5F;
        private const float adminHourlyRate = 30;

        public float Overtime { get; private set; }
        public Admin(string name) : base(name, adminHourlyRate){}

        public override void CalculatePay()
        {
            base.CalculatePay();
            if (HoursWorked > 160){
                Overtime = overtimeRate * (HoursWorked - 160);
                TotalPay = BasicPay + Overtime;
            }
        }

        public override string ToString()
        {
            return string.Format("[Admin:\n -Overtime={0}]", Overtime);
        }
    }//Admin : Staff Class end


    //File Reader Class
    class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = { ", " };

            if (File.Exists("staff.txt"))
            {
                string path = "staff.txt";
                using (StreamReader sr = new StreamReader(path))
                {
                    while (sr.EndOfStream != true)
                    {
                        result = sr.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        if (result[1] == "Manager"){
                            myStaff.Add(new Manager(result[0]));
                        } else if (result[1] == "Admin"){
                            myStaff.Add(new Admin(result[0]));
                        }
                    }
                    sr.Close();
                }
            }
            else
            {
                Console.WriteLine("staff.txt does not exist.");
            }
            return myStaff;
        }

    }//End File Reader


    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
