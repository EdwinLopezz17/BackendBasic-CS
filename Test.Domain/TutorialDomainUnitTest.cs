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
        tutorialInfraestructure.Setup(t => t.saveAsync(tutorial)).ReturnsAsync(true);

        TutorialDomain tutorialDomain = new TutorialDomain(tutorialInfraestructure.Object);

        //Act
        var result = tutorialDomain.saveAsync(tutorial);
        
        //Assert
        Assert.Equal(true, result.Result);
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
        tutorialInfraestructure.Setup(t => t.saveAsync(tutorial)).ReturnsAsync(true);

        TutorialDomain tutorialDomain = new TutorialDomain(tutorialInfraestructure.Object);

        //Act
        var ex = Assert.ThrowsAsync<Exception>(()  => tutorialDomain.saveAsync(tutorial));
        
        //Assert
        Assert.Equal("less than 3", ex.Result.Message);
    }
}