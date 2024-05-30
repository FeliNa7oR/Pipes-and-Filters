using System;
using CompAndDel.Pipes;
using CompAndDel.Filters;


namespace CompAndDel
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cargar la imagen
            PictureProvider provider = new PictureProvider();
            IPicture picture = provider.GetPicture(@"PathToImageToLoad.jpg");

            // Crear los filtros
            IFilter filterGreyscale = new FilterGreyscale();
            IFilter filterNegative = new FilterNegative();
            IFilter filterSave1 = new FilterSave(@"PathToSaveAfterGreyscale.jpg");
            IFilter filterSave2 = new FilterSave(@"PathToSaveAfterNegative.jpg");
            IFilterConditional filterConditional = new FilterConditional();

            // Crear las tuberías
            IPipe pipeNull = new PipeNull();
            IPipe pipeSave2 = new PipeSerial(filterSave2, pipeNull);
            IPipe pipeNegative = new PipeSerial(filterNegative, pipeSave2);
            IPipe pipeSave1 = new PipeSerial(filterSave1, pipeNegative);
            IPipe pipeGreyscale = new PipeSerial(filterGreyscale, pipeSave1);
            IPipe pipeConditional = new PipeConditional(filterConditional, pipeGreyscale, pipeNull);

            // Enviar la imagen a través de la cadena de pipes
            IPicture resultPicture = pipeConditional.Send(picture);

            // Guardar la imagen final
            provider.SavePicture(resultPicture, @"PathToImageToSave.jpg");
        }
    }
}
