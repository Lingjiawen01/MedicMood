namespace MedicMood.Views
{
    public class AlarmService
    {
        private bool isAlarmSet=false;

        public bool SetAlarm(DateTime alarmTime)
        {
            // 设置闹钟的逻辑
            if (alarmTime != default(DateTime))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CancelAlarm()
        {
            // 取消闹钟的逻辑
            if (isAlarmSet)
            {
                isAlarmSet = false;
                return true;
            }
            else
            {
                return false;
            }
        }

    }


}