using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using TimeWatch.Models;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace TimeWatch
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClockPage : ContentPage
    {
        private TimeSpan _defaultTime;
        private Boolean _running = false;
        public ClockPage(Preset preset)
        {
            InitializeComponent();
            _defaultTime = new TimeSpan(0, 0, (int)preset.Work);
            Countdown.Text = $"{_defaultTime:mm\\:ss}";
            PresetName.Text = preset.Name;
            StartButton.Text = "Start";
        }

        private void CheckTimer()
        {
            Countdown.Text = $"{_defaultTime:mm\\:ss}";
            Device.StartTimer(new TimeSpan(0, 0, 1), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    _defaultTime = _defaultTime - new TimeSpan(0, 0, 1);
                    Countdown.Text = $"{_defaultTime:mm\\:ss}";
                    
                });
                return _running;
            });
        }

        private void Play_Button_OnClicked(object sender, EventArgs e)
        {
            if (_running)
            {
                StartButton.Text = "Stop";
                _running = false;
                CheckTimer();
            }
            else
            {
                StartButton.Text = "Start";
                _running = true;
                CheckTimer();

            }
        }
    }
}