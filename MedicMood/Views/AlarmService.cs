using System;
using System.Collections.Generic;

namespace MedicMood.Views
{
    public class AlarmService
    {
        private List<DateTime> alarmTimes = new List<DateTime>(); // 存储已设置的闹钟时间列表

        public bool SetAlarm(DateTime alarmTime)
        {
            // 设置闹钟的逻辑
            if (alarmTime != default(DateTime))
            {
                alarmTimes.Add(alarmTime); // 将设置的闹钟时间添加到列表中
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
            if (alarmTimes.Count > 0)
            {
                alarmTimes.Clear(); // 清空已设置的闹钟时间列表
                return true;
            }
            else
            {
                return false;
            }
        }

        public List<DateTime> GetAlarmTimes()
        {
            // 返回已设置的闹钟时间列表
            return alarmTimes;
        }
    }
}