using shop.TABLE;
using shop;
using Somtum;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Somtum
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registerr : ContentPage
    {
        public Registerr()
        {
            InitializeComponent();
        }
        private void enmenubutton_clicked(object sender, EventArgs e)
        {
            var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "User.db");
            var db = new SQLiteConnection(dbPath);
            db.CreateTable<LIST>();

            var item = new LIST()
            {
                Username = enUsername.Text,
                Firstname = enFirstname.Text,
                Lastname = enLastname.Text,
                Phone = enPhone.Text,
                Password = enPassword.Text   
            };

            db.Insert(item);

            if ((string.IsNullOrWhiteSpace(enUsername.Text)) || (string.IsNullOrEmpty(enUsername.Text)) ||
            (string.IsNullOrWhiteSpace(enFirstname.Text)) || (string.IsNullOrEmpty(enFirstname.Text)) ||
            (string.IsNullOrWhiteSpace(enLastname.Text)) || (string.IsNullOrEmpty(enLastname.Text)) ||
            (string.IsNullOrWhiteSpace(enPhone.Text)) || (string.IsNullOrEmpty(enPhone.Text)) ||
            (string.IsNullOrWhiteSpace(enPassword.Text)) || (string.IsNullOrEmpty(enPassword.Text)))
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Error", "Please Enter Data", "Cancel", "Yes");
                    if (result)
                    {
                        await Navigation.PushAsync(new Registerr());
                    }
                    else
                    {
                        await Navigation.PushAsync(new Registerr());
                    }
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await this.DisplayAlert("Successfull", "Registeration Successful", "Cancel", "Yes");
                    if (result)
                    {
                        App.Current.MainPage = new login();
                    }
                });

                Navigation.PushAsync(new login());
            }
        }
    }
}