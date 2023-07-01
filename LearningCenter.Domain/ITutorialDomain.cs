using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Domain;

public interface ITutorialDomain
{
    public Task<bool> saveAsync( Tutorial tutorial);

    public bool update(int id, string name);
    
    public bool delete(int id);
}