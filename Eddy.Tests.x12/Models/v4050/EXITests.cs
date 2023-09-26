using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class EXITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EXI**9*KE*D*X*7*P*r";

		var expected = new EXI_ExcavationTicketInformation()
		{
			ReferenceIdentifier = null,
			Priority = 9,
			DateTimePeriodFormatQualifier = "KE",
			DateTimePeriod = "D",
			TimePeriodUnitQualifier = "X",
			Quantity = 7,
			Description = "P",
			ActionCode = "r",
		};

		var actual = Map.MapObject<EXI_ExcavationTicketInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredReferenceIdentifier(string referenceIdentifier, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		//Required fields
		subject.Priority = 9;
		subject.DateTimePeriodFormatQualifier = "KE";
		subject.DateTimePeriod = "D";
		//Test Parameters
		if (referenceIdentifier != "") 
			subject.ReferenceIdentifier = new C040_ReferenceIdentifier();
		//At Least one
		subject.Quantity = 7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredPriority(int priority, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		//Required fields
		subject.ReferenceIdentifier = new C040_ReferenceIdentifier();
		subject.DateTimePeriodFormatQualifier = "KE";
		subject.DateTimePeriod = "D";
		//Test Parameters
		if (priority > 0) 
			subject.Priority = priority;
		//At Least one
		subject.Quantity = 7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KE", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		//Required fields
		subject.ReferenceIdentifier = new C040_ReferenceIdentifier();
		subject.Priority = 9;
		subject.DateTimePeriod = "D";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//At Least one
		subject.Quantity = 7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		//Required fields
		subject.ReferenceIdentifier = new C040_ReferenceIdentifier();
		subject.Priority = 9;
		subject.DateTimePeriodFormatQualifier = "KE";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//At Least one
		subject.Quantity = 7;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("X", 7, true)]
	[InlineData("X", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredQuantity(string timePeriodUnitQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		//Required fields
		subject.ReferenceIdentifier = new C040_ReferenceIdentifier();
		subject.Priority = 9;
		subject.DateTimePeriodFormatQualifier = "KE";
		subject.DateTimePeriod = "D";
		//Test Parameters
		subject.TimePeriodUnitQualifier = timePeriodUnitQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", false)]
	[InlineData(7, "P", true)]
	[InlineData(7, "", true)]
	[InlineData(0, "P", true)]
	public void Validation_AtLeastOneQuantity(decimal quantity, string description, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		//Required fields
		subject.ReferenceIdentifier = new C040_ReferenceIdentifier();
		subject.Priority = 9;
		subject.DateTimePeriodFormatQualifier = "KE";
		subject.DateTimePeriod = "D";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
