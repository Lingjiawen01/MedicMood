using System;
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
            medicineNameLabel.Text = alarm.Note;  // 显示药品名称
        }

        private async void DismissButton_Clicked(object sender, EventArgs e)
        {
            // Update alarm status in the database
            var database = await Database.CreateInstanceAsync();
            database.UpdateAlarm(alarm);

            await Navigation.PushAsync(new Mood());
        }

        private async void SnoozeButton_Clicked(object sender, EventArgs e)
        {
            alarm.IsRinging = false;

            // 更新数据库中的闹钟状态
            var database = await Database.CreateInstanceAsync();
            database.UpdateAlarm(alarm);

            await Task.Delay(TimeSpan.FromMinutes(5)); // 等待5分钟

            alarm.IsRinging = true; // 重新响起闹钟
            database.UpdateAlarm(alarm); // 更新数据库中的闹钟状态
        }
    }
}
