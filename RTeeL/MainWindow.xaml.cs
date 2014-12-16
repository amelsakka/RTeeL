namespace RTeeL {
    using System.IO;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interop;
    using System.Windows.Media.Imaging;

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();
            var ver = Assembly.GetAssembly(typeof(MainWindow)).GetName().Version;
            Title = string.Format(Title, ver.Major, ver.Minor);
            try {
                var icon = System.Drawing.Icon.ExtractAssociatedIcon(Path.GetFileName(Assembly.GetAssembly(typeof(MainWindow)).CodeBase));
                if(icon != null)
                    Icon = Imaging.CreateBitmapSourceFromHIcon(icon.Handle, new Int32Rect(0, 0, icon.Width, icon.Height), BitmapSizeOptions.FromWidthAndHeight(icon.Width, icon.Height));
            }
            catch {}
        }

        private void Inputbox_TextChanged(object sender, TextChangedEventArgs e) {
            var tb = sender as TextBox;
            if(tb != null)
                FixBtn.IsEnabled = tb.Text.Length > 0;
        }

        private void FixBtn_Click(object sender, RoutedEventArgs e) { OutputBox.Text = RtlConverter.FixArabicAndFarsi(Inputbox.Text); }
    }
}