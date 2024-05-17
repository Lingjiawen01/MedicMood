using Microsoft.Maui.Controls;
using Plugin.Maui.Calendar.Models;
using System;
using System.Collections.Generic;

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
            LoadEvents();
            BindingContext = this;
        }

        public calender(string selectedEmoji)
        {
            this.selectedEmoji = selectedEmoji;
        }

        private void LoadEvents()
        {
            var currentDate = DateTime.Now.Date;
            Events[currentDate] = new List<EventModel>
            {
                new EventModel
                {
                    Name = $"Mood: {selectedEmoji}",
                    Description = moodNote
                }
            };
        }
    }

    public class EventModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
