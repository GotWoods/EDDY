using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BI*ZS*bq7fVT*0*s*Jw*Fg*q*w";

		var expected = new BI_BeginningSegmentForAutomotiveInspection()
		{
			StandardCarrierAlphaCode = "ZS",
			Date = "bq7fVT",
			InspectionLocationTypeCode = "0",
			RampIdentification = "s",
			CityName = "Jw",
			StateOrProvinceCode = "Fg",
			InspectorIdentityCode = "q",
			DamageCodeQualifier = "w",
		};

		var actual = Map.MapObject<BI_BeginningSegmentForAutomotiveInspection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZS", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BI_BeginningSegmentForAutomotiveInspection();
		subject.Date = "bq7fVT";
		subject.InspectionLocationTypeCode = "0";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bq7fVT", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BI_BeginningSegmentForAutomotiveInspection();
		subject.StandardCarrierAlphaCode = "ZS";
		subject.InspectionLocationTypeCode = "0";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredInspectionLocationTypeCode(string inspectionLocationTypeCode, bool isValidExpected)
	{
		var subject = new BI_BeginningSegmentForAutomotiveInspection();
		subject.StandardCarrierAlphaCode = "ZS";
		subject.Date = "bq7fVT";
		subject.InspectionLocationTypeCode = inspectionLocationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
