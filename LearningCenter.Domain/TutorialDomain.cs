using LearningCenter.Infraestructure.Interfases;
using LearningCenter.Infraestructure.Models;

namespace LearningCenter.Domain;

public class TutorialDomain: ITutorialDomain
{

    private ITutorialInfraestructure _tutorialInfraestructure;

    public TutorialDomain(ITutorialInfraestructure tutorialInfraestructure)
    {
        _tutorialInfraestructure = tutorialInfraestructure;
    }
    
    public bool save(Tutorial tutorial)
    {
        if (!IsValidName(tutorial.name)) throw new Exception("less than 3");
        return _tutorialInfraestructure.save(tutorial);
    }

    public bool update(int id, string name)
    {
        if (!IsValidName(name)) throw new Exception("less than 3");
        return _tutorialInfraestructure.update(id, name);
    }

    public bool delete(int id)
    {
        return _tutorialInfraestructure.delete(id);
    }


    private bool IsValidName(string name)
    {
        if (name.Length < 3) return false;
        return true;
    }
}