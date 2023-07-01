namespace LearningCenter.Infraestructure.Models;

public class Tutorial
{
    public int id { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public int maxLenght { get; set; }
    public bool isActive { get; set; }
}