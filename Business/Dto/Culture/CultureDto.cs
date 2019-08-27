using System;

namespace Business.Dto.Culture
{
    public class CultureDto
    {
        public Guid CultureGuid { get; set; }
        public string CultureCode { get; set; }
        public string CultureName { get; set; }
        public string CultureShortName { get; set; }
    }
}