using System;
using Microsoft.Maui.Controls;

namespace MedicMood.Views
{
    public partial class AddPage : ContentPage
    {
        private AlarmService alarmService;

        public AddPage()
        {
            InitializeComponent();
            alarmService = new AlarmService();
        }

        private void SetAlarmButton_Clicked(object sender, EventArgs e)
        {
            // 获取用户选择的日期和时间
            DateTime alarmDateTime = alarmDatePicker.Date + alarmTimePicker.Time;

            // 设置闹钟
            alarmService.SetAlarm(alarmDateTime);
        }

        private void CancelAlarmButton_Clicked(object sender, EventArgs e)
        {
            // 取消闹钟
            alarmService.CancelAlarm();
        }

    }
}