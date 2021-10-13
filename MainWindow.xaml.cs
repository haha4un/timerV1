using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace timerV1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int sec = 0;
        int min = 0;
        int hour = 0;
        int time = 0;

        bool start = false;
        bool stop = true;

        int counter = 0;

        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("code maker is @haha4un© \rpress spacebar to start / stop");
        }

        private void downS_Click(object sender, RoutedEventArgs e)
        {
            sec -= 1;
            if (sec < 0)
            {
                sec = 59;
                Secund.Text = sec.ToString();
            }
            else
            {
                Secund.Text = sec.ToString();
            }
        }

        private void downM_Click(object sender, RoutedEventArgs e)
        {
            min -= 1;
            if (min < 0)
            {
                min = 59;
                Minute.Text = min.ToString();
            }
            else
            {
                Minute.Text = min.ToString();
            }
        }

        //private void downH_Click(object sender, RoutedEventArgs e)
        //{
        //    hour -= 1;
        //    if (hour < 0)
        //    {
        //        hour = 59;
        //        Hour.Text = hour.ToString();
        //    }
        //    else
        //    {
        //        Hour.Text = hour.ToString();
        //    }
        //}

        ///////////////////////////////////////// короче, тут такое один вверх, другой вниз, так сказать делю теру

        private void upS_Click(object sender, RoutedEventArgs e)
        {
            sec += 1;
            if (sec > 59)
            {
                sec = 0;
                Secund.Text = sec.ToString();
            }
            else
            {
                Secund.Text = sec.ToString();
            }
        }

        private void upM_Click(object sender, RoutedEventArgs e)
        {
            min += 1;
            if (min > 59)
            {
                min = 0;
                Minute.Text = min.ToString();
            }
            else
            {
                Minute.Text = min.ToString();
            }
        }

        //private void upH_Click(object sender, RoutedEventArgs e)
        //{
        //    hour += 1;
        //    if (hour > 59)
        //    {
        //        hour = 0;
        //        Hour.Text = hour.ToString();
        //    }
        //    else
        //    {
        //        Hour.Text = hour.ToString();
        //    }
        //}
        ////////////////////// проверка на спейс нажатый

        private async Task spacerAsync()
        {
            //time = (hour * 1000 * 60) + (min * 1000 * 60) + (sec * 1000);
            //hour = 60 * min;
            //min = 60 * sec;

            counter += 1;
            if (counter == 1)
            {
                start = true;
                stop = false;


                while (counter == 1 & start == true)
                {
                    await Task.Delay(1000);


                    sec -= 1;
                    Secund.Text = sec.ToString();


                    if (sec < 0)
                    {
                        min -= 1;
                        sec = 59;

                        Minute.Text = min.ToString();
                        Secund.Text = sec.ToString();
                        if (min <= 0)
                        {
                            break;
                        }
                    }
                    else if (sec > 59)
                    {
                        min += 1;
                        sec = 0;

                        Minute.Text = min.ToString();
                        Secund.Text = sec.ToString();
                        if (min == 0)
                        {
                            break;
                        }
                    }
                }
            }
            else if (counter == 2)
            {
                start = false;
                stop = true;
            }
            else if (counter > 2)
            {
                counter = 0;
            }
        }

        private void starterOrStoper(object sender, RoutedEventArgs e)
        {
            spacerAsync();
            if ( Keyboard.IsKeyDown(Key.Space))
            {
                spacerAsync();
            }
        }
    }
}
