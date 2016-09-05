using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Tanfolyam45
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        MediaElement me;

        public MainWindow()
        {
            InitializeComponent();
            me = (MediaElement)(grid.Resources["gridmedia"] as DockPanel).Children[0];

        }

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            TranslateTransform3D tt = new TranslateTransform3D();
            tt.OffsetX= tt.OffsetY= tt.OffsetZ = e.Delta / 100;
            ((MatrixTransform3D)camera.Transform).Matrix *= tt.Value;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key!=Key.Right && e.Key != Key.Up && e.Key != Key.Left && e.Key != Key.Down)
            {
                return;
            }

            RotateTransform3D spin = null;

            int mul = 1;
            if (e.Key == Key.Left || e.Key == Key.Up)
                mul = -1;
            if(e.Key == Key.Right || e.Key == Key.Left)
            {
                spin = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), mul * 5));
            }
            else
            {
                spin = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 1, 0), mul * 5));

            }

            spin.CenterX = spin.CenterY = spin.CenterZ =5;

            ((MatrixTransform3D)cube.Transform).Matrix *= spin.Value;

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            me.Play();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            me.Stop();
        }
    }
}
