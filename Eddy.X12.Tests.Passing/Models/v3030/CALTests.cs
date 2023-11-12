using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAL*kp*1*lQ*WZu*cV14aH*Jtg5*Er*I*uIl*E0pN6p*iCdx*ZW*N";

		var expected = new CAL_Calendar()
		{
			ReferenceNumberQualifier = "kp",
			ReferenceNumber = "1",
			UnitOfTimePeriodOrInterval = "lQ",
			DateTimeQualifier = "WZu",
			Date = "cV14aH",
			Time = "Jtg5",
			TimeCode = "Er",
			ShipDeliveryOrCalendarPatternCode = "I",
			DateTimeQualifier2 = "uIl",
			Date2 = "E0pN6p",
			Time2 = "iCdx",
			TimeCode2 = "ZW",
			ShipDeliveryOrCalendarPatternCode2 = "N",
		};

		var actual = Map.MapObject<CAL_Calendar>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kp", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		//Required fields
		subject.ReferenceNumber = "1";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new CAL_Calendar();
		//Required fields
		subject.ReferenceNumberQualifier = "kp";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
