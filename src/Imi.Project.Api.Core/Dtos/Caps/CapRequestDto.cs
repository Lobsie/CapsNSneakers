using Imi.Project.Api.Core.Dtos.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Imi.Project.Api.Core.Dtos.Caps
{
    public class CapRequestDto : DtoBase
    {
        [Required(ErrorMessage = "Give your cap a name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "What is your cap made of?")]
        public string Material { get; set; }

        [Required(ErrorMessage = "What is the color of your cap?")]
        public string Colorway { get; set; }

        [Required(ErrorMessage = "Is this cap brandless!?")]
        public Guid BrandId { get; set; }

        [Required(ErrorMessage = "This cap doesn't fit!")]
        public Guid FittingId { get; set; }
    }
}