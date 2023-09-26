using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class CALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAL*lC*O*KG*dFf*LaX71OMX*t6Ww*kk*F*iNU*1Ahjtep9*YOU2*cf*n*qp*7*F";

		var expected = new CAL_Calendar()
		{
			ReferenceIdentificationQualifier = "lC",
			ReferenceIdentification = "O",
			UnitOfTimePeriodOrInterval = "KG",
			DateTimeQualifier = "dFf",
			Date = "LaX71OMX",
			Time = "t6Ww",
			TimeCode = "kk",
			ShipDeliveryOrCalendarPatternCode = "F",
			DateTimeQualifier2 = "iNU",
			Date2 = "1Ahjtep9",
			Time2 = "YOU2",
			TimeCode2 = "cf",
			ShipDeliveryOrCalendarPatternCode2 = "n",
			QuantityQualifier = "qp",
			Quantity = 7,
			FreeFormDescription = "F",
		};

		var actual = Map.MapObject<CAL_Calendar>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lC", true)]
	public void Validation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		//Required fields
		subject.ReferenceIdentification = "O";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "qp";
			subject.Quantity = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		//Required fields
		subject.ReferenceIdentificationQualifier = "lC";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.QuantityQualifier) || !string.IsNullOrEmpty(subject.QuantityQualifier) || subject.Quantity > 0)
		{
			subject.QuantityQualifier = "qp";
			subject.Quantity = 7;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("qp", 7, true)]
	[InlineData("qp", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		//Required fields
		subject.ReferenceIdentificationQualifier = "lC";
		subject.ReferenceIdentification = "O";
		//Test Parameters
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
