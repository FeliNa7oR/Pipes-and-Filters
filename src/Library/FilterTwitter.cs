using System;
using System.Drawing;

using CompAndDel;


namespace CompAndDel.Filters
{
    public class FilterTwitter : IFilter
    {
        private string message;

        public FilterTwitter(string message)
        {
            this.message = message;
        }

        public IPicture Filter(IPicture image)
        {
            
            var pictureProvider = new PictureProvider();
            string tempPath = @"temp_image.jpg";
            pictureProvider.SavePicture(image, tempPath);
            return image;
        }
    }
}
