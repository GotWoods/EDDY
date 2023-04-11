using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class EXITests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "EXI**9*3W*e*h*1*V*c";

        var expected = new EXI_ExcavationTicketInformation
        {
            ReferenceIdentifier = null,
            Priority = 9,
            DateTimePeriodFormatQualifier = "3W",
            DateTimePeriod = "e",
            TimePeriodUnitQualifier = "h",
            Quantity = 1,
            Description = "V",
            ActionCode = "c"
        };

        var actual = Map.MapObject<EXI_ExcavationTicketInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("ab", true)]
    public void Validation_RequiredReferenceIdentifier(string referenceIdentifier, bool isValidExpected)
    {
        var subject = new EXI_ExcavationTicketInformation();
        subject.Priority = 9;
        subject.DateTimePeriodFormatQualifier = "3W";
        subject.DateTimePeriod = "e";
        subject.Description = "AD";
        if (referenceIdentifier != "")
            subject.ReferenceIdentifier = new C040_ReferenceIdentifier { ReferenceIdentification = referenceIdentifier };
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(9, true)]
    public void Validation_RequiredPriority(int priority, bool isValidExpected)
    {
        var subject = new EXI_ExcavationTicketInformation();
        subject.ReferenceIdentifier = new C040_ReferenceIdentifier { ReferenceIdentification = "AB" };
        subject.DateTimePeriodFormatQualifier = "3W";
        subject.DateTimePeriod = "e";
        subject.Description = "AD";
        if (priority > 0)
            subject.Priority = priority;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("3W", true)]
    public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
    {
        var subject = new EXI_ExcavationTicketInformation();
        subject.ReferenceIdentifier = new C040_ReferenceIdentifier { ReferenceIdentification = "AB" };
        subject.Priority = 9;
        subject.DateTimePeriod = "e";
        subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
        subject.Description = "AD";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("e", true)]
    public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
    {
        var subject = new EXI_ExcavationTicketInformation();
        subject.ReferenceIdentifier = new C040_ReferenceIdentifier { ReferenceIdentification = "AB" };
        subject.Priority = 9;
        subject.DateTimePeriodFormatQualifier = "3W";
        subject.DateTimePeriod = dateTimePeriod;
        subject.Description = "AD";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", 0, true)]
    [InlineData("h", 1, true)]
    [InlineData("", 1, false)]
    [InlineData("h", 0, false)]
    public void Validation_AllAreRequiredTimePeriodUnitQualifier(string timePeriodUnitQualifier, decimal quantity, bool isValidExpected)
    {
        var subject = new EXI_ExcavationTicketInformation();
        subject.ReferenceIdentifier = new C040_ReferenceIdentifier { ReferenceIdentification = "AB" };
        subject.Priority = 9;
        subject.DateTimePeriodFormatQualifier = "3W";
        subject.DateTimePeriod = "e";
        subject.Description = "AD";
        subject.TimePeriodUnitQualifier = timePeriodUnitQualifier;
        if (quantity > 0)
            subject.Quantity = quantity;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
    }

    [Theory]
    [InlineData(0, "", false)]
    [InlineData(1, "V", true)]
    [InlineData(0, "V", true)]
    [InlineData(1, "", true)]
    public void Validation_AtLeastOneQuantity(decimal quantity, string description, bool isValidExpected)
    {
        var subject = new EXI_ExcavationTicketInformation();
        subject.ReferenceIdentifier = new C040_ReferenceIdentifier { ReferenceIdentification = "AB" };
        subject.Priority = 9;
        subject.DateTimePeriodFormatQualifier = "3W";
        subject.DateTimePeriod = "e";
        subject.Description = "AD";
        if (quantity > 0)
        {
            subject.Quantity = quantity;
            subject.TimePeriodUnitQualifier = "A";
        }
        subject.Description = description;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
    }
}