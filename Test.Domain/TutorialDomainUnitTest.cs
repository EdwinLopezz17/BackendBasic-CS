using LearningCenter.Domain;
using LearningCenter.Infraestructure.Interfases;
using LearningCenter.Infraestructure.Models;
using Moq;

namespace Test.Domain;

public class TutorialDomainUnitTest
{
    [Fact]
    public void save_ValidObject_ReturnTrue()
    {
        //Arrange
        Tutorial tutorial = new Tutorial()
        {
            name = "Test Prueba",
        };
        //Mock
        var tutorialInfraestructure = new Mock<ITutorialInfraestructure>();
        tutorialInfraestructure.Setup(t => t.save(tutorial)).Returns(true);

        TutorialDomain tutorialDomain = new TutorialDomain(tutorialInfraestructure.Object);

        //Act
        var result = tutorialDomain.save(tutorial);
        
        //Assert
        Assert.Equal(true, result);
    }
    
    [Fact]
    public void save_InValidObject_ReturnExecption()
    {
        //Arrange
        Tutorial tutorial = new Tutorial()
        {
            name = "Te",
        };
        //Mock
        var tutorialInfraestructure = new Mock<ITutorialInfraestructure>();
        tutorialInfraestructure.Setup(t => t.save(tutorial)).Returns(true);

        TutorialDomain tutorialDomain = new TutorialDomain(tutorialInfraestructure.Object);

        //Act
        var ex = Assert.Throws<Exception>(() => tutorialDomain.save(tutorial));
        
        //Assert
        Assert.Equal("less than 3", ex.Message);
    }
}