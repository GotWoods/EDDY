using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class T1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "T1*2*7*54oAqNQW*w2*z4*mj*CY3EpZ*c*l*BQ*o";

		var expected = new T1_TransitInboundOrigin()
		{
			AssignedNumber = 2,
			WaybillNumber = 7,
			Date = "54oAqNQW",
			StandardCarrierAlphaCode = "w2",
			CityName = "z4",
			StateOrProvinceCode = "mj",
			StandardPointLocationCode = "CY3EpZ",
			TransitRegistrationNumber = "c",
			TransitLevelCode = "l",
			ReferenceIdentificationQualifier = "BQ",
			ReferenceIdentification = "o",
		};

		var actual = Map.MapObject<T1_TransitInboundOrigin>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredAssignedNumber(int assignedNumber, bool isValidExpected)
	{
		var subject = new T1_TransitInboundOrigin();
		if (assignedNumber > 0)
			subject.AssignedNumber = assignedNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "z4";
			subject.StateOrProvinceCode = "mj";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "BQ";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z4", "mj", true)]
	[InlineData("z4", "", false)]
	[InlineData("", "mj", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new T1_TransitInboundOrigin();
		subject.AssignedNumber = 2;
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "BQ";
			subject.ReferenceIdentification = "o";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("BQ", "o", true)]
	[InlineData("BQ", "", false)]
	[InlineData("", "o", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new T1_TransitInboundOrigin();
		subject.AssignedNumber = 2;
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "z4";
			subject.StateOrProvinceCode = "mj";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
