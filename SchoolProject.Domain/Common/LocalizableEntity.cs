using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Domain.Common
{
    public class LocalizableEntity
    {
        public string? NameAr { get; set; }
        public string? NameEn { get; set; }

        public string GetLocalized()
        {
            var isArabic = Thread.CurrentThread.CurrentUICulture
                .TwoLetterISOLanguageName.Equals("ar", StringComparison.OrdinalIgnoreCase);

            string? primary = isArabic ? NameAr : NameEn;
            string? fallback = isArabic ? NameEn : NameAr;

            return !string.IsNullOrWhiteSpace(primary) ? primary! : (fallback ?? string.Empty);
        }

        
        public string LocalizedName => GetLocalized();

      
        public override string ToString() => GetLocalized();
    }
}
