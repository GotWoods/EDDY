using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class NTETests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "NTE*vFe*B";

        var expected = new NTE_Note()
        {
            NoteReferenceCode = "vFe",
            Description = "B",
        };

        var actual = Map.MapObject<NTE_Note>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("v1", true)]
    public void Validatation_RequiredDescription(string description, bool isValidExpected)
    {
        var subject = new NTE_Note();
        subject.Description = description;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}