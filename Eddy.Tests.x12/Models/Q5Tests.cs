using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class Q5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q5*O*f2SuaXp3*WdOG*hK*pGj*aN*5d*K6*o*k*8C*p*g*jO*1*b*5*u";

		var expected = new Q5_StatusDetails()
		{
			ShipmentStatusCode = "O",
			Date = "f2SuaXp3",
			Time = "WdOG",
			TimeCode = "hK",
			StatusReasonCode = "pGj",
			CityName = "aN",
			StateOrProvinceCode = "5d",
			CountryCode = "K6",
			EquipmentInitial = "o",
			EquipmentNumber = "k",
			ReferenceIdentificationQualifier = "8C",
			ReferenceIdentification = "p",
			DirectionIdentifierCode = "g",
			ReferenceIdentificationQualifier2 = "jO",
			ReferenceIdentification2 = "1",
			DirectionIdentifierCode2 = "b",
			PercentageAsDecimal = 5,
			PickupOrDeliveryCode = "u",
		};

		var actual = Map.MapObject<Q5_StatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("WdOG", "hK", true)]
	[InlineData("", "hK", false)]
	[InlineData("WdOG", "", false)]
	public void Validation_AllAreRequiredTime(string time, string timeCode, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.Time = time;
		subject.TimeCode = timeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "aN", true)]
	[InlineData("5d", "", false)]
	public void Validation_ARequiresBStateOrProvinceCode(string stateOrProvinceCode, string cityName, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.StateOrProvinceCode = stateOrProvinceCode;
		subject.CityName = cityName;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("8C", "p", true)]
	[InlineData("", "p", false)]
	[InlineData("8C", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "p", true)]
	[InlineData("g", "", false)]
	public void Validation_ARequiresBDirectionIdentifierCode(string directionIdentifierCode, string referenceIdentification, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.DirectionIdentifierCode = directionIdentifierCode;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("jO", "1", true)]
	[InlineData("", "1", false)]
	[InlineData("jO", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "1", true)]
	[InlineData("b", "", false)]
	public void Validation_ARequiresBDirectionIdentifierCode2(string directionIdentifierCode2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new Q5_StatusDetails();
		subject.DirectionIdentifierCode2 = directionIdentifierCode2;
		subject.ReferenceIdentification2 = referenceIdentification2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
