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

namespace ZoomCar
{
    [Activity(Label = "rating")]
    public class rating : Activity
    {

        int count = 1;
        SeekBar test1, test2, test3;
        TextView vTest1, vTest2, vTest3, vTotal;
        Button ok, calcu, ratingg;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.rating);
            test1 = FindViewById<SeekBar>(Resource.Id.sb1);
            test2 = FindViewById<SeekBar>(Resource.Id.sb2);
            test3 = FindViewById<SeekBar>(Resource.Id.sb3);

            vTest1 = FindViewById<TextView>(Resource.Id.tv1);
            vTest2 = FindViewById<TextView>(Resource.Id.tv2);
            vTest3 = FindViewById<TextView>(Resource.Id.tv3);
            vTotal = FindViewById<TextView>(Resource.Id.tvTotal);

            ok = FindViewById<Button>(Resource.Id.button1);
            calcu = FindViewById<Button>(Resource.Id.calc);
            ratingg = FindViewById<Button>(Resource.Id.rating);

            calcu.Click += Calcu_Click;
            ratingg.Click += Rating_Click;


            test1.ProgressChanged += delegate {
                vTest1.Text = "$"+ test1.Progress.ToString();

            };

            test2.ProgressChanged += delegate {
                vTest2.Text = "$"+test2.Progress.ToString();

            };

            test3.ProgressChanged += delegate {
                vTest3.Text = "$"+test3.Progress.ToString();

            };

            ok.Click += delegate {

                double t = test1.Progress + test2.Progress + test3.Progress;
                vTotal.Text = "Total insurance increment: $"+t.ToString();
            };

        }
        private void Rating_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(rating));
            StartActivity(i);
        }

        private void Calcu_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(calc));
            StartActivity(i);

        }


    }
}