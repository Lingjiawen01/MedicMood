using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MedicMood.Views;

namespace MedicMood
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var services = new ServiceCollection();
            services.AddHostedService<AlarmBackgroundService>(); // 注册后台服务
            services.AddSingleton<AlarmService>(); // 注册 AlarmService，如果需要的话
            services.AddTransient<ReminderPage>(); // 如果 ReminderPage 需要注入依赖，则需要注册
            var serviceProvider = services.BuildServiceProvider();

            // 使用 MAUI 应用程序构建器创建应用程序
            var appBuilder = MauiApp.CreateBuilder();
            appBuilder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            MainPage = new AppShell();
        }
    }
}