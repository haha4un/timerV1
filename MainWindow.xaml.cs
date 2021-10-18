using System.Media;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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
        int clicks = 0;

        private MediaPlayer musick = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show("Code maker is @haha4un©");
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
        ////////////////////// проверка на спейс нажатый

        private async Task spacerAsync()
        {
            counter += 1;
            if (counter == 1)
            {
                start = true;
                stop = false;


                while (counter == 1 & start == true)
                {
                    await Task.Delay(1);

                    if (min <= 0 && sec == 0)
                    {
                        start = false;
                        int i = 0;
                        while (i != 30 & clicks != 2)
                        {   
                            await Task.Delay(1000);

                            SystemSounds.Beep.Play();
                            i += 1;
                        }
                        break;
                    }
                    sec -= 1;
                    Secund.Text = sec.ToString();


                    if (sec < 0)
                    {
                        min -= 1;
                        sec = 59;

                        Minute.Text = min.ToString();
                        Secund.Text = sec.ToString();
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
            clicks += 1;
            if (clicks == 1)
            {
                start = true;
                spacerAsync();
            }
            else if (clicks == 2)
            {
                start = false;
            }
            else if (clicks == 3)
            {
                clicks = 1;
                start = true;
                spacerAsync();
            }
        }
    }
}
