using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAL*Y4*O*p1*nXL*84qBtuwp*WEoG*0F*5*azQ*YfAxjDDq*CL4I*YI*P*ws*2*G";

		var expected = new CAL_Calendar()
		{
			ReferenceIdentificationQualifier = "Y4",
			ReferenceIdentification = "O",
			UnitOfTimePeriodOrIntervalCode = "p1",
			DateTimeQualifier = "nXL",
			Date = "84qBtuwp",
			Time = "WEoG",
			TimeCode = "0F",
			ShipDeliveryOrCalendarPatternCode = "5",
			DateTimeQualifier2 = "azQ",
			Date2 = "YfAxjDDq",
			Time2 = "CL4I",
			TimeCode2 = "YI",
			ShipDeliveryOrCalendarPatternCode2 = "P",
			QuantityQualifier = "ws",
			Quantity = 2,
			FreeFormDescription = "G",
		};

		var actual = Map.MapObject<CAL_Calendar>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y4", true)]
	public void Validatation_RequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		subject.ReferenceIdentification = "O";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		subject.ReferenceIdentificationQualifier = "Y4";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("ws", 2, true)]
	[InlineData("", 2, false)]
	[InlineData("ws", 0, false)]
	public void Validation_AllAreRequiredQuantityQualifier(string quantityQualifier, decimal quantity, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		subject.ReferenceIdentificationQualifier = "Y4";
		subject.ReferenceIdentification = "O";
		subject.QuantityQualifier = quantityQualifier;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
