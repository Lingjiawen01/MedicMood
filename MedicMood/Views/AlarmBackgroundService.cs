using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MedicMood.Views;


namespace MedicMood.Views
{
    public class AlarmBackgroundService : BackgroundService
    {
        private IServiceProvider _services;

        public AlarmBackgroundService(IServiceProvider services)
        {
            _services = services;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                // 检查是否到达设定的闹钟时间
                if (IsAlarmTimeReached())
                {
                    // 响铃或者触发提醒操作
                    await RingAlarm();
                }

                // 等待一段时间后再次检查
                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            }
        }

        private bool IsAlarmTimeReached()
        {
            // 实例化 AlarmService 类来获取已设置的闹钟时间
            var alarmService = new AlarmService();
            var alarmTimes = alarmService.GetAlarmTimes();

            // 检查当前时间是否已经超过任何一个闹钟设定时间
            foreach (var alarmTime in alarmTimes)
            {
                if (DateTime.Now >= alarmTime)
                {
                    return true; // 如果当前时间超过了任何一个闹钟时间，则返回 true
                }
            }

            return false; // 如果没有达到任何一个闹钟时间，则返回 false
        }

        private async Task RingAlarm()
        {
            // 使用MAUI导航服务来跳转到提醒页面
            var navigation = _services.GetRequiredService<INavigation>();
            var reminderPage = new ReminderPage(new AlarmService());
            await navigation.PushAsync(reminderPage);
        }
    }
}