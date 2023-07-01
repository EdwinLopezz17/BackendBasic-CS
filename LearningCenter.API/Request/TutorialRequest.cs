using System.ComponentModel.DataAnnotations;

namespace LearningCenter.API.Request;

public class TutorialRequest
{
    [Required]
    [MaxLength(20)]
    [MinLength(3)]
    public string name { get; set; }
    public string description { get; set; }
    
    [Required]
    public int maxLenght { get; set; }
}