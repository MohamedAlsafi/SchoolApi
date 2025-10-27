using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using School.Shared.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Shared.Helper
{
    public static class LZ
    {
        private static IStringLocalizer<SharedResources>? _localizer;

        public static void Configure(IServiceProvider serviceProvider)
        {
            _localizer = serviceProvider.GetRequiredService<IStringLocalizer<SharedResources>>();
        }

        public static string Translate(string key)
        {
            if (_localizer is null)
                return key;

            return _localizer[key];
        }
        public static string LocalizeMap(string? nameAr, string? nameEn)
        {
            bool isArabic = Thread.CurrentThread.CurrentUICulture
                .TwoLetterISOLanguageName.Equals("ar", StringComparison.OrdinalIgnoreCase);

            string? primary = isArabic ? nameAr : nameEn;
            string? fallback = isArabic ? nameEn : nameAr;

            return !string.IsNullOrWhiteSpace(primary) ? primary! : (fallback ?? string.Empty);
        }
    }

}
