﻿using System.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using MedioClinic.Controllers.Widgets;
using MedioClinic.Models.Widgets.TextWidget;

[assembly:RegisterWidget("MedioClinic.Widget.Text", typeof(TextWidgetController), "Text editor widget",
        Description = "Default text editor widget with limited functionality", IconClass = "icon-l-text")]

namespace MedioClinic.Controllers.Widgets
{
    public class TextWidgetController : WidgetController<TextWidgetProperties>
    {
        public ActionResult Index()
        {
            var properties = GetProperties();
            return PartialView("Widgets/_TextWidget", new TextWidgetViewModel {Text = properties.Text});
        }
    }
}