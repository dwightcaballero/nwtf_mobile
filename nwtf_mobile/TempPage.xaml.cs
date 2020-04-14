using Newtonsoft.Json;
using nwtf_mobile_bl;
using System.Collections.Generic;
using System.Net.Http;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace nwtf_mobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TempPage : ContentPage
    {
        public TempPage()
        {
            InitializeComponent();
            GetRegistry();
        }

        public async void GetRegistry()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetStringAsync("https://10.5.4.71:44358/api/vwRegistries1");
            var reg = JsonConvert.DeserializeObject<List<views.vwRegistry>>(response);
            lblEntry.Text = reg[0].entry;
        }
    }
}