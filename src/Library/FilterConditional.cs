using System;
using CompAndDel;
using CognitiveCoreUCU;

namespace CompAndDel.Filters
{
    public class FilterConditional : IFilterConditional
    {
        private bool result;

        public bool Result { get { return result; } }

        public IPicture Filter(IPicture image)
        {
            
            string tempPath = @"temp_image.jpg";
            PictureProvider provider = new PictureProvider();
            provider.SavePicture(image, tempPath);
            
            return image;
        }
    }
}
