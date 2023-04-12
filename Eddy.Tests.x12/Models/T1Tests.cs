using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class T1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T1*4*5*7IT1NZCN*Ov*do*YL*d1kUvs*n*h*mD*R";

		var expected = new T1_TransitInboundOrigin()
		{
			AssignedNumber = 4,
			WaybillNumber = 5,
			Date = "7IT1NZCN",
			StandardCarrierAlphaCode = "Ov",
			CityName = "do",
			StateOrProvinceCode = "YL",
			StandardPointLocationCode = "d1kUvs",
			TransitRegistrationNumber = "n",
			TransitLevelCode = "h",
			ReferenceIdentificationQualifier = "mD",
			ReferenceIdentification = "R",
		};

		var actual = Map.MapObject<T1_TransitInboundOrigin>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T1_TransitInboundOrigin();
		if (assignedNumber > 0)
		subject.AssignedNumber = assignedNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("do", "YL", true)]
	[InlineData("", "YL", false)]
	[InlineData("do", "", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new T1_TransitInboundOrigin();
		subject.AssignedNumber = 4;
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("mD", "R", true)]
	[InlineData("", "R", false)]
	[InlineData("mD", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new T1_TransitInboundOrigin();
		subject.AssignedNumber = 4;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
