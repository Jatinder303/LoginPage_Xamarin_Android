using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LoginPage_Xamarin_Android.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace LoginPage_Xamarin_Android
{
    public class DatabaseManager
    {
        public static void FetchLogin(string Username_para)
        {
            try
            {
                // Define the object of student class and pass the values of the parameters to object variables.
                Login Login_Obj = new Login
                {
                    Username = Username_para
                };
                var httpClient = new HttpClient();
                var Json = JsonConvert.SerializeObject(Login_Obj);
                HttpContent httpContent = new StringContent(Json);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/Json");
                var response = httpClient.GetAsync(string.Format("http://10.0.2.2:58471/api/Logins/{0}", Login_Obj));
                Console.WriteLine(response);
            }
            catch (Exception e)
            {
                Console.WriteLine("Update student Data Error " + e.Message);
            }
        }
    }
}
