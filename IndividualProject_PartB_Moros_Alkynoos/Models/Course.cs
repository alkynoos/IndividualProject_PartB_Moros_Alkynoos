using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject_PartB_Moros_Alkynoos.Models
{
    class Course
    {
        private int _titlenumber;
        private string _stream;
        private string _type;
        private DateTime _start_date;
        private DateTime _end_date;
        public Course()
        {

        }
        public Course(int TitleNumber, string Stream, string Type, DateTime Start_Date, DateTime End_Date)
        {
            this._titlenumber = TitleNumber;
            this._stream = Stream;
            this._type = Type;
            this._start_date = Start_Date;
            this._end_date = End_Date;

        }

        public int TitleNumber
        {
            get { return (this._titlenumber); }
            set { this._titlenumber = value; }
        }
        public string Stream
        {
            get { return (this._stream); }
            set { this._stream = value; }
        }
        public string Type
        {
            get { return (this._type); }
            set { this._type = value; }
        }
        public DateTime Start_Date
        {
            get { return (this._start_date); }
            set { this._start_date = value; }
        }
        public DateTime End_Date
        {
            get { return (this._end_date); }
            set { this._end_date = value; }
        }

        public override string ToString()
        {
            return ($"Course Title: CB{_titlenumber} {_stream} {_type}" +
                    $"\tStream: {_stream}" +
                    $"\tType: {_type}" +
                    $"\tStart Date: {_start_date.ToString("dd/MM/yyyy")}" +
                    $"\tEnd Date: {_end_date.ToString("dd/MM/yyyy")}");
        }
    }
}
