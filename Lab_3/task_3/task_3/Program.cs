using System.Drawing;

namespace task_3;

class Program
{
    private static ImageHandler _handler = new ImageHandler();
    static void Main(string[] args)
    {
        var image = new Bitmap(@"C:\Users\mishavrana\Desktop\Kyiv.jpeg");
        var flipedImage = _handler.flipHorizontally(image);
        _handler.displayImage(flipedImage);
    }
}