using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models.Elements;

public class C074Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "l*G*p*i*u";

        var expected = new C074_CompositeDateTimePeriod()
        {
            DateTimePeriod = "l",
            DateTimePeriod2 = "G",
            DateTimePeriod3 = "p",
            DateTimePeriod4 = "i",
            DateTimePeriod5 = "u",
        };

        var actual = Map.MapObject<C074_CompositeDateTimePeriod>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("l", true)]
    public void Validatation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
    {
        var subject = new C074_CompositeDateTimePeriod();
        subject.DateTimePeriod = dateTimePeriod;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "G", true)]
    [InlineData("p", "", false)]
    public void Validation_ARequiresBDateTimePeriod3(string dateTimePeriod3, string dateTimePeriod2, bool isValidExpected)
    {
        var subject = new C074_CompositeDateTimePeriod();
        subject.DateTimePeriod = "l";
        subject.DateTimePeriod3 = dateTimePeriod3;
        subject.DateTimePeriod2 = dateTimePeriod2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "p", true)]
    [InlineData("i", "", false)]
    public void Validation_ARequiresBDateTimePeriod4(string dateTimePeriod4, string dateTimePeriod3, bool isValidExpected)
    {
        var subject = new C074_CompositeDateTimePeriod();
        subject.DateTimePeriod = "l";
        subject.DateTimePeriod4 = dateTimePeriod4;
        subject.DateTimePeriod3 = dateTimePeriod3;

        if (dateTimePeriod3 != "")
        {
            subject.DateTimePeriod2 = "i";
            subject.DateTimePeriod = "i";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "i", true)]
    [InlineData("u", "", false)]
    public void Validation_ARequiresBDateTimePeriod5(string dateTimePeriod5, string dateTimePeriod4, bool isValidExpected)
    {
        var subject = new C074_CompositeDateTimePeriod();
        subject.DateTimePeriod = "l";
        subject.DateTimePeriod5 = dateTimePeriod5;
        subject.DateTimePeriod4 = dateTimePeriod4;

        if (dateTimePeriod4 != "")
        {
            subject.DateTimePeriod3 = "i";
            subject.DateTimePeriod2 = "i";
            subject.DateTimePeriod = "i";
        }

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

}