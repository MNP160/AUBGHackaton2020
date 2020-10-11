using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace GarbageDetector.Models
{
    class ImageNetPrediction
    {
        [ColumnName("grid")]
        public float[] PredictedLabels; 
    }
}
