using MedicMood.Views;
using Microsoft.Maui.Controls;

namespace MedicMood.Views
{
    public partial class ReminderPage : ContentPage
    {
        private AlarmService _alarmService;

        public ReminderPage(AlarmService alarmService)
        {
            InitializeComponent();
            _alarmService = alarmService;
        }

        private void DismissButton_Clicked(object sender, EventArgs e)
        {
            // 取消闹钟
            _alarmService.CancelAlarm();

            // 关闭提醒页面
            Navigation.PopAsync();
        }
    }
}