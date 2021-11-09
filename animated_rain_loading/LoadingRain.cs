using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace animated_rain_loading
{
    public partial class LoadingRain : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);

        private PuddleAnimation _puddleAnimation;
        private BlobAnimation _blobAnimation;

        public LoadingRain()
        {
            InitializeComponent();
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 10, 10));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _blobAnimation = new BlobAnimation(
                new Blob[] {
                    new Blob(4, _blobPicture1),
                    new Blob(6, _blobPicture2),
                    new Blob(8, _blobPicture3),
                    new Blob(3, _blobPicture4),
                    new Blob(5, _blobPicture5),
                    new Blob(6, _blobPicture6),
                    new Blob(7, _blobPicture7),
                    new Blob(4, _blobPicture8)
                }
            );
            _blobAnimation.Start();

            _puddleAnimation = new PuddleAnimation(_puddlePicture);
            _puddleAnimation.SetProcent(0);

            Progress();
        }

        private async void Progress()
        {
            while (_puddleAnimation.Procent < 100)
            {
                await Task.Delay(50);
                _puddleAnimation.SetProcent(_puddleAnimation.Procent + 1);
                _procentLabel.Text = _puddleAnimation.Procent + "%";
            }
        }
    }
}