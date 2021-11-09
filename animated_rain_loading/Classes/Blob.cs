using System.Windows.Forms;

namespace animated_rain_loading
{
    public class Blob
    {
        public int Speed { get; set; }
        public PictureBox View { get; set; }

        public Blob(int speed, PictureBox view)
        {
            Speed = speed;
            View = view;
        }

        public void Move()
        {
            View.Top += Speed;

            if (View.Top > View.Parent.Height + View.Height)
                View.Top = 0 - View.Height;
        }
    }
}