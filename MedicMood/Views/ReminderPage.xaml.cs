using System;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Views;
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

        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Ensure the media element starts playing when the page appears
            mediaElement.Play();
        }

        private async void DismissButton_Clicked(object sender, EventArgs e)
        {
            // Update alarm status in the database
            var database = await Database.CreateInstanceAsync();
            database.UpdateAlarm(alarm);
            mediaElement.Stop();

            // Navigate to Mood page and pass alarm.Note
            await Navigation.PushAsync(new Mood(alarm.Note));
        }

        private async void SnoozeButton_Clicked(object sender, EventArgs e)
        {
            // Update alarm status to stop ringing
            alarm.IsActive = false;
            var database = await Database.CreateInstanceAsync();
            database.UpdateAlarm(alarm);
            mediaElement.Stop();

            // Navigate to AddPage to reset the alarm and pass the database instance
            await Navigation.PushAsync(new AddPage(database));
        }
    }
}
