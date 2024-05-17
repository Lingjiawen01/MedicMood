using Microsoft.Maui.Controls;
using System;

namespace MedicMood.Views
{
    public partial class Clockpage : ContentPage
    {
        private Database database;
        private Alarm selectedAlarm;
        private List<Alarm> alarms;

        public Clockpage()
        {
            InitializeComponent();
            InitializeDatabase();
            StartTimerToUpdateTime();
        }

        private async void InitializeDatabase()
        {
            database = await Database.CreateInstanceAsync();
            LoadAlarms();
        }

        private void LoadAlarms()
        {
            if (database != null)
            {
                alarms = database.GetAlarms(); // 将获取到的闹钟赋值给 alarms
                alarmListView.ItemsSource = database.GetAlarms();
            }
            else
            {
                DisplayAlert("Error", "Database is not initialized.", "OK");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadAlarms();
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage(database));
        }
        private void OnAlarmItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedAlarm = e.SelectedItem as Alarm;
        }

        private async void DeletButton(object sender, EventArgs e)
        {
            if (selectedAlarm != null)
            {
                bool result = await DisplayAlert("Confirm", "Are you sure you want to delete this alarm?", "Yes", "No");
                if (result)
                {
                    database.DeleteAlarm(selectedAlarm.Id);
                    LoadAlarms(); // 刷新列表
                }
            }
            else
            {
                await DisplayAlert("Error", "No alarm selected.", "OK");
            }
        }

        [Obsolete]
        private void StartTimerToUpdateTime()
        {
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                var currentTime = DateTime.Now;
                foreach (var alarm in alarms)
                {
                    if (!alarm.IsRinging && alarm.Time.Hour == currentTime.Hour && alarm.Time.Minute == currentTime.Minute)
                    {
                        alarm.IsRinging = true;
                        ShowReminderPage(alarm);
                    }
                }
                // 更新手机时间
                Device.BeginInvokeOnMainThread(() =>
                {
                    // 设置 Label 的文本为当前手机时间
                    currentTimeLabel.Text = currentTime.ToString("HH:mm:ss");
                });
                // 返回 true 以继续循环
                return true;
            });
        }


        private async void ShowReminderPage(Alarm alarm)
        {
            await Navigation.PushAsync(new ReminderPage(alarm));
        }

    }
}