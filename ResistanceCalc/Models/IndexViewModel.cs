using ResistanceCalc.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResistanceCalc.Models
{
    public class IndexViewModel : RequestModelBase
    {
        [Required(ErrorMessage ="Required")]
        [Display(Name ="Band A")]
        public string BandAColor { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Band B")]
        public string BandBColor { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Band C")]
        public string BandCColor { get; set; }

        [Required(ErrorMessage = "Required")]
        [Display(Name = "Band D")]
        public string BandDColor { get; set; }        

        public int OhmValue { get; set; }

        public IEnumerable<string> SignificantColors
        {
            get
            {
                return ColorCodeMatrix.Matrix.Select(s => s.Color.ToString()).Except(SignificantExclusions);
            }
        }

        public IEnumerable<string> MultiplierColors
        {
            get
            {
                return ColorCodeMatrix.Matrix.Select(s => s.Color.ToString()).Except(MultiplierExclusions);
            }
        }

        public IEnumerable<string> ToleranceColors
        {
            get
            {
                return ColorCodeMatrix.Matrix.Select(s => s.Color.ToString()).Except(ToleranceExclusions);
            }
        }

        IEnumerable<string> SignificantExclusions
        {
            get
            {
                yield return Color.None.ToString();
                yield return Color.Pink.ToString();
                yield return Color.Silver.ToString();
                yield return Color.Gold.ToString();
            }
        }

        IEnumerable<string> MultiplierExclusions
        {
            get
            {
                yield return Color.None.ToString();
            }
        }
        
        IEnumerable<string> ToleranceExclusions
        {
            get
            {
                yield return Color.Pink.ToString();
                yield return Color.Black.ToString();
                yield return Color.Orange.ToString();
                yield return Color.White.ToString();
            }
        }
    }
}