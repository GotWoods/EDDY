using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class CALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAL*BR*A*sy*dl9*ewj3eMRS*gC0o*UK*d*wQL*xMffdBbh*OpHN*qm*I*1K*1*j";

		var expected = new CAL_Calendar()
		{
			ReferenceIdentificationQualifier = "BR",
			ReferenceIdentification = "A",
			UnitOfTimePeriodOrInterval = "sy",
			DateTimeQualifier = "dl9",
			Date = "ewj3eMRS",
			Time = "gC0o",
			TimeCode = "UK",
			ShipDeliveryOrCalendarPatternCode = "d",
			DateTimeQualifier2 = "wQL",
			Date2 = "xMffdBbh",
			Time2 = "OpHN",
			TimeCode2 = "qm",
			ShipDeliveryOrCalendarPatternCode2 = "I",
			QuantityQualifier = "1K",
			Quantity = 1,
			FreeFormDescription = "j",
		};

		var actual = Map.MapObject<CAL_Calendar>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BR", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		//Required fields
		subject.ReferenceIdentification = "A";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "1K";
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		//Required fields
		subject.ReferenceIdentificationQualifier = "BR";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "1K";
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("1K", 1, true)]
	[InlineData("1K", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		//Required fields
		subject.ReferenceIdentificationQualifier = "BR";
		subject.ReferenceIdentification = "A";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
