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
    [Activity(Label = "GPACalculation")]
    public class GPACalculation : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.GPACalculation);
            string id = Intent.GetStringExtra("id");
            int studentindex = 0;

            var sub1 = FindViewById<EditText>(Resource.Id.sub1);
            var sub2 = FindViewById<EditText>(Resource.Id.sub2);
            var sub3 = FindViewById<EditText>(Resource.Id.sub3);
            var sub4 = FindViewById<EditText>(Resource.Id.sub4);
            var sub5 = FindViewById<EditText>(Resource.Id.sub5);
            var btn = FindViewById<Button>(Resource.Id.calculate);

            var stuinfo = FindViewById<TextView>(Resource.Id.stuinfo);
            var stuid = FindViewById<TextView>(Resource.Id.stuid);

            for(int i=0; i<Student.students.Count; i++)
            {
                if(Student.students[i].id == id)
                {
                    stuinfo.Text = Student.students[i].fname + " " + Student.students[i].lname;
                    stuid.Text = Student.students[i].id;
                    studentindex = i;
                }
            }

            btn.Click += delegate
            {
                if(string.IsNullOrEmpty(sub1.Text) || string.IsNullOrEmpty(sub2.Text) || string.IsNullOrEmpty(sub3.Text) || string.IsNullOrEmpty(sub4.Text) || string.IsNullOrEmpty(sub5.Text))
                {
                    Toast.MakeText(this, "Fields should not be empty. Please fill all the details.", ToastLength.Short).Show();
                } else
                {
                    int num1 = 0, num2 = 0, num3 = 0, num4 = 0, num5 = 0;
                    try
                    {
                        num1 = int.Parse(sub1.Text);
                        num2 = int.Parse(sub2.Text);
                        num3 = int.Parse(sub3.Text);
                        num4 = int.Parse(sub4.Text);
                        num5 = int.Parse(sub5.Text);
                    } catch(FormatException)
                    {
                        Toast.MakeText(this, "Grades should be in numbers between 0 and 100", ToastLength.Short).Show();
                        return;
                    }

                    if(num1 < 0 || num1 > 100 || num2 < 0 || num2 > 100 || num3 < 0 || num3 > 100 || num4 < 0 || num4 > 100 || num5 < 0 || num5 > 100)
                    {
                        Toast.MakeText(this, "Grades should be in numbers between 0 and 100", ToastLength.Short).Show();
                        return;
                    }
                    else
                    {
                        double totalmarks = 0;
                        totalmarks += getpoints(num1) * 3;
                        totalmarks += getpoints(num2) * 4;
                        totalmarks += getpoints(num3) * 4;
                        totalmarks += getpoints(num4) * 4;
                        totalmarks += getpoints(num5) * 2;

                        double studentgpa = totalmarks / (3 + 4 + 4 + 4 + 2);
                        Student.students[studentindex].gpa = studentgpa.ToString();
                        Finish();
                    }
                }
            };
        }       

        public double getpoints(int score)
        {
            if (score <= 100 && score > 93)
                return 4.0;     // A+

            if (score <= 93 && score > 86)
                return 3.7;     // A 

            if (score <= 86 && score > 79)
                return 3.5;     // A-

            if (score <= 79 && score > 76)
                return 3.2;     // B+

            if (score <= 76 && score > 72)
                return 3.0;     // B

            if (score <= 72 && score > 69)
                return 2.7;     // B-

            if (score <= 69 && score > 66)
                return 2.3;     // C+

            if (score <= 66 && score > 62)
                return 2.0;     // C

            if (score <= 62 && score > 59)
                return 1.7;     // C-

            if (score <= 59 && score > 49)
                return 1.0;     // D
            
            if (score <= 49)
                return 0.0;     // F

            return 0.0;         // F
        }
    }
}