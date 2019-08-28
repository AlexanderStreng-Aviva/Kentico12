using System.Collections.Generic;
using CMS.DocumentEngine;

namespace MedioClinic.Models.InlineEditors.Slideshow
{
    public class SlideshowEditorViewModel : InlineEditorViewModel
    {
        public string SwiperId { get; set; }
        public IEnumerable<DocumentAttachment> Images { get; set; }
    }
}