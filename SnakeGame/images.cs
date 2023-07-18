using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SnakeGame
{
    public static class images                                                 /* holds all imported images, so it will be static */
    {
        public readonly static ImageSource Empty = LoadImage("Empty.png");     /* pulling up all images from assets */
        public readonly static ImageSource Body = LoadImage("Body.png");
        public readonly static ImageSource Head = LoadImage("Head.png");
        public readonly static ImageSource Food = LoadImage("Food.png");
        public readonly static ImageSource DeadBody = LoadImage("DeadBody.png");
        public readonly static ImageSource DeadHead = LoadImage("DeadHead.png");
        private static ImageSource LoadImage(string fileName)
        {
            return new BitmapImage(new Uri($"Assets/{fileName}", UriKind.Relative));
        }
    }
}
