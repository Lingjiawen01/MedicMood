using System;
using Microsoft.Maui.Controls;

namespace MedicMood.Views
{
    public partial class Dashboard : ContentPage
    {
        public Dashboard()
        {
            InitializeComponent();
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

            // Subscribe to the CalendarUpdated event of the calender page
            calendarPage.CalendarUpdated += CalenderPage_CalendarUpdated;

            // Set the content of the Dashboard page to the content of the calender page
            Content = calendarPage.Content;
        }

        private void CalenderPage_CalendarUpdated(object sender, EventArgs e)
        {
            // Retrieve the necessary parameters again (or any updated data) from the calender page
            string updatedMedicineName = "UpdatedMedicineName";
            string updatedSelectedEmoji = "UpdatedSelectedEmoji";

            // Create a new instance of the calender page with the updated parameters
            var updatedCalendarPage = new calender(updatedMedicineName, updatedSelectedEmoji);

            // Update the content of the Dashboard page to the updated content of the calender page
            Content = updatedCalendarPage.Content;
        }
    }
}
