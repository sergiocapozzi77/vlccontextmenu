using System.Windows;
using System.Windows.Forms;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;

namespace WpfTestContextMenu
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly LibVLC libVLC;

        private VideoView WinFormVideoView;

        public MainWindow()
        {
            InitializeComponent();

            libVLC = new LibVLC();

            // Winform
            var media = new Media(libVLC, "http://www.quirksmode.org/html5/videos/big_buck_bunny.mp4", FromType.FromLocation);
            WinFormVideoView = new VideoView();
            var mp = new MediaPlayer(media);
            WindowsFormsHost.Child = WinFormVideoView;
            mp.EnableMouseInput = true;
            WinFormVideoView.MouseClick += WinFormVideoView_MouseClick;
            WinFormVideoView.MediaPlayer = mp;

            //WPF
            var media1 = new Media(libVLC, "http://www.quirksmode.org/html5/videos/big_buck_bunny.mp4", FromType.FromLocation);
            var mp1 = new MediaPlayer(media1);
            mp1.EnableMouseInput = true;
            WpfVideoView.MediaPlayer = mp1;
        }

        private void WinFormVideoView_MouseClick(object sender, MouseEventArgs e)
        {
            WindowsFormsHost.ContextMenu.IsOpen = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WpfVideoView.MediaPlayer.Play();
            WinFormVideoView.MediaPlayer.Play();
        }

    }
}