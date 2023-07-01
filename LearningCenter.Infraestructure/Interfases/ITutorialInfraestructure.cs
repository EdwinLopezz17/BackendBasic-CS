using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Infraestructure.Interfases;

public interface ITutorialInfraestructure
{
    List<Tutorial> GetAll();

    Tutorial GetById(int id);
    
    public bool save(Tutorial tutorial);

    public bool update(int id, string name);
    
    public bool delete(int id);
}