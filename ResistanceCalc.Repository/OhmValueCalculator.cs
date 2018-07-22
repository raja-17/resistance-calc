using ResistanceCalc.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResistanceCalc.Repository
{
    public class OhmValueCalculator : IOhmValueCalculator
    {
        public long CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor)
        {
            float precisionPercent = 0f;
            return CalculateOhmValue(bandAColor, bandBColor, bandCColor, bandDColor, out precisionPercent);
        }

        public long CalculateOhmValue(string bandAColor, string bandBColor, string bandCColor, string bandDColor, out float precisionPercent)
        {
            Color bandA, bandB, bandC, bandD;
            long ohmValue = 0;
            precisionPercent = 0;

            //Validation
            if (!Enum.TryParse(bandAColor, out bandA)) throw new ECCException($"Invalid Band A Color: {bandAColor}");
            if (!Enum.TryParse(bandBColor, out bandB)) throw new ECCException($"Invalid Band B Color: {bandBColor}");
            if (!Enum.TryParse(bandCColor, out bandC)) throw new ECCException($"Invalid Band C Color: {bandCColor}");
            if (!Enum.TryParse(bandDColor, out bandD)) throw new ECCException($"Invalid Band D Color: {bandDColor}");

            //None, Pink, Silver, Gold cannot be Band A or B color
            var invalidFirstColors = new List<Color>() { Color.Pink, Color.Silver, Color.Gold, Color.None };            
            if (invalidFirstColors.Contains(bandA))
                throw new ECCException($"'{bandAColor}' cannot be a Band A Color");

            if (invalidFirstColors.Contains(bandB))
                throw new ECCException($"'{bandBColor}' cannot be a Band B Color");

            //None is a invalid Band C color
            if (bandC == Color.None)
                throw new ECCException($"'{bandCColor}' cannot be a Band C Color");

            //Get the significant figure and multiplier
            var significantFigure = Convert.ToInt32(ColorCodeMatrix.Matrix.First(f => f.Color == bandA).SignificantFigure);
            var significantFigure2 = Convert.ToInt32(ColorCodeMatrix.Matrix.First(f => f.Color == bandB).SignificantFigure);
            var multiplier = Convert.ToDouble(ColorCodeMatrix.Matrix.First(f => f.Color == bandC).Multiplier);

            precisionPercent = ColorCodeMatrix.Matrix.First(f => f.Color == bandD).TolerancePercent ?? 0;

            ohmValue = Convert.ToInt64(((significantFigure * 10) + significantFigure2) * multiplier);

            return ohmValue;
        }

        
    }
    
}
