using System;
using System.Windows;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BlazorWpfSample.Domain;

namespace BlazorWpfSample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var configuration = new ConfigurationBuilder().AddJsonFile(ApplicationContext.ConfigurationFileName).Build();

            var counterDefaultValue = configuration["Counter:DefaultValue"];
            var asyncCountDelayMilliseconds = configuration["Counter:AsyncCountDelayMilliseconds"];

            Int32.TryParse(counterDefaultValue, out var defaultValueInt);
            Int32.TryParse(asyncCountDelayMilliseconds, out var asyncCountDelayMillisecondsInt);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddWpfBlazorWebView();

            serviceCollection.AddSingleton<ApplicationContext>();
            serviceCollection.AddSingleton<WeatherForecastService>();
            serviceCollection.AddSingleton<Counter>(_ => 
            {
                return new Counter(defaultValueInt, asyncCountDelayMillisecondsInt);
            });

            Resources.Add("services", serviceCollection.BuildServiceProvider());
        }
    }
}
