using Ajf.IdTracker.Shared;
using StructureMap;
using System.Diagnostics;
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
            var c=new Container(new IdTrackerSharedRegistry());

            Debug.WriteLine(c.WhatDoIHave());

            // new MainViewModel(new UniqueNumberProvider( new CsvRepository()));
            var mainVm = c.GetInstance<MainViewModel>();
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
