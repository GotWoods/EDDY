using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAL*Br*q*vj*wxz*bMWigZ*JLgv*BG*Q*Kn6*WxbJhb*Jwxm*4s*9*LD*9*T";

		var expected = new CAL_Calendar()
		{
			ReferenceIdentificationQualifier = "Br",
			ReferenceIdentification = "q",
			UnitOfTimePeriodOrInterval = "vj",
			DateTimeQualifier = "wxz",
			Date = "bMWigZ",
			Time = "JLgv",
			TimeCode = "BG",
			ShipDeliveryOrCalendarPatternCode = "Q",
			DateTimeQualifier2 = "Kn6",
			Date2 = "WxbJhb",
			Time2 = "Jwxm",
			TimeCode2 = "4s",
			ShipDeliveryOrCalendarPatternCode2 = "9",
			QuantityQualifier = "LD",
			Quantity = 9,
			FreeFormDescription = "T",
		};

		var actual = Map.MapObject<CAL_Calendar>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Br", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		//Required fields
		subject.ReferenceIdentification = "q";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "LD";
			subject.Quantity = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		//Required fields
		subject.ReferenceIdentificationQualifier = "Br";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "LD";
			subject.Quantity = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("LD", 9, true)]
	[InlineData("LD", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		//Required fields
		subject.ReferenceIdentificationQualifier = "Br";
		subject.ReferenceIdentification = "q";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
