using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject_PartB_Moros_Alkynoos.Models
{
    class Student
    {
        private string _firstname;
        private string _lastname;
        private DateTime _dateofbirth;
        private string _studentStream;
        private string _streamType;
        private decimal _tuitionfees;

        public Student()
        {

        }
        public Student(string FirstName, string LastName, DateTime DateOfBirth, string StudentStream, string StreamType, decimal TuitionFees)
        {
            this._firstname = FirstName;
            this._lastname = LastName;
            this._dateofbirth = DateOfBirth;
            this._studentStream = StudentStream;
            this._streamType = StreamType;
            this._tuitionfees = TuitionFees;
        }

        public string FirstName
        {
            get { return (this._firstname); }
            set { this._firstname = value; }
        }

        public string LastName
        {
            get { return (this._lastname); }
            set { this._lastname = value; }
        }

        public DateTime DateOfBirth
        {
            get { return (this._dateofbirth); }
            set { this._dateofbirth = value; }
        }


        public string StudentStream
        {
            get { return (this._studentStream); }
            set { this._studentStream = value; }
        }


        public string StreamType
        {
            get { return (this._streamType); }
            set { this._streamType = value; }
        }

        public decimal TuitionFees
        {
            get { return (this._tuitionfees); }
            set { this._tuitionfees = value; }
        }




        public override string ToString()
        {
            return ($"First Name: {_firstname}" +
                    $"\tLast Name: {_lastname}" +
                    $"\tDate of Berth: {_dateofbirth.ToString("yyyy-MM-dd")}" +
                    $"\tCourse: {_studentStream} {_streamType}" +
                    $"\tTuition Fees: {_tuitionfees}");
        }
    }
}
