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
    [Activity(Label = "calc")]
    public class calc : Activity
    {
        EditText quantity;
        Button btn1, calcu, rating;
        private List<KeyValuePair<string, string>> planets;
        string price = "";
        int acc = 100;
        int kit = 50;
        CheckBox check;
        RadioGroup radio;
        RadioButton radioa;
        RadioButton radiob;

        Android.App.AlertDialog.Builder myAlert;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.calc);

            planets = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Honda Civic", "55"),
                new KeyValuePair<string, string>("BMW", "85"),
                new KeyValuePair<string, string>("Audi", "80"),
                new KeyValuePair<string, string>("Camry", "65"),
                new KeyValuePair<string, string>("Malibu" , "60")
            };

            List<string> planetNames = new List<string>();
            foreach (var item in planets)
                planetNames.Add(item.Key);



            Spinner spinner = FindViewById<Spinner>(Resource.Id.spinner);
            var adapter = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, planetNames);
            spinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;

            quantity = FindViewById<EditText>(Resource.Id.edit1);
            myAlert = new Android.App.AlertDialog.Builder(this);

            btn1 = FindViewById<Button>(Resource.Id.button1);
            calcu = FindViewById<Button>(Resource.Id.calc);
            rating = FindViewById<Button>(Resource.Id.rating);
            check = FindViewById<CheckBox>(Resource.Id.checkBox2);             radioa = FindViewById<RadioButton>(Resource.Id.radio1);
            radiob = FindViewById<RadioButton>(Resource.Id.radio2);  

            btn1.Click += Btn1_Click;
            calcu.Click += Calcu_Click;
            rating.Click += Rating_Click;

        }
        private void errorMessageDialog(string msg)
        {
            myAlert.SetTitle("Error");
            myAlert.SetMessage("Please select number of " + msg);
            myAlert.SetPositiveButton("OK", OkAction);
            Dialog myDialog = myAlert.Create();
            myDialog.Show();
        }

        private void OkAction(object sender, DialogClickEventArgs e)
        {
            System.Console.WriteLine("Ok button is clicked.");
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

        private void Btn1_Click(object sender, EventArgs e)
        {
            var quantituv = quantity.Text;

            if (quantituv == " " || quantituv.Equals(""))
            {
                errorMessageDialog("days");
            }
            
            
            else {
                if (check.Checked && radioa.Checked)
                {
                    FindViewById<TextView>(Resource.Id.textView1).Text = "Total amount is: " + (kit + acc + Convert.ToInt32(price) * Convert.ToInt32(quantity.Text)).ToString();
                }
                else if (check.Checked)
                {
                   FindViewById<TextView>(Resource.Id.textView1).Text = "Total amount is: " + (acc + Convert.ToInt32(price) * Convert.ToInt32(quantity.Text)).ToString();
                    }
                    else
                    
                        if (radiob.Checked)
                {
                    FindViewById<TextView>(Resource.Id.textView1).Text = "Total amount is: " + ( Convert.ToInt32(price) * Convert.ToInt32(quantity.Text)).ToString();
                        }

                        else
                        
                            if (radioa.Checked)
                {
                    FindViewById<TextView>(Resource.Id.textView1).Text = "Total amount is: " + (kit + Convert.ToInt32(price) * Convert.ToInt32(quantity.Text)).ToString();
                            }
                            else
                                FindViewById<TextView>(Resource.Id.textView1).Text = "Total amount is: " + (Convert.ToInt32(price) * Convert.ToInt32(quantity.Text)).ToString();
                        }
                    
                
            
        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            FindViewById<TextView>(Resource.Id.textView2).Text = "For car " + spinner.GetItemAtPosition(e.Position).ToString() + " per day(s) is $" + planets[e.Position].Value;

            price = planets[e.Position].Value;

            string toast = string.Format("Selected car is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(this, toast, ToastLength.Long).Show();


        }
    }
}