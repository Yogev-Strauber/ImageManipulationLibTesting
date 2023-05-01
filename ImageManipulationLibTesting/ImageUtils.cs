namespace ImageManipulationLibTesting
{
    public static class ImageUtils
    {
        const int fixedResolution = 72;
        public static Image ResizeImage(Image image, int width, int height)
        {
            Size imageNewSize = CalculateResizedDimensions(image, width, height);
            Image reSizedImage = ConfigureResizedImage(image, imageNewSize);

            return reSizedImage;
        }

        private static Image ConfigureResizedImage(Image image, Size newSize)
        {
            Image reSizedImage = new Image<Rgba32>(newSize.Width, newSize.Height);

            image.Metadata.HorizontalResolution = fixedResolution;
            image.Metadata.VerticalResolution = fixedResolution;

            reSizedImage = image.Clone(img => img.Resize(new ResizeOptions
            {
                Size = newSize,
                Mode = ResizeMode.Max
            }));

            return reSizedImage;
        }

        /// <summary>
        /// Resize the image size in percentage way.<br />
        /// First, checks which property is more significant change.<br />
        /// Secondly, based on that change resize the image by this percentage.<br />
        /// And all this is for Calculates resized dimensions for an image, <br />
        ///  <br />
        /// PRESERVING THE ASPECT RATIO !!!
        /// </summary>
        /// <param name="image">Image instance</param>
        /// <param name="desiredWidth">desired width</param>
        /// <param name="desiredHeight">desired height</param>
        /// <returns>Size instance with the resized dimensions</returns>
        private static Size CalculateResizedDimensions(Image image, int desiredWidth, int desiredHeight)
        {
            var widthScale = (double)desiredWidth / image.Width;
            var heightScale = (double)desiredHeight / image.Height;

            // scale to whichever ratio is smaller, this works for both scaling up and scaling down
            var scale = widthScale < heightScale ? widthScale : heightScale;

            int newWidth = (int)(scale * image.Width);
            int newHeight = (int)(scale * image.Height);

            Size newSize = new Size(newWidth, newHeight);

            return newSize;
        }

    }
}
