using LearningCenter.Domain;

namespace Test.Domain;

public class TestableClassUnitTest
{
    [Theory]
    [InlineData(10,20,30)]
    [InlineData(15,20,35)]
    [InlineData(15,25,40)]
    public void sum_ValidValues_ReturnSum(int numA, int numB, int expectedResult)
    {
        //Arrange
        TestableClass testableClass = new TestableClass();

        //Act
        var result = testableClass.sum(numA, numB);

        //Assert
        Assert.Equal(expectedResult,result);
    }
}