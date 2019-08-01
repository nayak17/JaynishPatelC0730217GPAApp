using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using System.Collections.Generic;

namespace JaynishPatelC0730217GPAApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        ListView listView;
        SearchView searchView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            listView = FindViewById<ListView>(Resource.Id.listView1);
            searchView = FindViewById<SearchView>(Resource.Id.searchView1);
            var btn = FindViewById<Button>(Resource.Id.button1);
            btn.Click += delegate
            {
                Intent intent = new Intent(this, typeof(StudentInfo));
                StartActivity(intent);
            };

            var adapter = new StudentList(this, Student.students);
            listView.Adapter = adapter;
            listView.ItemClick += listItemSelected;
            searchView.QueryTextChange += searchViewQueryTextChange;
        }

        void listItemSelected(object sender, AdapterView.ItemClickEventArgs e)
        {
            Student student = Student.students[e.Position];
            Intent gpacalculation = new Intent(this, typeof(GPACalculation));
            gpacalculation.PutExtra("id", student.id);
            StartActivity(gpacalculation);
        }

        void searchViewQueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            var value = e.NewText;
            List<Student> searchList = new List<Student>();
            foreach (Student aObj in Student.students)
            {
                if (aObj.fname.ToLower().Contains(value.ToLower()))
                {
                    searchList.Add(aObj);
                }
            }
            var adapter = new StudentList(this, searchList);
            listView.SetAdapter(adapter);
        }

        protected override void OnRestart()
        {
            base.OnRestart();
            //var adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, Student.students);
            var adapter = new StudentList(this, Student.students);
            listView.Adapter = adapter;
        }

        protected override void OnResume()
        {
            base.OnResume();
            var adapter = new StudentList(this, Student.students);
            listView.Adapter = adapter;
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}