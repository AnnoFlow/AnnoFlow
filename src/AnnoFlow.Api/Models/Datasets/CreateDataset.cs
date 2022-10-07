using System.ComponentModel.DataAnnotations;

namespace AnnoFlow.Api.Models.Datasets
{
    public class CreateDataset
    {
        [Required]
        public Guid Id { get; set; }
    }
}