using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject_PartB_Moros_Alkynoos.Models
{
    class Assignment
    {
        private string _assignmentStream;
        private string _assignmentType;
        private string _title;
        private string _description;
        private DateTime _subdatetime;
        private decimal _oralmark;
        private decimal _totalmark;

        public Assignment()
        {

        }

        public Assignment(string AssignmentStream, string AssignmentType, string Title, string Description, DateTime SubDateTime, decimal OralMark, decimal TotalMark)
        {
            this._assignmentStream = AssignmentStream;
            this._assignmentType = AssignmentType;
            this._title = Title;
            this._description = Description;
            this._subdatetime = SubDateTime;
            this._oralmark = OralMark;
            this._totalmark = TotalMark;
        }




        public string AssignmentType
        {
            get { return (this._assignmentType); }
            set { this._assignmentType = value; }
        }

        public string AssignmentStream
        {
            get { return (this._assignmentStream); }
            set { this._assignmentStream = value; }
        }

        public string Title
        {
            get { return (this._title); }
            set { this._title = value; }
        }

        public string Description
        {
            get { return (this._description); }
            set { this._description = value; }
        }

        public DateTime SubDateTime
        {
            get { return (this._subdatetime); }
            set { this._subdatetime = value; }
        }

        public decimal OralMark
        {
            get { return (this._oralmark); }
            set { this._oralmark = value; }
        }
        public decimal TotalMark
        {
            get { return (this._totalmark); }
            set { this._totalmark = value; }
        }

        public override string ToString()
        {
            return ($"Assignment Stream: {_assignmentStream} {_assignmentType}" +
                    $"\tTitle: {_title}" +
                    $"\tDescription: {_description}" +
                    $"\tSubmission Date & Time: {_subdatetime.ToString("dd/MM/yyyy HH:mm")}" +
                    $"\tOral Mark: {_oralmark.ToString("0.00")}\tTotal Mark: {_totalmark.ToString("0.00")}");
        }
    }
}
