using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace JaynishPatelC0730217GPAApp
{
    public class Student
    {
        public string fname;
        public string lname;
        public string id;
        public string gpa;
        public Student(string fname, string lname, string id, string marks)
        {
            this.fname = fname;
            this.lname = lname;
            this.id = id;
            this.gpa = marks;
        }
        public static List<Student> students = new List<Student>();

        public override string ToString()
        {
            var output = fname + "\n" + lname + "\n" + id;
            return output;
        }
    }
}