using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace MedicMood.Views
{
    public partial class ReminderPage : ContentPage
    {
        private Alarm alarm;

        public ReminderPage(Alarm alarm)
        {
            InitializeComponent();
            this.alarm = alarm;
            medicineNameLabel.Text = alarm.Note;  // Display medicine name
        }

        private async void DismissButton_Clicked(object sender, EventArgs e)
        {
            // Update alarm status in the database
            var database = await Database.CreateInstanceAsync();
            database.UpdateAlarm(alarm);

            // Navigate to Mood page and pass alarm.Note
            await Navigation.PushAsync(new Mood(alarm.Note));
        }

        private async void SnoozeButton_Clicked(object sender, EventArgs e)
        {
            // Update alarm status to stop ringing
            alarm.IsRinging = false;
            var database = await Database.CreateInstanceAsync();
            database.UpdateAlarm(alarm);

            // Navigate to AddPage to reset the alarm and pass the database instance
            await Navigation.PushAsync(new AddPage(database));
        }
    }
}
