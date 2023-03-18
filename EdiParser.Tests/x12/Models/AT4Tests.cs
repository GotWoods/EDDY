using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class AT4Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "AT4*gIRwPqK5VP5Ol6kVxuBimFLVqsGMYmtWWIjCQN8EBZ6cfSr1ZX";

        var expected = new AT4_BillOfLadingDescription()
        {
            LadingDescription = "gIRwPqK5VP5Ol6kVxuBimFLVqsGMYmtWWIjCQN8EBZ6cfSr1ZX",
        };

        var actual = Map.MapObject<AT4_BillOfLadingDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("gIRwPqK5VP5Ol6kVxuBimFLVqsGMYmtWWIjCQN8EBZ6cfSr1ZX", true)]
    public void Validatation_RequiredLadingDescription(string ladingDescription, bool isValidExpected)
    {
        var subject = new AT4_BillOfLadingDescription();
        subject.LadingDescription = ladingDescription;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}