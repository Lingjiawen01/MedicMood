using System;
using Microsoft.Maui.Controls;

namespace MedicMood.Views
{
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeCalender();
        }

        private void InitializeCalender()
        {
            // Retrieve the necessary parameters (e.g., medicineName and selectedEmoji)
            // You can retrieve these parameters from your data source or wherever they are stored
            string medicineName = "YourMedicineName";
            string selectedEmoji = "YourSelectedEmoji";

            // Create a new instance of the calender page with the parameters
            var calendarPage = new calender(medicineName, selectedEmoji);

            // Subscribe to the CalendarUpdated event
            calendarPage.CalendarUpdated += CalenderPage_CalendarUpdated;

            // Set the content of the Dashboard page to the content of the calender page
            Content = calendarPage.Content;
        }

        // Handle the CalendarUpdated event
        private void CalenderPage_CalendarUpdated(object sender, EventArgs e)
        {
            // This method will be called whenever the calendar is updated
            // You can update the Dashboard page accordingly
        }
    }
}
