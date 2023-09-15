using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BI*Kj*NHUiFN*c*T*OF*OW*U*G";

		var expected = new BI_BeginningSegmentForAutomotiveInspection()
		{
			StandardCarrierAlphaCode = "Kj",
			Date = "NHUiFN",
			InspectionLocationTypeCode = "c",
			RampIdentification = "T",
			CityName = "OF",
			StateOrProvinceCode = "OW",
			InspectorIdentityCode = "U",
			DamageCodeQualifier = "G",
		};

		var actual = Map.MapObject<BI_BeginningSegmentForAutomotiveInspection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kj", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BI_BeginningSegmentForAutomotiveInspection();
		subject.Date = "NHUiFN";
		subject.InspectionLocationTypeCode = "c";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "OF";
			subject.StateOrProvinceCode = "OW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NHUiFN", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BI_BeginningSegmentForAutomotiveInspection();
		subject.StandardCarrierAlphaCode = "Kj";
		subject.InspectionLocationTypeCode = "c";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "OF";
			subject.StateOrProvinceCode = "OW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredInspectionLocationTypeCode(string inspectionLocationTypeCode, bool isValidExpected)
	{
		var subject = new BI_BeginningSegmentForAutomotiveInspection();
		subject.StandardCarrierAlphaCode = "Kj";
		subject.Date = "NHUiFN";
		subject.InspectionLocationTypeCode = inspectionLocationTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.CityName) || !string.IsNullOrEmpty(subject.StateOrProvinceCode))
		{
			subject.CityName = "OF";
			subject.StateOrProvinceCode = "OW";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("OF", "OW", true)]
	[InlineData("OF", "", false)]
	[InlineData("", "OW", false)]
	public void Validation_AllAreRequiredCityName(string cityName, string stateOrProvinceCode, bool isValidExpected)
	{
		var subject = new BI_BeginningSegmentForAutomotiveInspection();
		subject.StandardCarrierAlphaCode = "Kj";
		subject.Date = "NHUiFN";
		subject.InspectionLocationTypeCode = "c";
		subject.CityName = cityName;
		subject.StateOrProvinceCode = stateOrProvinceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
