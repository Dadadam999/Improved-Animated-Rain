using System.Drawing;
using System.Windows.Forms;

namespace animated_rain_loading
{
    public class PuddleAnimation
    {
        public int Procent { get; private set; } = 0;

        private PictureBox _pictureBox;
        private Bitmap _sourceImage;

        public PuddleAnimation(PictureBox picturePuddle)
        {
            _pictureBox = picturePuddle;
            _sourceImage = new Bitmap(picturePuddle.Image);
        }

        public void SetProcent(int procent)
        {
            Procent = procent;

            int sourceHeight = _sourceImage.Height * procent / 100;
            sourceHeight = sourceHeight <= 0 ? 1 : sourceHeight;

            _pictureBox.Image = _sourceImage.Clone(new Rectangle(0, 0, _sourceImage.Width, sourceHeight), _sourceImage.PixelFormat);
        }
    }
}