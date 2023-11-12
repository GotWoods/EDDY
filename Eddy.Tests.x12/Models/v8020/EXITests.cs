using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;
using Eddy.x12.Models.v8020.Composites;

namespace Eddy.x12.Tests.Models.v8020;

public class EXITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EXI**9*TU*A*z*3*b*Z";

		var expected = new EXI_ExcavationTicketInformation()
		{
			ReferenceIdentifier = null,
			Priority = 9,
			DateTimePeriodFormatQualifier = "TU",
			DateTimePeriod = "A",
			TimePeriodUnitQualifier = "z",
			Quantity = 3,
			Description = "b",
			ActionCode = "Z",
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
		subject.DateTimePeriodFormatQualifier = "TU";
		subject.DateTimePeriod = "A";
		//Test Parameters
		if (referenceIdentifier != "") 
			subject.ReferenceIdentifier = new C040_ReferenceIdentifier();
		//At Least one
		subject.Quantity = 3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimePeriodUnitQualifier) || !string.IsNullOrEmpty(subject.TimePeriodUnitQualifier) || subject.Quantity > 0)
		{
			subject.TimePeriodUnitQualifier = "z";
			subject.Quantity = 3;
		}
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
		subject.DateTimePeriodFormatQualifier = "TU";
		subject.DateTimePeriod = "A";
		//Test Parameters
		if (priority > 0) 
			subject.Priority = priority;
		//At Least one
		subject.Quantity = 3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimePeriodUnitQualifier) || !string.IsNullOrEmpty(subject.TimePeriodUnitQualifier) || subject.Quantity > 0)
		{
			subject.TimePeriodUnitQualifier = "z";
			subject.Quantity = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TU", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		//Required fields
		subject.ReferenceIdentifier = new C040_ReferenceIdentifier();
		subject.Priority = 9;
		subject.DateTimePeriod = "A";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		//At Least one
		subject.Quantity = 3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimePeriodUnitQualifier) || !string.IsNullOrEmpty(subject.TimePeriodUnitQualifier) || subject.Quantity > 0)
		{
			subject.TimePeriodUnitQualifier = "z";
			subject.Quantity = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		//Required fields
		subject.ReferenceIdentifier = new C040_ReferenceIdentifier();
		subject.Priority = 9;
		subject.DateTimePeriodFormatQualifier = "TU";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		//At Least one
		subject.Quantity = 3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimePeriodUnitQualifier) || !string.IsNullOrEmpty(subject.TimePeriodUnitQualifier) || subject.Quantity > 0)
		{
			subject.TimePeriodUnitQualifier = "z";
			subject.Quantity = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("z", 3, true)]
	[InlineData("z", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredTimePeriodUnitQualifier(string timePeriodUnitQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		//Required fields
		subject.ReferenceIdentifier = new C040_ReferenceIdentifier();
		subject.Priority = 9;
		subject.DateTimePeriodFormatQualifier = "TU";
		subject.DateTimePeriod = "A";
		//Test Parameters
		subject.TimePeriodUnitQualifier = timePeriodUnitQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.Description = "b";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", false)]
	[InlineData(3, "b", true)]
	[InlineData(3, "", true)]
	[InlineData(0, "b", true)]
	public void Validation_AtLeastOneQuantity(decimal quantity, string description, bool isValidExpected)
	{
		var subject = new EXI_ExcavationTicketInformation();
		//Required fields
		subject.ReferenceIdentifier = new C040_ReferenceIdentifier();
		subject.Priority = 9;
		subject.DateTimePeriodFormatQualifier = "TU";
		subject.DateTimePeriod = "A";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TimePeriodUnitQualifier) || !string.IsNullOrEmpty(subject.TimePeriodUnitQualifier) || subject.Quantity > 0)
		{
			subject.TimePeriodUnitQualifier = "z";
			subject.Quantity = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
