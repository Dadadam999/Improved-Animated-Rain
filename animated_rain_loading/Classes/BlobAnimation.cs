using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace animated_rain_loading
{
    public class BlobAnimation
    {
        public List<Blob> Blobs { get; set; } = new List<Blob>();

        private Timer _timer = new Timer();

        public BlobAnimation(Blob[] blobs)
        {
            _timer.Interval = 30;
            _timer.Tick += TickTimer;

            Blobs.AddRange(blobs);
        }

        public void Start() => _timer.Start();

        public void Stop() => _timer.Stop();

        private void TickTimer(object sender, EventArgs e) => Blobs.ForEach(blob => { blob.Move(); });
    }
}