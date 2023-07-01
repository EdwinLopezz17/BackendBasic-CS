using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Infraestructure.Interfases;

public interface ITutorialInfraestructure
{
    Task<List<Tutorial>> GetAllAsync();

    Tutorial GetById(int id);
    
    public Task<bool> saveAsync(Tutorial tutorial);

    public bool update(int id, string name);
    
    public bool delete(int id);
}