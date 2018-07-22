using System.Collections.Generic;

namespace ResistanceCalc.Util
{
    public static class ColorCodeMatrix
    {
        public static readonly List<ColorCode> Matrix;

        static ColorCodeMatrix()
        {
            //define color mappings
            Matrix = new List<ColorCode>();
            Matrix.Add(new ColorCode() { Color = Color.None, SignificantFigure = null, Multiplier = null, TolerancePercent = 20f });
            Matrix.Add(new ColorCode() { Color = Color.Pink, SignificantFigure = null, Multiplier = 0.001d, TolerancePercent = null });
            Matrix.Add(new ColorCode() { Color = Color.Silver, SignificantFigure = null, Multiplier = 0.01d, TolerancePercent = 10f });
            Matrix.Add(new ColorCode() { Color = Color.Gold, SignificantFigure = null, Multiplier = 0.1d, TolerancePercent = 5f });
            Matrix.Add(new ColorCode() { Color = Color.Black, SignificantFigure = 0, Multiplier = 1d, TolerancePercent = null });
            Matrix.Add(new ColorCode() { Color = Color.Brown, SignificantFigure = 1, Multiplier = 10d, TolerancePercent = 1f });
            Matrix.Add(new ColorCode() { Color = Color.Red, SignificantFigure = 2, Multiplier = 100d, TolerancePercent = 2f });
            Matrix.Add(new ColorCode() { Color = Color.Orange, SignificantFigure = 3, Multiplier = 1000d, TolerancePercent = null });
            Matrix.Add(new ColorCode() { Color = Color.Yellow, SignificantFigure = 4, Multiplier = 10000d, TolerancePercent = 5f });
            Matrix.Add(new ColorCode() { Color = Color.Green, SignificantFigure = 5, Multiplier = 100000d, TolerancePercent = 0.5f });
            Matrix.Add(new ColorCode() { Color = Color.Blue, SignificantFigure = 6, Multiplier = 1000000d, TolerancePercent = 0.25f });
            Matrix.Add(new ColorCode() { Color = Color.Violet, SignificantFigure = 7, Multiplier = 10000000d, TolerancePercent = 0.1f });
            Matrix.Add(new ColorCode() { Color = Color.Gray, SignificantFigure = 8, Multiplier = 100000000d, TolerancePercent = 0.05f });
            Matrix.Add(new ColorCode() { Color = Color.White, SignificantFigure = 9, Multiplier = 1000000000d, TolerancePercent = null });            
        }
    }

   

    
}
