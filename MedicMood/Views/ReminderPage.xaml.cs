using MedicMood.Views;
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
        }

        private async void DismissButton_Clicked(object sender, EventArgs e)
        {
            alarm.IsRinging = false;

            // 检查当前页面是否是栈顶页面
            if (Navigation.NavigationStack.Count > 0 && Navigation.NavigationStack.Last() == this)
            {
                await Navigation.PopAsync();
            }
        }

        private async void SnoozeButton_Clicked(object sender, EventArgs e)
        {
            // 停止闹钟一段时间
            alarm.IsRinging = false;
            TimeSpan snoozeDuration = TimeSpan.FromMinutes(5);
            await Task.Delay(snoozeDuration);
            // 再次启动闹钟
            alarm.IsRinging = true;
        }
    }
}