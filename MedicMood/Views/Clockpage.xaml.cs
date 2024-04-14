using MedicMood.DataModel;

namespace MedicMood.Views;

public partial class Clockpage : ContentPage
{
    public List<Alarm> Alarms { get; set; }
    private int nextAlarmNumber = 1; // 用于跟踪下一个闹钟的编号
    public Clockpage()
    {
        InitializeComponent();
        LoadAlarms();
        StartTimerToUpdateTime();
    }

    private void LoadAlarms()
    {
        // Load no sample alarms (replace with actual data retrieval logic)
        Alarms = new List<Alarm>();

        // Update ListView with alarms
        alarmListView.ItemsSource = Alarms;
    }

    [Obsolete]
    private void StartTimerToUpdateTime()
    {
        Device.StartTimer(TimeSpan.FromSeconds(1), () =>
        {
            // 更新手机时间
            Device.BeginInvokeOnMainThread(() =>
            {
                // 设置 Label 的文本为当前手机时间
                currentTimeLabel.Text = DateTime.Now.ToString("HH:mm:ss");
            });

            // 返回 true 以继续循环
            return true;
        });
    }

    private void OnButtonClicked(object sender, EventArgs e)
    {
        // 创建一个新的闹钟并将其添加到列表中，标签设置为"Alarm {nextAlarmNumber}"
        Alarm newAlarm = new Alarm { Label = $"Alarm {nextAlarmNumber}", Time = DateTime.Now.AddHours(1), IsActive = true };
        Alarms.Add(newAlarm);
        // Navigate to the AddPage when the button is clicked, add alarm button
        //Navigation.PushAsync(new AddPage());

        alarmListView.ItemsSource = null; // Refresh ListView
        alarmListView.ItemsSource = Alarms;

        // 增加下一个闹钟的编号
        nextAlarmNumber++;
    }
    private void DeleteAlarm_Clicked(object sender, EventArgs e)
    {
        // Delete selected alarm from the list
        if (alarmListView.SelectedItem != null)
        {
            Alarms.Remove((Alarm)alarmListView.SelectedItem);
            alarmListView.SelectedItem = null; // Clear selection
            alarmListView.ItemsSource = null; // Refresh ListView
            alarmListView.ItemsSource = Alarms;
        }

    }
}