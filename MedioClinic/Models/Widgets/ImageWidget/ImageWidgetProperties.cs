using System;
using Kentico.PageBuilder.Web.Mvc;

namespace MedioClinic.Models.Widgets.ImageWidget
{
    public class ImageWidgetProperties : IWidgetProperties
    {
        public Guid ImageGuid { get; set; }
    }
}