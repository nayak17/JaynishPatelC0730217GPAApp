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
    class StudentList : BaseAdapter<Student>
    {
        Activity activity;
        List<Student> studentlist;
        
        public StudentList(Activity context, List<Student> student)
        {
            this.activity = context;
            this.studentlist = student;
        }

        public override Student this[int position]
        {
            get { return studentlist[position]; }
        }

        //Fill in cound here, currently 0
        public override int Count
        {
            get {
                return studentlist.Count;
            }
        }
        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int index, View convertView, ViewGroup parent)
        {
            Student stu = studentlist[index];
            View studentView = convertView;

            if (studentView == null)
            {
                studentView = activity.LayoutInflater.Inflate(Resource.Layout.StudentList, null);
            }

            studentView.FindViewById<TextView>(Resource.Id.studentinfo).Text = stu.fname + " " + stu.lname + " (" + stu.id + ")";
            studentView.FindViewById<TextView>(Resource.Id.studentgpa).Text = stu.gpa;
            
            return studentView;
        }

    }

    class StudentListViewHolder : Java.Lang.Object
    {
        //Your adapter views to re-use
        //public TextView Title { get; set; }
    }
}