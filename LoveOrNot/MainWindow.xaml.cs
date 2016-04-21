using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Threading;

namespace LoveOrNot
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        static Random rnd = new Random();
        Thread doStuffThread;
        private void Go_Button_Click(object sender, RoutedEventArgs e)
        {
            

            doStuffThread = new Thread(new ThreadStart(DoVangaStuff));
            doStuffThread.Start();

            
        }

        const string _NOT_LOVES = "Не любит";
        const string _LOVES = "Любит";

        void DoVangaStuff()
        {
            var rndNum = rnd.Next(100);

            Result_Label.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
            new Action(() =>
            {
                Result_Label.Foreground = new SolidColorBrush(Colors.Black);
            }));

            for (int i = 0; i < rndNum; i++)
            {
                if(i % 2 == 0)
                {
                    Result_Label.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                    new Action(() =>
                    {
                        Result_Label.Content = _NOT_LOVES;
                    }));
                }
                else
                {
                    Result_Label.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
                    new Action(() =>
                    {
                        Result_Label.Content = _LOVES;
                    }));
                }

                Thread.Sleep(200);
            }

            Result_Label.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal,
            new Action(() =>
            {
                if (Result_Label.Content == _NOT_LOVES)
                Result_Label.Foreground = new SolidColorBrush(Colors.Red);
            else
                Result_Label.Foreground = new SolidColorBrush(Colors.Green);
            }));
        }
    }
}
