using System.ComponentModel.DataAnnotations;
namespace HolidaySearch.Models
{

    [Flags]
    public enum Airport
    {
        [Display(Name = "None")]
        None = 0,
        [Display(Name = "Manchester Airport (MAN)")]
        Man = 1,
        [Display(Name = "London Luton (LTN)")]
        Ltn = 2,
        [Display(Name = "Londen Gatwick (LGW)")]
        Lgw = 4,
        [Display(Name = "Any London Airport")]
        AnyLondon = 6,
        [Display(Name = "Malaga Airport (AGP)")]
        Agp = 8,
        [Display(Name = "Mallorca Airport (PMI)")]
        Pmi = 16,
        [Display(Name = "Gran Canaria Airport (LPA)")]
        Lpa = 32,
        [Display(Name = "Tenerife South Airport (TFS)")]
        TFS = 64,
        [Display(Name = "Any Airport")]
        AnyAirport = 127
    }
}
