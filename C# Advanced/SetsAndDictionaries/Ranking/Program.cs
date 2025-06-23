using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsPasswords = new Dictionary<string, string>();
            Dictionary<string, Student> students = new Dictionary<string, Student>();

            string command = Console.ReadLine();
            while (!command.Equals("end of contests"))
            {
                string[] inputContest = command.Split(":", StringSplitOptions.RemoveEmptyEntries);
                string contestName = inputContest[0];
                string contestPassword = inputContest[1];

                if (!contestsPasswords.ContainsKey(contestName))
                {
                    contestsPasswords.Add(contestName, contestPassword);
                }

                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            while (!command.Equals("end of submissions"))
            {
                string[] inputSubmission = command.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string contestName = inputSubmission[0];
                string contestPassword = inputSubmission[1];
                string studentName = inputSubmission[2];
                int studentScore = int.Parse(inputSubmission[3]);

                if (contestsPasswords.ContainsKey(contestName) && contestsPasswords[contestName].Equals(contestPassword))
                {
                    if (!students.ContainsKey(studentName))
                    {
                        students.Add(studentName, new Student(studentName));
                    }

                    students[studentName].AddCourse(contestName, studentScore);
                }

                command = Console.ReadLine();
            }

            List<Student> studentsList = students.Select(s => s.Value).OrderBy(s => s.Name).ToList();
            studentsList.ForEach(s => s.SortStudentCourses());

            Student bestStudent = studentsList.OrderByDescending(s => s.GetTotalScore()).First();
            Console.WriteLine($"Best candidate is {bestStudent.Name} with total {bestStudent.GetTotalScore()} points.");

            Console.WriteLine("Ranking:");
            for (int i = 0; i < studentsList.Count; i++)
            {
                Console.WriteLine(studentsList[i].ToString());
            }
        }
    }

    public class Student
    {
        private string name;
        private Dictionary<string, int> studentCourses;

        public string Name { get { return this.name; } set { this.name = value; } }

        public Student(string studentName)
        {
            Name = studentName;
            studentCourses = new Dictionary<string, int>();
        }

        public void AddCourse(string courseName, int score)
        {
            if (!studentCourses.ContainsKey(courseName))
            {
                studentCourses.Add(courseName, 0);
            }

            if (score > studentCourses[courseName])
            {
                studentCourses[courseName] = score;
            }
        }

        public int GetTotalScore()
        {
            return studentCourses.Select(s => s.Value).Sum();
        }

        public void SortStudentCourses()
        {
            studentCourses = studentCourses.OrderByDescending(s => s.Value).ToDictionary(k => k.Key, v => v.Value);
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine(this.name);
            int linesCount = 1;
            foreach (var course in this.studentCourses)
            {
                string courseData = $"#  {course.Key} -> {course.Value}";
                if (linesCount < this.studentCourses.Count)
                {
                    builder.AppendLine(courseData);
                }
                else
                {
                    builder.Append(courseData);
                }

                linesCount++;
            }


            return builder.ToString();
        }
    }
}
