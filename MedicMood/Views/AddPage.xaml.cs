using System;
using System.Diagnostics;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace MedicMood.Views
{
    public partial class AddPage : ContentPage
    {
        private Database database;
        private Alarm selectedAlarm;
        private DateTime startDate;
        private DateTime endDate;

        public DateTime StartDate
        {
            get => startDate;
            set
            {
                startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }
        public DateTime EndDate
        {
            get => endDate;
            set
            {
                endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }


        public AddPage(Database db)
        {
            InitializeComponent();
            database = db;
            StartDate = DateTime.Today; // 默认起始日期为今天
            EndDate = DateTime.Today; // 默认结束日期为今天
        }

        private async void SetAlarmButton_Clicked(object sender, EventArgs e)
        {
            Alarm alarm = new Alarm
            {
                Label = "Your Label",
                StartTime = StartDate,
                EndTime = EndDate,
                IsActive = workSwitch.IsToggled,
                MedicineNote = noteEditor.Text
            };

            database.AddAlarm(alarm);

            // 设置成功
            await DisplayAlert("Success", "Alarm set successfully.", "OK");

            await Navigation.PopAsync();
        }


        private async void DeleteAlarmButton_Clicked(object sender, EventArgs e)
        {
            if (selectedAlarm != null)
            {
                // 从数据库中删除选定的闹钟
                database.DeleteAlarm(selectedAlarm.Id);

                // 显示删除成功的提示消息
                await DisplayAlert("Success", "Alarm deleted successfully.", "OK");

                // 返回上一页
                await Navigation.PopAsync();
            }
            else
            {
                // 如果没有选定的闹钟，则显示错误消息
                await DisplayAlert("Error", "No alarm selected.", "OK");
            }
        }
    }
}