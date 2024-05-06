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
            MainPage = new AppShell();
        }
    }
}