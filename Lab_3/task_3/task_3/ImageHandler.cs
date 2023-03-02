using System.Drawing;

namespace task_3
{
    public class ImageHandler
    {
        // Display image(actually saving the image)
        public Action<Bitmap> displayImage = image =>
        {
            image.Save(@"C:\Users\mishavrana\Desktop\fliped.jpeg");
            Console.WriteLine("Processed image saved.");
        };

        public Func<Bitmap, Bitmap> flipHorizontally = FlipHorizontally;


        // Flip image horizontally
        private static Bitmap FlipHorizontally(Bitmap image)
        {
            Bitmap processedImage = new Bitmap(image.Width, image.Height);

            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    processedImage.SetPixel(image.Width - x - 1, y, image.GetPixel(x, y));
                }
            }

            return processedImage;
        }
    }
}

