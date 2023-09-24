using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BI*9P*8SURaU*C*i*4j*Br*8*1";

		var expected = new BI_BeginningSegmentForAutomotiveInspection()
		{
			StandardCarrierAlphaCode = "9P",
			Date = "8SURaU",
			InspectionLocationTypeCode = "C",
			RampIdentification = "i",
			CityName = "4j",
			StateOrProvinceCode = "Br",
			InspectorIdentityCode = "8",
			DamageCodeQualifier = "1",
		};

		var actual = Map.MapObject<BI_BeginningSegmentForAutomotiveInspection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9P", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BI_BeginningSegmentForAutomotiveInspection();
		subject.Date = "8SURaU";
		subject.InspectionLocationTypeCode = "C";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "4j";
			subject.StateOrProvinceCode = "Br";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8SURaU", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BI_BeginningSegmentForAutomotiveInspection();
		subject.StandardCarrierAlphaCode = "9P";
		subject.InspectionLocationTypeCode = "C";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "4j";
			subject.StateOrProvinceCode = "Br";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredInspectionLocationTypeCode(string inspectionLocationTypeCode, bool isValidExpected)
	{
		var subject = new BI_BeginningSegmentForAutomotiveInspection();
		subject.StandardCarrierAlphaCode = "9P";
		subject.Date = "8SURaU";
		subject.InspectionLocationTypeCode = inspectionLocationTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "4j";
			subject.StateOrProvinceCode = "Br";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4j", "Br", true)]
	[InlineData("4j", "", false)]
	[InlineData("", "Br", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new BI_BeginningSegmentForAutomotiveInspection();
		subject.StandardCarrierAlphaCode = "9P";
		subject.Date = "8SURaU";
		subject.InspectionLocationTypeCode = "C";
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
