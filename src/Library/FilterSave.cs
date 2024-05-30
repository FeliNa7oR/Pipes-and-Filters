using System;
using System.Drawing;

using CompAndDel;

namespace CompAndDel.Filters
{
    public class FilterSave : IFilter
    {
        private string path;

        public FilterSave(string path)
        {
            this.path = path;
        }

        public IPicture Filter(IPicture image)
        {
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, this.path);
            return image;
        }
    }
}
