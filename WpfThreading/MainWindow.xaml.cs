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
using System.Windows.Threading;

namespace WpfThreading
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    /*public static class ExtensionMethods
    {

       private static Action EmptyDelegate = delegate() { };
 

       public static void Refresh(this UIElement uiElement)
       {
          uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
       }
    }*/

    public partial class MainWindow : Window
    {


        int length = 100000;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1Loop1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < length; i++)
            {
                label1.Content = i.ToString();
                //label1.Refresh();
                //Thread.Sleep(1);
            }
        }

        private void button2Loop2(object sender, RoutedEventArgs e)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                int result = 0;
                for (int i = 0; i < 9999; i++)
                {
                    result++;
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        this.label2.Content = result;
                    }));
                    Thread.Sleep(5);
                }
            });

        }

        private void button32Loops1thread(object sender, RoutedEventArgs e)
        {
            int i = 0;
            label3.Content = i.ToString();
        }

        private void button42Loops2threads(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
