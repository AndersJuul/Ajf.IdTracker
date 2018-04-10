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

            var mainVm = c.GetInstance<MainViewModel>();

            mainVm.PurposeItems=c
                .GetInstance<IPurposeItemsProvider>()
                .GetPurposeItems();

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
