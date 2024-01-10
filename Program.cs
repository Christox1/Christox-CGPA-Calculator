using System.ComponentModel.Design;
using System.Threading.Tasks.Sources;

namespace Christox_GPA_Calculator
{
    internal class Program
    {    
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Christox Student GPA Calculator");           

            Console.Write("Number of Courses Taken: \n");
            int numberOfCourse = int.Parse(Console.ReadLine());

            List<CourseEvaluator> courseBreakdown = new List<CourseEvaluator>();
            Console.Clear();
            for (int i = 0; i < numberOfCourse; i++)
            {
                Console.Write($"Enter course code for course #{i + 1}): ");
                string courseCode = Console.ReadLine();
                Console.Clear();
                Console.Write($"Credit unit for {courseCode}: ");
                int creditUnit = int.Parse(Console.ReadLine());
                Console.Clear();
                Console.Write($"Enter mark scored for {courseCode}: ");
                int score = int.Parse(Console.ReadLine());
                Console.Clear();

                char grade;
                int gradeUnit;
                int weightPoint;
                string remark;

                if (score >=70 && score <=100)
                {
                    grade = 'A';
                    gradeUnit = 5;
                    remark = "Excellent";
                }
                else if (score >=60 && score <=69)
                {
                    grade = 'B';
                    gradeUnit = 4;
                    remark = "Very Good";
                }
                else if (score >=50 && score <=59)
                {
                    grade = 'C';
                    gradeUnit = 3;
                    remark = "Good";
                }
                else if (score >=45 && score <=49)
                {
                    grade = 'D';
                    gradeUnit = 2;
                    remark = "Fair";
                }
                else if (score >=40 && score <=44)
                {
                    grade = 'E';
                    gradeUnit = 1;
                    remark = "pass";
                }
                else
                {
                    grade = 'F';
                    gradeUnit = 0;
                    remark = "Fail";
                }

                weightPoint = creditUnit * gradeUnit;
                courseBreakdown.Add(new CourseEvaluator
                {
                    CourseCode = courseCode, CreditUnit = creditUnit,Grade = grade, GradeUnit = gradeUnit, WeightPoint = weightPoint, Remark = remark
                });  
                    
            }
                Console.Clear();
                
                Console.WriteLine("|--------------------------|---------------------|----------|-------------------|-----------------|-----------------|");
                Console.WriteLine("|  COURSE CODE             | COURSE UNIT         | GRADE    | GRADE UNIT        | WEIGHT POINT    | REMARK          |");
                Console.WriteLine("|--------------------------|---------------------|----------|-------------------|-----------------|-----------------|");                                                                       
                foreach (var breakdown in courseBreakdown)
                { 
              Console.WriteLine($"| {breakdown.CourseCode,-24} | {breakdown.CreditUnit,-20}| {breakdown.Grade,-9}| {breakdown.GradeUnit,-18}| {breakdown.WeightPoint,-16}| {breakdown.Remark,-16}|");
                }

                Console.WriteLine("|--------------------------|---------------------|----------|-------------------|-----------------|-----------------|");


            int totalCourseUnitRegistered = 0;
            int totalCourseUnitPassed = 0;
            double totalWeightPoint = 0;

            foreach (var breakdown in courseBreakdown) 
            {
                totalCourseUnitRegistered += breakdown.CreditUnit;
                if (breakdown.Grade != 'F')
                {
                    totalCourseUnitPassed += breakdown.CreditUnit;
                    totalWeightPoint += breakdown.WeightPoint;              
                }
            }

            double gpa = Math.Round(totalWeightPoint / totalCourseUnitPassed, 2);

            Console.WriteLine($"Total Course Unit Registered is {totalCourseUnitRegistered}");
            Console.WriteLine($"Total Course Unit Passed is {totalCourseUnitPassed}");
            Console.WriteLine($"Total weight Point is {totalWeightPoint}");
            Console.WriteLine($"Your GPA is = {gpa}");
        }
    }

    class CourseEvaluator
    {
        public string CourseCode { get; set; }
        public int CreditUnit { get; set; }
        public char Grade { get; set; }
        public int GradeUnit { get; set; }
        public int WeightPoint { get; set; }
        public string Remark { get; set; }

    }
}