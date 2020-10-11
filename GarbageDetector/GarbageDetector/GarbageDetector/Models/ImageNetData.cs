﻿using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Text;

namespace GarbageDetector.Models
{
    class ImageNetData
    {
        [LoadColumn(0)]
        public string ImagePath;
        [LoadColumn(1)]
        public string Label;

        public static IEnumerable<ImageNetData> ReadFromFile(string folderPath)
        {
            return Directory.GetFiles(folderPath)
                .Where(filePath => Path.GetExtension(filePath) != ".md")
                .Select(filePath=>new ImageNetData { ImagePath=filePath, Label=Path.GetFileName(filePath)});
        }

    }
}