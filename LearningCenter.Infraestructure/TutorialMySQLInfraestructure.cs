using LearningCenter.Infraestructure.Context;
using LearningCenter.Infraestructure.Interfases;
using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Infraestructure;

public class TutorialMySQLInfraestructure: ITutorialInfraestructure
{

    private LearningCenterDBContext _learningCenterDbContext;

    public TutorialMySQLInfraestructure(LearningCenterDBContext learningCenterDbContext)
    {
        _learningCenterDbContext = learningCenterDbContext;
    }
    
    public List<Tutorial> GetAll()
    {

        return _learningCenterDbContext.Tutorials.Where(tutorial => tutorial.isActive).ToList();
        
        /*var result = from tutorials in _learningCenterDbContext.Tutorials
            where tutorials.isActive
            select tutorials;
        return result.ToList();*/
    }

    public Tutorial GetById(int id)
    {
       return _learningCenterDbContext.Tutorials.Find(id);
       
       //return _learningCenterDbContext.Tutorials.Single(tutorial => tutorial.id == id);
    }

    public bool save(Tutorial tutorial)
    {
        _learningCenterDbContext.Tutorials.Add(tutorial);
        _learningCenterDbContext.SaveChanges();
        return true;
    }

    public bool update(int id, string name)
    {
        Tutorial tutorial = _learningCenterDbContext.Tutorials.Find(id);
        tutorial.name = name;

        _learningCenterDbContext.Tutorials.Update(tutorial);
        _learningCenterDbContext.SaveChanges();

        return true;
    }

    public bool delete(int id)
    {
        Tutorial tutorial = _learningCenterDbContext.Tutorials.Find(id);
        tutorial.isActive = false;

        _learningCenterDbContext.Update(tutorial);
        //Eliminacion fisica
        //_learningCenterDbContext.Tutorials.Remove(tutorial);
        
        _learningCenterDbContext.SaveChanges();

        return true;
    }
}