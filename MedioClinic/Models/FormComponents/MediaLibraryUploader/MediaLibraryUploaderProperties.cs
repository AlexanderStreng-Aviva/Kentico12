using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using CMS.DataEngine;
using Kentico.Forms.Web.Mvc;
using MedioClinic.Models.FormComponents.MediaLibrarySelection;

namespace MedioClinic.Models.FormComponents.MediaLibraryUploader
{
    public class MediaLibraryUploaderProperties : FormComponentProperties<string>
    {
        public MediaLibraryUploaderProperties() : base(FieldDataType.Text, 400)
        {
        }

        [DefaultValueEditingComponent(TextInputComponent.IDENTIFIER)]
        public override string DefaultValue { get; set; } = string.Empty;

        [EditingComponent(MediaLibrarySelectionComponent.Identifier,
            Label = "{$FormComponent.MediaLibraryUploader.MediaLibraryId.Name$}",
            Tooltip = "{$FormComponent.MediaLibraryUploader.MediaLibraryId.Tooltip$}",
            ExplanationText = "{$FormComponent.MediaLibraryUploader.MediaLibraryId.ExplanationText$}")]
        [Required]
        public string MediaLibraryId { get; set; }
    }
}