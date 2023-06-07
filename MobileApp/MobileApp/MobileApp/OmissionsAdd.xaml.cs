using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OmissionsAdd : ContentPage
    {
        public Student _student { get; set; }
        public StudentOmissions _studentOmissions { get; set; } = new StudentOmissions();
        public OmissionsAdd(Student student)
        {
            InitializeComponent();

            _student = student;
            _studentOmissions.IdStudent = student.Id;
            BindingContext = this;

            test.Text= _student.Name;
        }

        private void Save_Clicked(object sender, EventArgs e) 
        {
            try
            {
                var client = new WebClient();
                client.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                var result = client.UploadString("http://192.168.0.122/WebCollege/api/Tests", JsonConvert.SerializeObject(_studentOmissions));
                Navigation.PushAsync(new Omissions());
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}