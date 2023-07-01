namespace LearningCenter.Infraestructure.Models;

public class Category
{
    public int id { get; set; }
    public string description { get; set; }
    
    public List<Tutorial> tutorials { get; set; }
    
    //uno a muchos
    //public Tutorial tutorial { get; set; }
}