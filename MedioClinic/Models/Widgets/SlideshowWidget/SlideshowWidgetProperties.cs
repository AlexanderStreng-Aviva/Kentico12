using System;
using Kentico.PageBuilder.Web.Mvc;

namespace MedioClinic.Models.Widgets.SlideshowWidget
{
    public class SlideshowWidgetProperties : IWidgetProperties
    {
        public Guid[] ImageIds { get; set; }
    }
}