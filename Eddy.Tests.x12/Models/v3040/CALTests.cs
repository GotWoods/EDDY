using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAL*05*h*28*puF*7fKR1I*i4Ni*de*a*KEO*NOxelk*9xa3*Zx*c*h2*5*a";

		var expected = new CAL_Calendar()
		{
			ReferenceNumberQualifier = "05",
			ReferenceNumber = "h",
			UnitOfTimePeriodOrInterval = "28",
			DateTimeQualifier = "puF",
			Date = "7fKR1I",
			Time = "i4Ni",
			TimeCode = "de",
			ShipDeliveryOrCalendarPatternCode = "a",
			DateTimeQualifier2 = "KEO",
			Date2 = "NOxelk",
			Time2 = "9xa3",
			TimeCode2 = "Zx",
			ShipDeliveryOrCalendarPatternCode2 = "c",
			QuantityQualifier = "h2",
			Quantity = 5,
			FreeFormDescription = "a",
		};

		var actual = Map.MapObject<CAL_Calendar>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("05", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		//Required fields
		subject.ReferenceNumber = "h";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "h2";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		//Required fields
		subject.ReferenceNumberQualifier = "05";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "h2";
			subject.Quantity = 5;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("h2", 5, true)]
	[InlineData("h2", 0, false)]
	[InlineData("", 5, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		//Required fields
		subject.ReferenceNumberQualifier = "05";
		subject.ReferenceNumber = "h";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
