using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GarbageDetector.YoloParser
{
    public class BoundingBoxDimensions : DimensionsBase { }

    public class YoloBoundingBox
    {
        public BoundingBoxDimensions Dimensions { get; set; }
        public string Label { get; set; }
        public float Confidence { get; set; }
        public Color BoxColor { get; set; }
        public RectangleF Rectangle
        {
            get { return new RectangleF(Dimensions.X, Dimensions.Y, Dimensions.Width, Dimensions.Height); }
        }

    }

}
