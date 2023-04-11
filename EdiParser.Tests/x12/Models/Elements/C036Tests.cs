using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C036Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "f*C*W*4*1";

        var expected = new C036_IndexIdentification()
        {
            ConfigurationTypeCode = "f",
            ReferenceIdentification = "C",
            ReferenceIdentification2 = "W",
            XPeg = 4,
            YPeg = 1,
        };

        var actual = Map.MapObject<C036_IndexIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("C", "W", true)]
    [InlineData("", "W", false)]
    [InlineData("C", "", false)]
    public void Validation_AllAreRequiredReferenceIdentification(string referenceIdentification, string referenceIdentification2, bool isValidExpected)
    {
        var subject = new C036_IndexIdentification();
        subject.ReferenceIdentification = referenceIdentification;
        subject.ReferenceIdentification2 = referenceIdentification2;
        subject.XPeg = 4;
        subject.YPeg = 1;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData("", 0, false)]
    [InlineData("C", 4, true)]
    [InlineData("", 4, true)]
    [InlineData("C", 0, true)]
    public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, decimal xPeg, bool isValidExpected)
    {
        var subject = new C036_IndexIdentification();
        subject.ReferenceIdentification = referenceIdentification;
        if (referenceIdentification != "")
            subject.ReferenceIdentification2 = "B";

        if (xPeg > 0)
        {
            subject.XPeg = xPeg;
            subject.YPeg = xPeg;
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }

    [Theory]
    [InlineData(0, 0, true)]
    [InlineData(4, 1, true)]
    [InlineData(0, 1, false)]
    [InlineData(4, 0, false)]
    public void Validation_AllAreRequiredXPeg(decimal xPeg, decimal yPeg, bool isValidExpected)
    {
        var subject = new C036_IndexIdentification();
        subject.ReferenceIdentification = "A";
        subject.ReferenceIdentification2 = "B";
        if (xPeg > 0)
            subject.XPeg = xPeg;
        if (yPeg > 0)
            subject.YPeg = yPeg;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

}