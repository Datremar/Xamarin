using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;

namespace App4
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private TextView textView1;
        private int n = 0;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);


            textView1 = FindViewById<TextView>(Resource.Id.textView1);
            textView1.Text = n.ToString();

            try
            {
                FindViewById<Button>(Resource.Id.button2).Click += (o, e) =>
                textView1.Text = (++n).ToString();
            }
            catch (OverflowException)
            {
                n = int.MinValue;
            }

            try
            {
                FindViewById<Button>(Resource.Id.button1).Click += (o, e) =>
                textView1.Text = (--n).ToString();
            }
            catch (OverflowException)
            {
                n = int.MaxValue;
            }
        }
    }
}