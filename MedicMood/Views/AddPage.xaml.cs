using MedicMood.DataModel;
using System;
using System.Diagnostics;

namespace MedicMood.Views;

public partial class AddPage : ContentPage
{
    private AlarmService alarmService;
    private List<Alarm> alarms;
    private int nextAlarmNumber;
    public AddPage(List<Alarm> alarms, int nextAlarmNumber)
    {
        InitializeComponent();
        this.alarms = alarms;
        this.nextAlarmNumber = nextAlarmNumber;
        alarmService = new AlarmService();
    }

    private async void SetAlarmButton_Clicked(object sender, EventArgs e)
    {
        // 获取用户选择的日期和时间
        DateTime alarmDateTime = alarmDatePicker.Date + alarmTimePicker.Time;

        // 获取用户选择的声音
        string selectedSound = soundPicker.SelectedItem as string;

        // 设置闹钟并检查是否成功
        bool isSuccess = alarmService.SetAlarm(alarmDateTime);

        // 根据设置结果执行逻辑
        if (isSuccess)
        {
            // 设置成功
            await DisplayAlert("Success", "Alarm set successfully.", "OK");

            //创建新的闹钟+添加入列表

            Alarm newAlarm = new Alarm { Label = $"Alarm {nextAlarmNumber}", Time = alarmDateTime, IsActive = true };
            alarms.Add(newAlarm);

            // 返回到时钟页面
            await Navigation.PopAsync();
        }
        else
        {
            // 设置失败
            await DisplayAlert("Error", "Failed to set alarm.", "OK");
        }
    }

    private async void CancelAlarmButton_Clicked(object sender, EventArgs e)
    {
        // 取消闹钟
        bool isCanceled = alarmService.CancelAlarm();
        if (isCanceled)
        {
            await DisplayAlert("Success", "Alarm canceled successfully.", "OK");
        }
        else
        {
            await DisplayAlert("Success", "No alarm to cancel.", "OK");
        }
    }

    private void RepeatButton_Clicked(object sender, EventArgs e)
    {
        // 切换重复日期选项的可见性
        repeatOptions.IsVisible = !repeatOptions.IsVisible;
    }

    private void ButtonMonday_Clicked(object sender, EventArgs e)
    {
        ToggleButtonState((Button)sender);
    }

    private void ButtonTuesday_Clicked(object sender, EventArgs e)
    {
        ToggleButtonState((Button)sender);
    }

    private void ButtonWednesday_Clicked(object sender, EventArgs e)
    {
        ToggleButtonState((Button)sender);
    }

    private void ButtonThursday_Clicked(object sender, EventArgs e)
    {
        ToggleButtonState((Button)sender);
    }

    private void ButtonFriday_Clicked(object sender, EventArgs e)
    {
        ToggleButtonState((Button)sender);
    }

    private void ButtonSaturday_Clicked(object sender, EventArgs e)
    {
        ToggleButtonState((Button)sender);
    }

    private void ButtonSunday_Clicked(object sender, EventArgs e)
    {
        ToggleButtonState((Button)sender);
    }

    private void ToggleButtonState(Button button)
    {
        // 切换按钮的状态（选中或取消选中）
        button.BackgroundColor = button.BackgroundColor == Color.FromRgb(128, 128, 128) ? Color.FromRgb(0, 128, 0) : Color.FromRgb(128, 128, 128);
        button.TextColor = button.TextColor == Color.FromRgb(0, 0, 0) ? Color.FromRgb(255, 255, 255) : Color.FromRgb(0, 0, 0);
    }


}
