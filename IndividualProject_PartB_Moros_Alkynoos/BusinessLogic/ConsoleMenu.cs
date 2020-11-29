using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject_PartB_Moros_Alkynoos.BusinessLogic
{
    class ConsoleMenu
    {
        protected internal static void Menu()
        {
            Console.WriteLine("Welcome to the Private Shoole Menu!!");
            Console.WriteLine("Choose from the action below: ");
            Console.WriteLine("1) SQL queries execution menu.");
            Console.WriteLine("2) Input date to database.");

            ConsoleKeyInfo menuSelection;
            menuSelection = Console.ReadKey(true);

            switch (menuSelection.KeyChar)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("SQL queries execution menu:");
                    SqlQueries();
                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine("Input data to database menu:");
                    InputToDatabase();
                    break;
                default:
                    Console.Clear();
                    Menu();
                    break;
            }


        }

        protected internal static void SqlQueries()
        {
            Console.Clear();
            Console.WriteLine("Choose Action: ");
            Console.WriteLine("1) Select * From Students.");
            Console.WriteLine("2) Select * From Trainers.");
            Console.WriteLine("3) Select * From Assignments.");
            Console.WriteLine("4) Select * From Courses.");
            Console.WriteLine("5) Students Per Course.");
            Console.WriteLine("6) Trainers Per Course.");
            Console.WriteLine("7) Assignment Per Course.");
            Console.WriteLine("8) Assignment Per Course Per Student.");
            Console.WriteLine("9) Students that belong to more than one course.");
            Console.WriteLine("Press any other key to return to Main menu.");


            ConsoleKeyInfo menuSelection;
            menuSelection = Console.ReadKey(true);

            SQL_Utils sQL_Utils = new SQL_Utils();
            

            switch (menuSelection.KeyChar)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("Select * From Students.\n");
                    sQL_Utils.SelectStudent();
                    Console.WriteLine("\n Press Enter to return to SQL queries execution menu. ");
                    Console.ReadLine();
                    SqlQueries();
                    break;
                    case '2':
                    Console.Clear();
                    Console.WriteLine("Select * From Trainers.\n");
                    sQL_Utils.SelectTrainer();
                    Console.WriteLine("\n Press Enter to return to SQL queries execution menu. ");
                    Console.ReadLine();
                    SqlQueries();
                    break;
                    case '3':
                    Console.Clear();
                    Console.WriteLine("Select * From Assignments.\n");
                    sQL_Utils.SelectAssignment();
                    Console.WriteLine("\n Press Enter to return to SQL queries execution menu. ");
                    Console.ReadLine();
                    SqlQueries();
                    break;
                    case '4':
                    Console.Clear();
                    Console.WriteLine("Select * From Courses.\n");
                    sQL_Utils.SelectCourse();
                    Console.WriteLine("\n Press Enter to return to SQL queries execution menu. ");
                    Console.ReadLine();
                    SqlQueries();
                    break;
                    case '5':
                    Console.Clear();
                    Console.WriteLine("Students Per Course.\n");
                    sQL_Utils.SelectStudentPerCourse();
                    Console.WriteLine("\n Press Enter to return to SQL queries execution menu. ");
                    Console.ReadLine();
                    SqlQueries();
                    break;
                    case '6':
                    Console.Clear();
                    Console.WriteLine("Trainers Per Course.\n");
                    sQL_Utils.SelectTrainerPerCourse();
                    Console.WriteLine("\n Press Enter to return to SQL queries execution menu. ");
                    Console.ReadLine();
                    SqlQueries();
                    break;
                    case '7':
                    Console.Clear();
                    Console.WriteLine("Assignment Per Course.\n");
                    sQL_Utils.SelectAssignment();
                    Console.WriteLine("\n Press Enter to return to SQL queries execution menu. ");
                    Console.ReadLine();
                    SqlQueries();
                    break;
                    case '8':
                    Console.Clear();
                    Console.WriteLine("Assignment Per Course Per Student.\n");
                    sQL_Utils.SelectAssignmentPerCoursePerStudent();
                    Console.WriteLine("\n Press Enter to return to SQL queries execution menu. ");
                    Console.ReadLine();
                    SqlQueries();
                    break;
                    case '9':
                    Console.Clear();
                    Console.WriteLine("Students that belong to more than one course.\n");
                    sQL_Utils.SelectStudentsWithMoreCourse();
                    Console.WriteLine("\n Press Enter to return to SQL queries execution menu. ");
                    Console.ReadLine();
                    SqlQueries();
                    break;
                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }

        protected internal static void InputToDatabase()
        {
            Console.Clear();
            Console.WriteLine("Choose Action: ");
            Console.WriteLine("1) Input to Students.");
            Console.WriteLine("2) Input to Trainers.");
            Console.WriteLine("3) Input to Assignment.");
            Console.WriteLine("4) Input to Course.");
            Console.WriteLine("5) Input to Students per Course.");
            Console.WriteLine("6) Input to Trainer per Course.");
            Console.WriteLine("7) Input Assignmetns per Students per Course. ");
            Console.WriteLine("Press any other key to return to Main menu.");

            ConsoleKeyInfo menuSelection;
            menuSelection = Console.ReadKey(true);

           CommandPromptUtils commandPromptUtils = new CommandPromptUtils();

            switch (menuSelection.KeyChar)
            {
                case '1':
                    Console.Clear();
                    Console.WriteLine("Input to Students.\n");
                    commandPromptUtils.InputStudent();
                    Console.WriteLine("\nInput data to database menu. ");
                    Console.ReadLine();
                    InputToDatabase();
                    break;
                case '2':
                    Console.Clear();
                    Console.WriteLine("Input to Trainers.\n");
                    commandPromptUtils.InputTrainer();
                    Console.WriteLine("\nInput data to database menu. ");
                    Console.ReadLine();
                    InputToDatabase();
                    break;
                case '3':
                    Console.Clear();
                    Console.WriteLine("Input to Assignment.\n");
                    commandPromptUtils.InputAssignment();
                    Console.WriteLine("\nInput data to database menu. ");
                    Console.ReadLine();
                    InputToDatabase();
                    break;
                case '4':
                    Console.Clear();
                    Console.WriteLine("Input to Course.\n");
                    commandPromptUtils.InputCourse();
                    Console.WriteLine("\nInput data to database menu. ");
                    Console.ReadLine();
                    InputToDatabase();
                    break;
                case '5':
                    Console.Clear();
                    Console.WriteLine("Input to Students per Course.\n");
                    commandPromptUtils.InputStudentsToCourse();
                    Console.WriteLine("\nInput data to database menu. ");
                    Console.ReadLine();
                    InputToDatabase();
                    break;
                case '6':
                    Console.Clear();
                    Console.WriteLine("Input to Trainer per Course.\n");
                    commandPromptUtils.InputTrainerPerCourse();
                    Console.WriteLine("\nInput data to database menu. ");
                    Console.ReadLine();
                    InputToDatabase();
                    break;
                case '7':
                    Console.Clear();
                    Console.WriteLine("Input Assignmetns per Students per Course.\n");
                    commandPromptUtils.InputAssignmentPerStudentPerCourse();
                    Console.WriteLine("\nInput data to database menu. ");
                    Console.ReadLine();
                    InputToDatabase();
                    break;
                default:
                    Console.Clear();
                    Menu();
                    break;
            }
        }

    }
}
