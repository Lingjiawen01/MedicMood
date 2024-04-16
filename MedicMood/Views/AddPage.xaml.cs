using MedicMood.DataModel;
using Microsoft.Maui.Controls;
using System;

namespace MedicMood.Views;

public partial class AddPage : ContentPage
{
    private AlarmService alarmService;
    public AddPage(List<Alarm> alarms, int nextAlarmNumber)
    {
        InitializeComponent();
        alarmService = new AlarmService();
    }

    private void SetAlarmButton_Clicked(object sender, EventArgs e)
    {
        // 获取用户选择的日期和时间
        DateTime alarmDateTime = alarmDatePicker.Date + alarmTimePicker.Time;

        // 设置闹钟并检查是否成功
        bool isSuccess = alarmService.SetAlarm(alarmDateTime);

        // 根据设置结果执行逻辑
        if (isSuccess)
        {
            // 设置成功
            Console.WriteLine("Alarm set successfully.");
        }
        else
        {
            // 设置失败
            Console.WriteLine("Failed to set alarm.");
        }
    }

    private void CancelAlarmButton_Clicked(object sender, EventArgs e)
    {
        // 取消闹钟
        bool isCanceled = alarmService.CancelAlarm();
        if (isCanceled)
        {
            Console.WriteLine("Alarm canceled successfully.");
        }
        else
        {
            Console.WriteLine("No alarm to cancel.");
        }
    }

}
