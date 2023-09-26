using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class EXITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EXI**7*Ox*b*X*4*q*u";

		var expected = new EXI_ExcavationTicketInformation()
		{
			ReferenceIdentifier = null,
			Priority = 7,
			DateTimePeriodFormatQualifier = "Ox",
			DateTimePeriod = "b",
			TimePeriodQualifier = "X",
			Quantity = 4,
			Description = "q",
			ActionCode = "u",
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
		subject.Priority = 7;
		subject.DateTimePeriodFormatQualifier = "Ox";
		subject.DateTimePeriod = "b";
		//Test Parameters
		if (referenceIdentifier != "") 
			subject.ReferenceIdentifier = new C040_ReferenceIdentifier();
		//At Least one
		subject.Quantity = 4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredPriority(int priority, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		//Required fields
		subject.ReferenceIdentifier = new C040_ReferenceIdentifier();
		subject.DateTimePeriodFormatQualifier = "Ox";
		subject.DateTimePeriod = "b";
		//Test Parameters
		if (priority > 0) 
			subject.Priority = priority;
		//At Least one
		subject.Quantity = 4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ox", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		//Required fields
		subject.ReferenceIdentifier = new C040_ReferenceIdentifier();
		subject.Priority = 7;
		subject.DateTimePeriod = "b";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//At Least one
		subject.Quantity = 4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		//Required fields
		subject.ReferenceIdentifier = new C040_ReferenceIdentifier();
		subject.Priority = 7;
		subject.DateTimePeriodFormatQualifier = "Ox";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//At Least one
		subject.Quantity = 4;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("X", 4, true)]
	[InlineData("X", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredQuantity(string timePeriodQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		//Required fields
		subject.ReferenceIdentifier = new C040_ReferenceIdentifier();
		subject.Priority = 7;
		subject.DateTimePeriodFormatQualifier = "Ox";
		subject.DateTimePeriod = "b";
		//Test Parameters
		subject.TimePeriodQualifier = timePeriodQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", false)]
	[InlineData(4, "q", true)]
	[InlineData(4, "", true)]
	[InlineData(0, "q", true)]
	public void Validation_AtLeastOneQuantity(decimal quantity, string description, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		//Required fields
		subject.ReferenceIdentifier = new C040_ReferenceIdentifier();
		subject.Priority = 7;
		subject.DateTimePeriodFormatQualifier = "Ox";
		subject.DateTimePeriod = "b";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
