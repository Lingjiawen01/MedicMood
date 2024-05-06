using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System.Collections.Generic;

namespace MedicMood.Views
{
    public partial class Clockpage : ContentPage
    {
        private Database database;
        private Alarm selectedAlarm;

        public Clockpage(Database db)
        {
            InitializeComponent();
            database = db;
            LoadAlarms();
        }

        private void LoadAlarms()
        {
            if (database != null)
            {
                var alarms = database.GetAlarms();
                alarmListView.ItemsSource = alarms;
            }
            else
            {
                // 清空现有的闹钟列表
                alarmListView.ItemsSource = null;

                // 在页面中显示一个消息或提示用户添加闹钟的按钮
                // 这里仅显示一个提示消息，您可以根据需要进行修改
                DisplayAlert("Error", "Database is not initialized.", "OK");
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LoadAlarms(); // 当页面显示时重新加载闹钟列表
        }

        private async void OnButtonClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddPage(database));
        }

        private void OnAlarmItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            selectedAlarm = e.SelectedItem as Alarm;
        }
    }
}