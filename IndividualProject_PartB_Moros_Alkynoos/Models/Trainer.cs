using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndividualProject_PartB_Moros_Alkynoos.Models
{
    class Trainer
    {
        private string _firstname; 
        private string _lastname;
        private string _subject;

        public Trainer()
        {

        }

        public Trainer(string FirstName, string LastName, string Subject)
        {
            this._firstname = FirstName;
            this._lastname = LastName;
            this._subject = Subject;
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

        public string Subject
        {
            get { return (this._subject); }
            set { this._subject = value; }
        }

        public override string ToString()
        {
            return ($"First Name: {_firstname}\tLast Name: {_lastname}\tSubject: {_subject}");
        }
    }
}
