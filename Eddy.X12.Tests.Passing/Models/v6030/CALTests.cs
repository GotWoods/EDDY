using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class CALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAL*kg*Z*EE*JvL*Uu9sG0YZ*Wptt*Oz*M*xxM*Wl5IOypw*2Dxs*3n*o*63*7*R";

		var expected = new CAL_Calendar()
		{
			ReferenceIdentificationQualifier = "kg",
			ReferenceIdentification = "Z",
			UnitOfTimePeriodOrIntervalCode = "EE",
			DateTimeQualifier = "JvL",
			Date = "Uu9sG0YZ",
			Time = "Wptt",
			TimeCode = "Oz",
			ShipDeliveryOrCalendarPatternCode = "M",
			DateTimeQualifier2 = "xxM",
			Date2 = "Wl5IOypw",
			Time2 = "2Dxs",
			TimeCode2 = "3n",
			ShipDeliveryOrCalendarPatternCode2 = "o",
			QuantityQualifier = "63",
			Quantity = 7,
			FreeFormDescription = "R",
		};

		var actual = Map.MapObject<CAL_Calendar>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kg", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		//Required fields
		subject.ReferenceIdentification = "Z";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "63";
			subject.Quantity = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		//Required fields
		subject.ReferenceIdentificationQualifier = "kg";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "63";
			subject.Quantity = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("63", 7, true)]
	[InlineData("63", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		//Required fields
		subject.ReferenceIdentificationQualifier = "kg";
		subject.ReferenceIdentification = "Z";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
