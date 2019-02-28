using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW8_Overload
{
    #region
    public class Person
    {
        public string firstName { set; get; }
        public string lastName { set; get; }
        public int age { set; get; }
        public Person() { }
        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }
        public static bool operator ==(Person p1, Person p2)
        {
            if (p1.firstName == p2.firstName && p1.lastName == p2.lastName && p1.age == p2.age)
                return true;
            else
                return false;
        }
        public static bool operator !=(Person p1, Person p2)
        {
            if (p1.firstName == p2.firstName && p1.lastName == p2.lastName && p1.age == p2.age)
                return false;
            else
                return true;
        }
        public override bool Equals(Object obj)
        {
            Person p = (Person)obj;
            return this.firstName == p.firstName && this.lastName == p.lastName && this.age == p.age;
        }
    }
    public class Employees
    {
        public Person[] employees = new Person[3];
        public Person this[int index]
        {
            get
            {
                return employees[index];
            }
            set
            {
                employees[index] = value;
            }
        }

        public static bool operator >(Employees e1, Employees e2)
        {
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < e1.employees.Length; i++)
                sum1 += e1.employees[i].age;
            for (int i = 0; i < e2.employees.Length; i++)
                sum2 += e2.employees[i].age;
            if (sum1 > sum2)
                return true;
            else
                return false;
        }
        public static bool operator <(Employees e1, Employees e2)
        {
            int sum1 = 0;
            int sum2 = 0;
            for (int i = 0; i < e1.employees.Length; i++)
                sum1 += e1.employees[i].age;
            for (int i = 0; i < e2.employees.Length; i++)
                sum2 += e2.employees[i].age;
            if (sum1 < sum2)
                return true;
            else
                return false;
        }
        public static double[] operator *(Employees e1, Employees e2)
        {
            double[] mult = new double[3];
            if (e1.employees.Length == e2.employees.Length)
            {
                for (int i = 0; i < e1.employees.Length; i++)
                {
                    mult[i] = e1.employees[i].age * e2.employees[i].age;
                }
                return mult;
            }
            else
            {
                Console.WriteLine("Разные размеры массивов!");
                return mult;
            }
        }
        public static explicit operator int(Employees e)
        {
            return e.employees.Length;
        }
        public static Employees operator +(Employees e1, Employees e2)
        {
            Employees e = new Employees();
            for (int i = 0; i < e.employees.Length; i++)
            {
                e.employees[i] = e1.employees[i];
                e.employees[i].age = e1.employees[i].age + e2.employees[i].age;
            }
            return e;
        }

    }
    public class Money
    {
        public decimal Amount { get; set; }
        public string Unit { get; set; }

        public Money(decimal amount, string unit)
        {
            Amount = amount;
            Unit = unit;
        }
        public static Money operator +(Money a, Money b)
        {
            if (a.Unit != b.Unit)
            {
                decimal sum = Conversion.Converse(a) + Conversion.Converse(b);
                return new Money(sum, "KZT");
            }

            return new Money(a.Amount + b.Amount, a.Unit);
        }
        public static bool operator ==(Money a, Money b)
        {
            if (a.Unit == b.Unit && a.Amount == b.Amount)
                return true;
            else
                return false;
        }
        public static bool operator !=(Money a, Money b)
        {
            if (a.Unit == b.Unit && a.Amount == b.Amount)
                return false;
            else
                return true;
        }
    }
    public class Conversion
    {
        public string currency;
        public Conversion(string cur)
        {
            this.currency = cur;
        }
        public static decimal Converse(Money m)
        {
            if (m.Unit == "KZT")
            {
                m.Amount = m.Amount * 1;
                return m.Amount;
            }
            else if (m.Unit == "USD")
            {
                m.Amount = m.Amount * 370;
                return m.Amount;
            }
            else if (m.Unit == "EUR")
            {
                m.Amount = m.Amount * 420;
                return m.Amount;
            }
            else if (m.Unit == "RUR")
            {
                m.Amount = m.Amount * 5;
                return m.Amount;
            }
            else
                return m.Amount;
        }
    }
    public class Decimal
    {

    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            #region
            Person p1 = new Person("Иванов", "Иван", 20);
            Person p2 = new Person("Суслов", "Иван", 25);
            Person p3 = new Person("Сталин", "Талгат", 43);
            Person p4 = new Person("Дарк", "Жанна", 85);
            Person p5 = new Person("Ленин", "Касым", 11);
            Person p6 = new Person("Берий", "Стас", 25);

            ////Console.WriteLine(p1.Equals(p2));
            Employees e = new Employees();
            Employees e1 = new Employees();
           
            e.employees[0] = p1;
            e.employees[1] = p2;
            e.employees[2] = p3;
            //int len = (int)e;
            //Console.WriteLine(len);
            //Console.WriteLine(e[2]);
            e1.employees[0] = p4;
            e1.employees[1] = p5;
            e1.employees[2] = p6;
            //Employees e2 = e + e1;
            //for (int i = 0; i < e2.employees.Length; i++)
            //{
            //    Console.WriteLine(e.employees[i].age);
            //}
            //double [] mult = e * e1;
            //for (int i = 0; i < mult.Length; i++)
            //{
            //    Console.WriteLine(mult[i]);
            //}

            //Money m1 = new Money(100, "USD");
            //Money m2 = new Money(200, "USD");
            //Money m3 = m1 + m2;
            ////Console.WriteLine(m3.Amount);
            //Console.WriteLine(m1 == m2);
            #endregion

        }
    }
}
