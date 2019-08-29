﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CMS.DocumentEngine;
using Kentico.PageBuilder.Web.Mvc;
using MedioClinic.Controllers.Widgets;
using MedioClinic.Models.Widgets.SlideshowWidget;

[assembly:
    RegisterWidget("MedioClinic.Widget.Slideshow", 
        typeof(SlideshowWidgetController),
        "{$Widget.Slideshow.Name$}",
        Description = "{$Widget.Slideshow.Description$}",
        IconClass = "icon-carousel")]

namespace MedioClinic.Controllers.Widgets
{
    public class SlideshowWidgetController : WidgetController<SlideshowWidgetProperties>
    {
        public ActionResult Index()
        {
            var properties = GetProperties();
            if (properties == null)
            {
                return HttpNotFound();
            }

            var images = GetImages(properties?.ImageIds);
            return PartialView("Widgets/_SlideshowWidget", new SlideshowWidgetViewModel
            {
                Images = images,
                Width = properties.Width,
                Height = properties.Height,
                EnforceDimensions = properties.EnforceDimensions,
                TransitionDelay = properties.TransitionDelay,
                TransitionSpeed = properties.TransitionSpeed,
                DisplayArrowSigns = properties.DisplayArrowSigns
            });
        }

        protected IEnumerable<DocumentAttachment> GetImages(IEnumerable<Guid> guids)
        {
            var page = GetPage();

            if (guids != null && guids.Any())
            {
                var guidList = guids.ToList();

                return page?
                    .AllAttachments
                    .Where(attachment => guids.Any(guid => guid == attachment.AttachmentGUID))
                    .OrderBy(attachment => guidList.IndexOf(attachment.AttachmentGUID))
                    .ToList();
            }

            return new List<DocumentAttachment>();
        }
    }
}