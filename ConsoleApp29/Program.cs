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

            bool b = students.Any(st => st.Age > 20 && st.Age <= 25);
            Student s1 = students.FirstOrDefault(st => st.Age > 50);
            //Student s2 = students.First(st => st.Age > 20 && st.Age <= 25);
            var res1 = students.Where(st => st.Age > 20 && st.Age <= 25).ToList();
            List<string> res2 = students.Select(p => p.Fullname).ToList();

            var res3 = students
                .Where(st => st.Age > 20 && st.Age <= 25)
                .Select(st => st.Fullname)
                .ToList();

            object[] arr = { "A1", true, "B2", "A3", 10, };

            var task1 = students
                .Where(st => st.Mark > 8)
                .OrderByDescending(st => st.Mark)
                .OrderBy(st => st.University);

            ////foreach (var item in task1)
            ////{
            ////    Console.WriteLine($"{item.University}|{item.Mark}");
            ////}

            //Console.WriteLine();

            var task2 = students
                .OrderByDescending(st => st.Mark)
                .GroupBy(st => st.University)

            .ToDictionary(st => st.Key, sts => sts.ToList())
            ;




            ////foreach (var item in task2)
            ////{
            ////    foreach (var st in task2[item.Key])
            ////    {
            ////        int i = 1;
            ////        Console.WriteLine($"{st.University}|{st.Mark}");
            ////        if (i == 5) break;
            ////        i++;
            ////    }
            ////}

            var task3 = students
                .Distinct()
                .GroupBy(st => st.Mark)

                .ToDictionary(st => st.Key, sts => sts.ToList());
                ;

            
            foreach (var item in task3)
            {
                Console.WriteLine(item.Key);
            }
            //foreach (var item in task3)
            //{
            //    foreach (var st in task3[item.Key])
            //    {
            //        Console.WriteLine($"{st.University}|{st.Name}|{st.Mark}");
            //    }
            //}
            //Console.WriteLine("Answer:");
            //foreach (var st in task3[task3.Keys.Max()])
            //{

            //    Console.WriteLine($"Key({task3.Keys.Max()}){st.University}|{st.Name}|{st.Mark}");
            //}


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