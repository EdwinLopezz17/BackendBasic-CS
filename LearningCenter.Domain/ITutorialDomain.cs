using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Domain;

public interface ITutorialDomain
{
    public bool save( Tutorial tutorial);

    public bool update(int id, string name);
    
    public bool delete(int id);
}