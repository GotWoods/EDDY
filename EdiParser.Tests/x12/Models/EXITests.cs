using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class EXITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EXI**9*3W*e*h*1*V*c";

		var expected = new EXI_ExcavationTicketInformation()
		{
			ReferenceIdentifier = "",
			Priority = 9,
			DateTimePeriodFormatQualifier = "3W",
			DateTimePeriod = "e",
			TimePeriodUnitQualifier = "h",
			Quantity = 1,
			Description = "V",
			ActionCode = "c",
		};

		var actual = Map.MapObject<EXI_ExcavationTicketInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("", true)]
	public void Validatation_RequiredReferenceIdentifier(C040_ReferenceIdentifier referenceIdentifier, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		subject.Priority = 9;
		subject.DateTimePeriodFormatQualifier = "3W";
		subject.DateTimePeriod = "e";
		subject.ReferenceIdentifier = referenceIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validatation_RequiredPriority(int priority, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		subject.ReferenceIdentifier = "";
		subject.DateTimePeriodFormatQualifier = "3W";
		subject.DateTimePeriod = "e";
		if (priority > 0)
		subject.Priority = priority;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3W", true)]
	public void Validatation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		subject.ReferenceIdentifier = "";
		subject.Priority = 9;
		subject.DateTimePeriod = "e";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validatation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		subject.ReferenceIdentifier = "";
		subject.Priority = 9;
		subject.DateTimePeriodFormatQualifier = "3W";
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("h", 1, true)]
	[InlineData("", 1, false)]
	[InlineData("h", 0, false)]
	public void Validation_AllAreRequiredTimePeriodUnitQualifier(string timePeriodUnitQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		subject.ReferenceIdentifier = "";
		subject.Priority = 9;
		subject.DateTimePeriodFormatQualifier = "3W";
		subject.DateTimePeriod = "e";
		subject.TimePeriodUnitQualifier = timePeriodUnitQualifier;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", false)]
	[InlineData(1,"V", true)]
	[InlineData(0, "V", true)]
	[InlineData(1, "", true)]
	public void Validation_AtLeastOneQuantity(decimal quantity, string description, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		subject.ReferenceIdentifier = "";
		subject.Priority = 9;
		subject.DateTimePeriodFormatQualifier = "3W";
		subject.DateTimePeriod = "e";
		if (quantity > 0)
		subject.Quantity = quantity;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
