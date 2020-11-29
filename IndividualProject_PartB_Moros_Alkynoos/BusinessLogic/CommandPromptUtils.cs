using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndividualProject_PartB_Moros_Alkynoos.Models;

namespace IndividualProject_PartB_Moros_Alkynoos.BusinessLogic
{
    class CommandPromptUtils
    {
        SQL_Utils sQL_Utils = new SQL_Utils();

        //-----------Trainer-------------------
        protected internal int InputTrainer(List<string> subjects = null)
        {
            if (subjects == null) subjects = new List<string>() { "C#", "Java", "JavaScript", "Python", "PHP" };
            Trainer trainer = new Trainer();
            trainer.FirstName = AskDetail("Give me your first name");
            trainer.LastName = AskDetail("Give me your last name");          

            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            sQL_Utils.InputToTrainerTable(trainer.FirstName, trainer.LastName);
            
            int trainerID = TakeLatestEntryID(connectionStr, " Trainers ", " TrainerID ");            
            
            trainer.Subject = AskDetail("Select the subject you teach", subjects);
            int streamID = ChooseStream(trainer.Subject);
            sQL_Utils.InputToTrainerSubjectsTable(trainerID, streamID);

            return (trainerID);
        }

        protected internal void InputTrainerPerCourse() 
        {
            List<string> choises = new List<string>() { "Insert existing Trainer to course.", "Input new Trainer to course." };
            Console.WriteLine("Selct From Below: ");
            string choiseReturn = SelectFromListOfStrings(choises);
            int trainerID;
            int courseID = 0;
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            if (choiseReturn == "Insert existing Trainer to course.")
            {
                

                sQL_Utils.SelectTrainer();
                Console.Write("Input Trainer ID: ");
                trainerID = int.Parse(Console.ReadLine());
                DisplayCoursesForUser();
                Console.Write("Input course ID that you wish to insert Trainer: ");
                courseID = int.Parse(Console.ReadLine());
            }
            else
            {
                InputTrainer();
                trainerID = TakeLatestEntryID(connectionStr, "Trainers", "TrainerID");
                DisplayCoursesForUser();
                Console.Write("Input course ID that you wish to insert Trainer: ");
                courseID = int.Parse(Console.ReadLine());
            }
            using (SqlConnection connection = new SqlConnection(connectionStr)) 
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = $"INSERT INTO TrainerPerCourse VALUES ({courseID},{trainerID})";
                    command.Connection = connection;
                    command.ExecuteNonQuery();

                }

            }
        }




        //-------------Course--------------------------

        protected internal int InputCourse(List<string> stream = null, List<string> type = null)
        {
            if (stream == null) stream = new List<string>() { "C#", "Java", "JavaScript", "Python", "PHP" };
            if (type == null) type = new List<string>() { "Full Time", "Part Time"};
            Course course = new Course();
            string title = AskDetail("Give Course Title: ");  
            Console.WriteLine("Select trainer ID for the course, see the table below.");
                       

            course.Stream = AskDetail("Select Stream", stream);
            int streamID = ChooseStream(course.Stream);
            course.Type = AskDetail("Select Type", type);
            int typeID = ChooseType(course.Type);

            course.Start_Date = Convert.ToDateTime(AskDetail("Give Course Start Date"));
            course.End_Date = Convert.ToDateTime(AskDetail("Give Course End Date"));

            sQL_Utils.InputToCoursesTable(title, streamID, typeID, course.Start_Date, course.End_Date);

            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True"; 
            
            int latestCourseID = TakeLatestEntryID(connectionStr, "Courses", "CourseID");
            return (latestCourseID);
        }


        //---------------Student--------------------------

        protected internal int InputStudent()
        {            
            Student student = new Student();
            student.FirstName = AskDetail("Give me student first name");
            student.LastName = AskDetail("Give me student last name");
            student.DateOfBirth = Convert.ToDateTime(AskDetail("Give me student date of birth"));

            decimal outputTuitionFees;
            bool tuitionFeesDecimal = decimal.TryParse(AskDetail("Give me student's tuition fees").Replace('.', ','), out outputTuitionFees);
            student.TuitionFees = outputTuitionFees;
            string strTuitionFees = student.TuitionFees.ToString().Replace(',', '.');

            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string insertString = $"INSERT INTO Students (FirstName,LastName,Date_Of_Birth,TuitionFees) " + 
                                      $"VALUES ('{student.FirstName}','{student.LastName}','{student.DateOfBirth.ToString("yyyy-MM-dd")}','{strTuitionFees}')"; 
                SqlCommand command = new SqlCommand(insertString, connection);
                command.ExecuteNonQuery();
            }

            int inputSudentID = TakeLatestEntryID(connectionStr, "Students", "StudentID");
            return (inputSudentID);

        }

        protected internal void InputStudentsToCourse()
        {
            List<string> choises = new List<string>() { "Insert existing student to course." , "Input new student to course."  };
            Console.WriteLine("Selct From Below: ");
            string choiseReturn = SelectFromListOfStrings(choises);
            int studentID = 0;
            int courseID = 0;
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            if (choiseReturn == "Insert existing student to course.")
            {
                sQL_Utils.SelectStudent();
                Console.Write("Input Student ID: ");
                studentID = int.Parse(Console.ReadLine());
                DisplayCoursesForUser();
                Console.Write("Input course ID that you wish to insert student: ");
                 courseID = int.Parse(Console.ReadLine());
            }
            else
            {
                InputStudent();                               
                studentID = TakeLatestEntryID(connectionStr, "Students", "StudentID");
                DisplayCoursesForUser();
                Console.Write("Input course ID that you wish to insert student: ");
                courseID = int.Parse(Console.ReadLine());
            }

            sQL_Utils.InputToStudentPerCourseTable(courseID, studentID);

            
        }

        //-------------Assignment--------------------------


        protected internal int InputAssignment()
        {
            Assignment assignment = new Assignment();
            assignment.Title = AskDetail("Give me assigment title");
            assignment.Description = AskDetail("Give me description");

            string  connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandText = $"INSERT INTO Assignments VALUES ('{assignment.Title}','{assignment.Description}')";
                command.Connection = connection;
                
                command.ExecuteNonQuery();
            }

            int latestAssignmentID = TakeLatestEntryID(connectionStr, "Assignments", "AssignmentID");

            return (latestAssignmentID);

        }

        protected internal void InputAssignmentPerStudentPerCourse()
        {
            List<string> choises = new List<string>() { "Insert existing assignment.", "Input new assignment." };
            Console.WriteLine("Selct From Below: ");
            string choiseReturn = SelectFromListOfStrings(choises);
            int assignmentID = 0;

            if (choiseReturn == "Insert existing assignment.")
            {
                sQL_Utils.SelectAssignment();
                Console.Write("Input Assignment ID: ");
                assignmentID = int.Parse(Console.ReadLine());
            }
            else
            {               
                assignmentID = InputAssignment();
                Console.WriteLine(assignmentID);
            }

            List<string> choisesStudent = new List<string>() { "Insert existing Student.", "Input new Student." };
            Console.WriteLine("Selct From Below: ");
            string choiseReturnStudent = SelectFromListOfStrings(choisesStudent);

            int studentID = 0;

            if (choiseReturnStudent =="Insert existing Student.")
            {
                sQL_Utils.SelectStudent();
                Console.Write("Input Student ID: ");
                studentID = int.Parse(Console.ReadLine());
            }
            else
            {
                studentID = InputStudent();
            }

            List<string> choisesCourse = new List<string>() { "Insert existing Course.", "Input new Course." };
            Console.WriteLine("Selct From Below: ");
            string choiseReturnCourse = SelectFromListOfStrings(choisesCourse);

            int courseID = 0;

            if (choiseReturnCourse == "Insert existing Course.")
            {
                sQL_Utils.SelectCourse();
                Console.Write("Input Course ID: ");
                courseID = int.Parse(Console.ReadLine());
            }
            else
            {
                courseID = InputCourse();
            }

            Assignment assignment = new Assignment();
            assignment.SubDateTime = Convert.ToDateTime(AskDetail("Give Assignment submission date & time"));
            decimal outputOral;
            decimal outputTotal;
            bool oralDecimal = decimal.TryParse(AskDetail("Give Assignment oral mark").Replace('.', ','), out outputOral);
            assignment.OralMark = outputOral;
            bool totalDecimal = decimal.TryParse(AskDetail("Give Assignment total mark").Replace('.', ','), out outputTotal);
            assignment.TotalMark = outputTotal;

            

            sQL_Utils.InputToStudentPerCourseTable(courseID, studentID);
            sQL_Utils.InputToAssignmentPerCourseTable(assignmentID, assignment.SubDateTime, assignment.OralMark, assignment.TotalMark, courseID);



            
        }

        //-------Methodes use in the class

        protected internal int ChooseStream(string stream)
        {
            int streamID = 0;
            switch (stream)
            {
                case "C#":
                    streamID = 1;
                    break;
                case "Java":
                    streamID = 2;
                    break;
                case "JavaScript":
                    streamID = 3;
                    break;
                case "Python":
                    streamID = 4;
                    break;
                case "PHP":
                    streamID = 5;
                    break;
                default:
                    break;
            }

            return (streamID);
        }

        protected internal int ChooseType(string type)
        {
            int typeID = 0;
            switch (type)
            {
                case "Full Time":
                    typeID = 1;
                    break;
                case "Part Time":
                    typeID = 2;
                    break;
                default:
                    break;
            }
            return (typeID);
        }


        private string AskDetail(string message, List<string> subjects = null)
        {
            string result = "";
            Console.Write(message + ": ");
            if (subjects != null)
            {
                result = SelectFromListOfStrings(subjects);
            }
            else
            {
                result = Console.ReadLine();
            }

            return (result);
        }

        private string SelectFromListOfStrings(List<string> elements)
        {
            string result = "";
            int counter = 1;
            Console.WriteLine();
            foreach (var item in elements)
            {
                Console.WriteLine($"{counter++}. {item}");
            }

            int choice = 0;
            do
            {
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out choice))
                {
                    if (choice <= elements.Count && choice > 0)
                    {
                        result = elements.ElementAt(choice - 1);
                        break;
                    }
                }
                else
                    Console.Write("Enter Correct selection: ");
            } while (true);

            return (result);
        }

        private static int TakeLatestEntryID(string connectionStr, string Table, string PrimaryKey)
        {
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = $"SELECT MAX({PrimaryKey}) FROM {Table}";
                    command.Connection = connection;
                    int latestID = (int)command.ExecuteScalar();
                    return (latestID);
                }

            }
        }

        private void DisplayCoursesForUser()
        {
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = "SELECT Title, CourseID, Stream.Name AS Stream, Type.Name AS Type, StartDate, EndDate FROM Courses " +
                                            "INNER JOIN TrainerSubjects ON Courses.StreamID = TrainerSubjects.StreamID " +
                                            "INNER JOIN Stream ON Stream.StreamID = TrainerSubjects.StreamID " +
                                            "INNER JOIN Type ON Type.TypeID = Courses.TypeID " +
                                            "GROUP BY Courses.CourseID, Courses.Title,CourseID, Title, Stream.Name, Type.Name, StartDate, EndDate";
                    command.Connection = connection;

                    SqlDataReader reader = null;
                    try
                    {
                        reader = command.ExecuteReader();
                        if (reader != null)
                        {
                            Console.WriteLine($"Title\tCourse ID\tStream\t\tType\t\tStart Date\tEnd Date\n");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0]}\t{reader[1],-5}\t\t{reader[2],-5}\t\t{reader[3],5}\t{Convert.ToDateTime(reader[4]).ToString("dd/MM/yyyy")}\t{Convert.ToDateTime(reader[5]).ToString("dd/MM/yyyy")}");
                            }
                        }

                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        if (reader != null)
                            reader.Close();
                        if (connection != null)
                            connection.Close();
                    }

                }
            }
        }


    }

}
