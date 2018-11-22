using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Autofac;

namespace AdaptiveClient.WPFDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IContainer Container;

        private void Application_Start(object sender, StartupEventArgs e)
        {
            CreateContainer();
            MainWindow window = Container.Resolve<MainWindow>();
            window.ShowDialog();
        }


        private void CreateContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<MainWindow>();
            builder.RegisterType<MainWindowViewModel>();
            Container = builder.Build();
        }
    }
}
