using System;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;

namespace MedioClinic.Models.Widgets.SlideshowWidget
{
    public class SlideshowWidgetProperties : IWidgetProperties
    {
        public Guid[] ImageIds { get; set; }

        [EditingComponent(IntInputComponent.IDENTIFIER, Label = "Transition delay (milliseconds)", Order = 1)]
        public int TransitionDelay { get; set; } = 5000;

        [EditingComponent(IntInputComponent.IDENTIFIER, Label = "Transition speed (milliseconds)", Order = 2)]
        public int TransitionSpeed { get; set; } = 300;

        [EditingComponent(CheckBoxComponent.IDENTIFIER, Label = "Display arrow signs on the live site", Order = 3)]
        public bool DisplayArrowSigns { get; set; } = true;

        [EditingComponent(CheckBoxComponent.IDENTIFIER, Label = "Enforce dimensions in live site", Order = 4)]
        public bool EnforceDimensions { get; set; }

        [EditingComponent(IntInputComponent.IDENTIFIER, Label = "Width (pixels)", Order = 5)]
        public int Width { get; set; }

        [EditingComponent(IntInputComponent.IDENTIFIER, Label = "Height (pixels)", Order = 6)]
        public int Height { get; set; }
    }
}