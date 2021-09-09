using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using LoginPage_Xamarin_Android.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace LoginPage_Xamarin_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText Username_Obj;
        EditText Password_Obj;
        Button btn_Login;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            Username_Obj = FindViewById<EditText>(Resource.Id.txtUsername);
            Password_Obj = FindViewById<EditText>(Resource.Id.txtPassword);
            btn_Login = FindViewById<Button>(Resource.Id.btnLogin);
           
            btn_Login.Click += Login_Fun;
        }

        private void Login_Fun(object sender, EventArgs e)
        {
       
            
            //Toast.MakeText(this, Username_Obj.Text, ToastLength.Long).Show();
            HttpClient client = new HttpClient();
            var response = client.GetStringAsync(string.Format("http://10.0.2.2:58471/api/Logins?id=Jatinder&password=Jatinder123"));
            Toast.MakeText(this, response.Result, ToastLength.Long).Show();


            //DatabaseManager.FetchLogin(Username_Obj.Text);
            /*  if (Username_Obj.Text == "****@gmail.com" && Password_Obj.Text == "12345")
              {
                  Toast.MakeText(this, "Login successfully done!", ToastLength.Long).Show();
                  StartActivity(typeof(Dashboard));
              }
              else
              {
                  //Toast.makeText(getActivity(), "Wrong credentials found!", Toast.LENGTH_LONG).show();  
                  Toast.MakeText(this, "Wrong credentials found!", ToastLength.Long).Show();
              }*/

            /*if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
           {
               Toast.MakeText(this, "Login successfully done!", ToastLength.Long).Show();
               StartActivity(typeof(Dashboard));
           }
           else
           {
               Toast.MakeText(this, "Wrong credentials found!", ToastLength.Long).Show();
           }*/
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}