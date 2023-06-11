using PluginBase;
using System;
using System.Drawing;

namespace GammaExtensionPlugin
{
    public class GammaExtension : ICommand
    {
        private int r;
        private int g;
        private int b;

        public string Name { get => "GammaExtension"; }

        public string Description => throw new NotImplementedException();

        public double Version => throw new NotImplementedException();

        public Bitmap Execute(Bitmap sourceBitmap, double threshold)
        {
            Bitmap resultBitmap = new(sourceBitmap.Width, sourceBitmap.Height);

            for (int j = 0; j < sourceBitmap.Height; j++)
            {
                for (int i = 0; i < sourceBitmap.Width; i++)
                {
                    Color color = sourceBitmap.GetPixel(i, j);
                    r = (int)(255 * Math.Pow(color.R / 255.0, threshold));
                    g = (int)(255 * Math.Pow(color.G / 255.0, threshold));
                    b = (int)(255 * Math.Pow(color.B / 255.0, threshold));

                    if (r > 255) r = 255;
                    else if (r < 0)
                        r = 0;
                    if (g > 255) g = 255;
                    else if (g < 0)
                        g = 0;
                    if (b > 255) b = 255;
                    else if (b < 0)
                        b = 0;
                    resultBitmap.SetPixel(i, j, Color.FromArgb((byte)r, (byte)g, (byte)b));
                }
            }

            return resultBitmap;
        }
    }
}
