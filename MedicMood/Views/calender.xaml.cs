using System;
using Microsoft.Maui.Controls;
using Plugin.Maui.Calendar.Models;

namespace MedicMood.Views
{
    public partial class calender : ContentPage
    {
        public EventCollection Events { get; set; }
        private string moodNote;
        private string selectedEmoji;

        public calender(string moodNote, string selectedEmoji)
        {
            InitializeComponent();
            this.moodNote = moodNote;
            this.selectedEmoji = selectedEmoji;
            Events = new EventCollection();
            BindingContext = this;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadEvents();
        }

        // Method to set the moodNote and selectedEmoji values
        public void SetMood(string moodNote, string selectedEmoji)
        {
            this.moodNote = moodNote;
            this.selectedEmoji = selectedEmoji;
        }

        private void LoadEvents()
        {
            // Clear existing events
            Events.Clear();

            // Get the current date
            var currentDate = DateTime.Now.Date;

            // Create an event for today with stored moodNote and selectedEmoji values
            Events[currentDate] = new List<EventModel>
            {
                new EventModel
                {
                    Name = $"Mood: {selectedEmoji}",
                    Description = moodNote
                }
            };
        }

        // Define the CalendarUpdated event
        public event EventHandler<EventArgs> CalendarUpdated;

        // Call this method whenever the calendar is updated
        private void OnCalendarUpdated()
        {
            CalendarUpdated?.Invoke(this, EventArgs.Empty);
        }

    }

    public class EventModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
