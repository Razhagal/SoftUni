using System;
using System.Collections.Generic;
using System.Linq;

namespace AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, List<decimal>> studentsGrades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < count; i++)
            {
                string[] studentData = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string studentName = studentData[0];
                decimal studentGrade = decimal.Parse(studentData[1]);

                if (!studentsGrades.ContainsKey(studentName))
                {
                    studentsGrades.Add(studentName, new List<decimal>());
                }

                studentsGrades[studentName].Add(studentGrade);
            }

            foreach (var student in studentsGrades)
            {
                Console.Write($"{student.Key} -> ");
                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:f2} ");
                }

                Console.WriteLine($"(avg: {student.Value.Average():f2})");
            }
        }
    }
}
