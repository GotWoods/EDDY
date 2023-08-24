using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BI*Gh*rKfFIA*X*J*On*SL*3*Z";

		var expected = new BI_BeginningSegmentForAutomotiveInspection()
		{
			StandardCarrierAlphaCode = "Gh",
			Date = "rKfFIA",
			InspectionLocationTypeCode = "X",
			RampIdentification = "J",
			CityName = "On",
			StateOrProvinceCode = "SL",
			InspectorIdentityCode = "3",
			DamageCodeQualifier = "Z",
		};

		var actual = Map.MapObject<BI_BeginningSegmentForAutomotiveInspection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Gh", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BI_BeginningSegmentForAutomotiveInspection();
		subject.Date = "rKfFIA";
		subject.InspectionLocationTypeCode = "X";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rKfFIA", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BI_BeginningSegmentForAutomotiveInspection();
		subject.StandardCarrierAlphaCode = "Gh";
		subject.InspectionLocationTypeCode = "X";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredInspectionLocationTypeCode(string inspectionLocationTypeCode, bool isValidExpected)
	{
		var subject = new BI_BeginningSegmentForAutomotiveInspection();
		subject.StandardCarrierAlphaCode = "Gh";
		subject.Date = "rKfFIA";
		subject.InspectionLocationTypeCode = inspectionLocationTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
