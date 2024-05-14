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
        public AddPage(Database db)
        {
            InitializeComponent();
            database = db;
        }

        private async void SetAlarmButton_Clicked(object sender, EventArgs e)
        {
            DateTime alarmDateTime = alarmDatePicker.Date.Add(alarmTimePicker.Time);
            Alarm alarm = new Alarm
            {
                Label = "Your Label",
                Time = alarmDateTime,
                IsActive = workSwitch.IsToggled,
                RepeatDays = new List<DayOfWeek>() // Initialize the list
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

        private void OnRepeatDayCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            if (checkBox.IsChecked)
            {
                // 如果 CheckBox 被选中
                if (checkBox.BindingContext is string dayOfWeek)
                {
                    switch (dayOfWeek)
                    {
                        case "Monday":
                            // 处理星期一被选中的情况
                            break;
                        case "Tuesday":
                            // 处理星期二被选中的情况
                            break;
                        case "Wednesday":
                            // 处理星期三被选中的情况
                            break;
                        case "Thursday":
                            // 处理星期四被选中的情况
                            break;
                        case "Friday":
                            // 处理星期五被选中的情况
                            break;
                        case "Saturday":
                            // 处理星期六被选中的情况
                            break;
                        case "Sunday":
                            // 处理星期日被选中的情况
                            break;
                        default:
                            break;
                    }
                }
            }
            else
            {
                // 如果 CheckBox 取消选中
                if (checkBox.BindingContext is string dayOfWeek)
                {
                    switch (dayOfWeek)
                    {
                        case "Monday":
                            // 处理星期一未被选中的情况
                            break;
                        case "Tuesday":
                            // 处理星期二未被选中的情况
                            break;
                        case "Wednesday":
                            // 处理星期三未被选中的情况
                            break;
                        case "Thursday":
                            // 处理星期四未被选中的情况
                            break;
                        case "Friday":
                            // 处理星期五未被选中的情况
                            break;
                        case "Saturday":
                            // 处理星期六未被选中的情况
                            break;
                        case "Sunday":
                            // 处理星期日未被选中的情况
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}