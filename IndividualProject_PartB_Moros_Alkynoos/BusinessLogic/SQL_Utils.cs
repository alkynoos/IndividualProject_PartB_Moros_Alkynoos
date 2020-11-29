using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject_PartB_Moros_Alkynoos.BusinessLogic
{
    class SQL_Utils
    {
       

        protected internal void SelectStudent()
        {
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Select * From Students", connection))
                {
                    SqlDataReader reader = null;
                    try
                    {
                        reader = command.ExecuteReader();
                        if (reader != null)
                        {
                            Console.WriteLine($"ID\tFirst Name\tLast Name\tDate of birth\tTuition Fees\n");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0]}\t{reader[1],-10}\t{reader[2],-10}\t{Convert.ToDateTime(reader[3]).ToString("dd/MM/yyyy"),-10}\t{reader[4],-10}");
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
        protected internal void SelectTrainer()
        {
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Select * From Trainers", connection))
                {
                    SqlDataReader reader = null;
                    try
                    {
                        reader = command.ExecuteReader();
                        if (reader != null)
                        {
                            Console.WriteLine($"ID\tFirst Name\tLast Name\n");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0]}\t{reader[1],-10}\t{reader[2],-10}");
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
        protected internal void SelectAssignment()
        {
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Select * From Assignments", connection))
                {
                    SqlDataReader reader = null;
                    try
                    {
                        reader = command.ExecuteReader();
                        if (reader != null)
                        {
                            Console.WriteLine($"ID\tTitle\t\t\tDescription\n");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0]}\t{reader[1],-20}\t{reader[2],-15}");
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
        protected internal void SelectCourse()
        {
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("Select * From Courses", connection))
                {
                    SqlDataReader reader = null;
                    try
                    {
                        reader = command.ExecuteReader();
                        if (reader != null)
                        {
                            Console.WriteLine($"Title\tCourse ID\tStream ID\tType ID\t\tStart Date\tEnd Date\n");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0]}\t{reader[1],5}\t\t{reader[2],5}\t\t{reader[3],5}\t\t{Convert.ToDateTime(reader[4]).ToString("dd/MM/yyyy")}\t{Convert.ToDateTime(reader[5]).ToString("dd/MM/yyyy")}");
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

        protected internal void SelectStudentPerCourse() 
        {
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT  Courses.CourseID, Courses.Title, Stream.Name AS Stream, Type.Name AS Type, " +
                                                            "CONCAT(Students.FirstName, Students.LastName) AS Students " +
                                                            "FROM Courses INNER JOIN  Stream ON Courses.StreamID = Stream.StreamID " +
                                                            "INNER JOIN  StudentsPerCourse ON Courses.CourseID = StudentsPerCourse.CourseID " +
                                                            "INNER JOIN  Students ON StudentsPerCourse.StudentID = Students.StudentID " +
                                                            "INNER JOIN  Type ON Courses.TypeID = Type.TypeID", connection))
                {
                    SqlDataReader reader = null;
                    try
                    {
                        reader = command.ExecuteReader();
                        if (reader != null)
                        {
                            Console.WriteLine($"Course ID\tTitle\tStream\t\tType\t\tStudent\n");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0],5}\t\t{reader[1]}\t{reader[2]}\t\t{reader[3]}\t{reader[4],-10}");
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
        protected internal void SelectTrainerPerCourse() 
        {
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT	Courses.CourseID, Courses.Title, Stream.Name AS Stream, Type.Name AS Type, Trainers.TrainerID, " +
                                                                    "CONCAT(Trainers.FirstName, Trainers.LastName) AS Trainers " +
                                                            "FROM Courses INNER JOIN Stream ON Courses.StreamID = Stream.StreamID " +
                                                                        "INNER JOIN TrainerPerCourse ON Courses.CourseID = TrainerPerCourse.CourseID " +
                                                                        "INNER JOIN Trainers ON TrainerPerCourse.TrainerID = Trainers.TrainerID " +
                                                                        "INNER JOIN Type ON Courses.TypeID = Type.TypeID", connection))
                {
                    SqlDataReader reader = null;
                    try
                    {
                        reader = command.ExecuteReader();
                        if (reader != null)
                        {
                            Console.WriteLine($"Course ID\tTitle\tStream\t\tType\t\tTrainerID\tTrainer\n");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0],5}\t\t{reader[1]}\t{reader[2]}\t\t{reader[3]}\t{reader[4],5}\t\t{reader[5],-10}");
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
        protected internal void SelectAssignmentPerCourse() 
        {
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT	Courses.Title AS Title, Stream.Name AS Stream, Type.Name AS Type, Assignments.Title AS [Assignment Title], Assignments.Description, " +
                                                            "AssignmentsPerCourse.Orall_Mark,AssignmentsPerCourse.Total_Mark,AssignmentsPerCourse.Sub_Date " +
                                                            "FROM Assignments INNER JOIN AssignmentsPerCourse ON Assignments.AssignmentID = AssignmentsPerCourse.AssignmentID  " +
                                                            "INNER JOIN Courses ON AssignmentsPerCourse.CourseID = Courses.CourseID  " +
                                                            "INNER JOIN Stream ON Courses.StreamID = Stream.StreamID   " +
                                                            "INNER JOIN Type ON Courses.TypeID = Type.TypeID", connection))
                {
                    SqlDataReader reader = null;
                    try
                    {
                        reader = command.ExecuteReader();
                        if (reader != null)
                        {
                            Console.WriteLine($"Title\tStream\tType\t\tAssignment Title\tDescription\tOral Mark\tTotal Mark\t Sub date\n");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0],5}\t{reader[1]}\t{reader[2]}\t{reader[3]}\t{reader[4],-10}\t{reader[5]}\t{reader[6]}\t{reader[7]}");
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
        protected internal void SelectAssignmentPerCoursePerStudent()
        {
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT	CONCAT(Students.FirstName, Students.LastName) AS Students, Courses.Title, Type.Name, Stream.Name AS Stream, " + 
                                                                    "Assignments.Title AS[Assignment Title], Assignments.Description, AssignmentsPerCourse.Sub_Date, " +
                                                                    "AssignmentsPerCourse.Orall_Mark, AssignmentsPerCourse.Total_Mark " +
                                                            "FROM Assignments INNER JOIN AssignmentsPerCourse ON Assignments.AssignmentID = AssignmentsPerCourse.AssignmentID " +
                                                                    "INNER JOIN Courses ON AssignmentsPerCourse.CourseID = Courses.CourseID " +
                                                                    "INNER JOIN Stream ON Courses.StreamID = Stream.StreamID " +
                                                                    "INNER JOIN StudentsPerCourse ON Courses.CourseID = StudentsPerCourse.CourseID " +
                                                                    "INNER JOIN Students ON StudentsPerCourse.StudentID = Students.StudentID " +
                                                                    "INNER JOIN Type ON Courses.TypeID = .Type.TypeID", connection))
                {
                    SqlDataReader reader = null;
                    try
                    {
                        reader = command.ExecuteReader();
                        if (reader != null)
                        {
                            Console.WriteLine($"Student\tCourse Title\tType\t\tStream\t\tAssignment Title\tDescription\t Sub date\tOral Mark\tTotal Mark\n");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0],5}\t{reader[1]}\t{reader[2]}\t{reader[3]}\t{reader[4],-10}\t{reader[5]}\t{Convert.ToDateTime(reader[6]).ToString("dd/MM/yyyy HH:mm")}\t{reader[7]}\t\t{reader[8]}");
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
        protected internal void SelectStudentsWithMoreCourse() 
        {
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT StudentsPerCourse.StudentID, CONCAT(Students.FirstName, Students.LastName) AS Students, count(StudentsPerCourse.CourseID) AS [Count of other Courses] " +
                                                            "FROM StudentsPerCourse INNER JOIN Students ON StudentsPerCourse.StudentID = Students.StudentID " +
                                                            "GROUP BY StudentsPerCourse.StudentID, FirstName, LastName HAVING count(StudentsPerCourse.CourseID) > 1", connection))
                {
                    SqlDataReader reader = null;
                    try
                    {
                        reader = command.ExecuteReader();
                        if (reader != null)
                        {
                            Console.WriteLine($"Student ID\tStudent\t\t\tCount of Courses\n");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0],5}\t\t{reader[1]}\t\t{reader[2]}");
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
        protected internal void SelectTrainerWithThereStream()
        {
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = $"SELECT Trainers.TrainerID, CONCAT(FirstName,LastName) AS [Trainer Full name], Stream.Name AS Subject FROM Trainers " +
                                          $"INNER JOIN TrainerSubjects ON Trainers.TrainerID = TrainerSubjects.TrainerID " +
                                          $"INNER JOIN Stream ON TrainerSubjects.StreamID = Stream.StreamID";
                    command.Connection = connection;
                    SqlDataReader reader = null;                    
                    try
                    {
                        reader = command.ExecuteReader();
                        if (reader != null)
                        {
                            Console.WriteLine("ID\tTrainer Name\tSubject\n");
                            while (reader.Read())
                            {
                                Console.WriteLine($"{reader[0]}\t{reader[1]}\t{reader[2]}");
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

        protected internal void InputToTrainerTable(string firstName, string lastName)
        {
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string insertString = $"INSERT INTO Trainers (FirstName, LastName) " +
                                      $"VALUES ('{firstName}','{lastName}')";
                SqlCommand command = new SqlCommand(insertString, connection);
                command.ExecuteNonQuery();                               
            }
        }
        protected internal void InputToTrainerSubjectsTable(int trainerID, int streamID)
        {
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                string insertString = $"INSERT INTO TrainerSubjects VALUES ({trainerID},{streamID})";
                SqlCommand command = new SqlCommand(insertString, connection);
                command.ExecuteNonQuery();
            }
        }

        protected internal void InputToCoursesTable(string title, int streamID,int typeID, DateTime startDate, DateTime endDate)
        {
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True"; // MAYBE I SHOULD MAKE IT AS A METHODE
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                SqlCommand command = new SqlCommand();
                connection.Open();

                command.CommandText = $"INSERT INTO Courses VALUES('{title}','{streamID}','{typeID}','{startDate.ToString("yyyy-MM-dd")}','{endDate.ToString("yyyy-MM-dd")}')";
                command.Connection = connection;
                command.ExecuteNonQuery();
            }
        }
        protected internal void InputToStudentPerCourseTable(int courseID, int studentID)
        {
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.CommandText = $"INSERT INTO StudentsPerCourse VALUES ({courseID},{studentID})";
                    command.Connection = connection;
                    command.ExecuteNonQuery();
                }
            }
        }
        protected internal void InputToAssignmentPerCourseTable(int assignmentID, DateTime sub_Date, decimal orall_Mark, decimal total_Mark, int courseID)
        {
            string connectionStr = "Server =.; Database = Individual_Project_PART_B; Trusted_Connection = True";
            using (SqlConnection connection = new SqlConnection(connectionStr))
            {
                
                string strOrall = orall_Mark.ToString().Replace(',', '.');
                string strTotal = total_Mark.ToString().Replace(',', '.');

                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {

                    command.CommandText = $"INSERT INTO AssignmentsPerCourse (AssignmentID, Sub_Date, Orall_Mark, Total_Mark, CourseID) " +
                                          $"VALUES('{assignmentID.ToString()}', '{sub_Date.ToString("yyyy-MM-dd HH:mm:ss")}', {strOrall}, {strTotal},'{courseID.ToString()}')";                    
                    command.Connection = connection;
                    command.ExecuteNonQuery();                    
                }
            }
        }
        
    }
}
