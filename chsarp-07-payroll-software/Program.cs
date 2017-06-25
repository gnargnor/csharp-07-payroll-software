using System;

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

        public void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");
            BasicPay = hWorked * hourlyRate;
            TotalPay = BasicPay;

        }

        public override string ToString()
        {
            return string.Format("[Staff: \nTotalPay={0}, \nBasicPay={1}, \nNameOfStaff={2}, \nHoursWorked={3}]", TotalPay, BasicPay, NameOfStaff, HoursWorked);
        }
    }//End Staff Class


    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
