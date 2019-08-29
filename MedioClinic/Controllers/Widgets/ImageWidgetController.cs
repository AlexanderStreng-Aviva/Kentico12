using System.Linq;
using System.Web.Mvc;
using CMS.DocumentEngine;
using Kentico.PageBuilder.Web.Mvc;
using MedioClinic.Controllers.Widgets;
using MedioClinic.Models.Widgets.ImageWidget;

[assembly: RegisterWidget("MedioClinic.Widget.Image", 
    typeof(ImageWidgetController), 
    "{$Widget.Image.Name$}", 
    Description = "{$Widget.Image.Description$}", 
    IconClass = "icon-picture")]
namespace MedioClinic.Controllers.Widgets
{
    public class ImageWidgetController : WidgetController<ImageWidgetProperties>
    {
        public ActionResult Index()
        {
            var properties = GetProperties();
            var image = GetImage(properties);

            return PartialView("Widgets/_ImageWidget", new ImageWidgetViewModel {Image = image});
        }

        private DocumentAttachment GetImage(ImageWidgetProperties properties)
        {
            var page = GetPage();
            return page?.AllAttachments.FirstOrDefault(x => x.AttachmentGUID == properties.ImageGuid);
        }
    }
}