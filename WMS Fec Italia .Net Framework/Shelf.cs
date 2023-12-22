
using System.Collections.Generic;

namespace WMS_Fec_Italia_MVC
{
    class Shelf
    {
        public double Width { get; }
        public double Height { get; }
        public double Depth { get; }
        private List<Box> boxes;
        public double Volume { get; }
        public Shelf(double width, double height, double depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
            boxes = new List<Box>();
        }

        public Shelf(double volume)
        {
            Volume = volume;
            boxes = new List<Box>();
        }

        public bool CanFit(Box box)
        {
           
            double remainingVolume = Volume;
            foreach (var existingBox in boxes)
            {
                remainingVolume -= existingBox.Volume;
            }
            return remainingVolume - (box.Volume) >= 0;
        }

       
    }
}