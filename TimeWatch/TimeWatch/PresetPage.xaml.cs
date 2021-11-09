using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeWatch.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TimeWatch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PresentPage : ContentPage
    {
        public PresentPage()
        {
            InitializeComponent();

            List<Preset> presets = new List<Preset>
            {
                new Preset
                {
                    Name = "[20/10X8+60]6",
                    Work = 20,
                    Rest = 10,
                    Reps = 8,
                    Recovery = 60
                },
                new Preset
                {
                    Name = "[4/1]4",
                    Work = 60,
                    Rest = 60,
                    Reps = 4
                },
                new Preset
                {
                    Name = "[EMOTM]",
                    Work = 60,
                    Reps = 15,
                },
            };

            PresetList.ItemsSource = presets;
        }


        private async void PresetList_OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            var preset = e.Item as Preset;
            await Navigation.PushAsync(new ClockPage(preset));
            
            PresetList.SelectedItem = null;
        }
    }
}