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
    [Activity(Label = "StudentInfo")]
    public class StudentInfo : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.StudentInfo);
            // Create your application here

            var fname = FindViewById<EditText>(Resource.Id.fname);
            var lname = FindViewById<EditText>(Resource.Id.lname);
            var id = FindViewById<EditText>(Resource.Id.id);
            var btn = FindViewById<Button>(Resource.Id.button1);

            btn.Click += delegate
            {
                if (!string.IsNullOrEmpty(fname.Text) && !string.IsNullOrEmpty(lname.Text) && !string.IsNullOrEmpty(id.Text))
                {
                    Android.App.AlertDialog.Builder dialog = new Android.App.AlertDialog.Builder(this);
                    Android.App.AlertDialog alert = dialog.Create();
                    alert.SetTitle("Add Student");
                    alert.SetMessage("Are you sure?");
                    alert.SetButton("Yes, I'm Sure!", (c, ev) => {
                        Student student = new Student(fname.Text, lname.Text, id.Text, "Pending");
                        Student.students.Add(student);
                        fname.Text = "";
                        lname.Text = "";
                        id.Text = "";
                        Toast.MakeText(this, student.fname + " is now a student.", ToastLength.Short).Show();
                    });
                    alert.SetButton2("No Way!", (c, ev) => {
                        // Don't delete the content of the fields
                    });
                    alert.Show();

                    
                } else {
                    Toast.MakeText(this, "Fields should not be empty. Please fill all the details.", ToastLength.Short).Show();
                }
            };
        }
    }
}