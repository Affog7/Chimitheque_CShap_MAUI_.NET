using System;
using System.Diagnostics;

namespace Chimitheque_Mobile_App.View.Utils
{
    public class ProgressArc : IDrawable
    {
        public double Progress { get; set; } = 100;
        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            // Angle of the arc in degrees
            var endAngle = 90 - (int)Math.Round(Progress * 360, MidpointRounding.AwayFromZero);
            // Drawing code goes here
            // canvas.StrokeColor = Color.FromRgba("6599ff");
            canvas.StrokeColor = Color.FromRgba("6599ff");
            canvas.StrokeSize = 4;
            //Debug.WriteLine($"The rect width is {dirtyRect.Width} and height is {dirtyRect.Height}");
            canvas.DrawArc(5, 5, (dirtyRect.Width - 10), (dirtyRect.Height - 10), 90, endAngle, false, false);
        }
    }
     

}

