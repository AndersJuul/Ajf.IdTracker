using Ajf.IdTracker.Shared;
using System.Windows;

namespace IdTracker
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var mainVm = new MainViewModel(new CsvRepository());
            var mainform = new MainWindow()
            {
                DataContext = mainVm
            };

            mainform.ShowDialog();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);


        }
    }
}
