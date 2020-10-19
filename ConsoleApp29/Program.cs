using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace ConsoleApp29
{
    class Program
    {
        static void Main(string[] args)
        {
            var students = CreaterandomStudents(20).ToList();

            students[19].Mark = 20;
            students[5].Mark = 20;

            Console.WriteLine("First");
            foreach (var st in students)
            {
                Console.WriteLine($"{st.University}|{st.Name}|{st.Mark}");
            }
            Console.WriteLine();
            Console.WriteLine("Task 1:");
            var task1 = students
                .Where(st => st.Mark > 8)
                .OrderByDescending(st => st.Mark)
                .OrderBy(st => st.University);

            foreach (var item in task1)
            {
                Console.WriteLine($"{item.University}|{item.Mark}");
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Task 2:");
            var task2 = students
                .OrderByDescending(st => st.Mark)

                .GroupBy(st => st.University)

            .ToDictionary(st => st.Key, sts => sts)
            ;

            var task2Result = task2[University.Politexnik].Take(5)
                .Concat(task2[University.AUA].Take(5))
                .Concat(task2[University.EPH].Take(5));


            foreach (var st in task2Result)
            {
                Console.WriteLine($"{st.University}|{st.Name}|{st.Mark}");
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Task 3:");
            var task3 = students
                .Distinct()
                .OrderByDescending(st=>st.Mark)
                .Take(1);
            ;


            foreach (var st in task3)
            {
               Console.WriteLine($"{st.University}|{st.Name}|{st.Mark}");
            }

        }
        private static IEnumerable<Student> CreaterandomStudents(int count)
        {
            University[] universties = { University.AUA, University.EPH, University.Politexnik, University.Politexnik };
            var rnd = new Random();
            for (int i = 1; i <= count; i++)
            {
                yield return new Student
                {
                    Name = $"A{i}",
                    Surname = $"A{i}yan",
                    Age = rnd.Next(17, 40),
                    Mark = (byte)rnd.Next(0, 21),
                    University = universties[rnd.Next(0, universties.Length)]
                };
            }
        }
    }
    public class Student
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Mark { get; set; }

        public University University { get; set; }

        public string Fullname => $"{Mark} - {Name}";

        public override string ToString() => Fullname;
    }
    public enum University
    {
        EPH,
        Politexnik,
        AUA
    }
}