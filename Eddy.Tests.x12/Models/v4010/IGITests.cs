using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class IGITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IGI*h*m*F*7*d*l";

		var expected = new IGI_InsurerOrGuarantorInformation()
		{
			InsurerGuarantorTypeCode = "h",
			CodeListQualifierCode = "m",
			IndustryCode = "F",
			MortgageInsuranceCoverageTypeCode = "7",
			InsurerCoverageIndicatorCode = "d",
			PayerResponsibilitySequenceNumberCode = "l",
		};

		var actual = Map.MapObject<IGI_InsurerOrGuarantorInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredInsurerGuarantorTypeCode(string insurerGuarantorTypeCode, bool isValidExpected)
	{
		var subject = new IGI_InsurerOrGuarantorInformation();
		//Required fields
		//Test Parameters
		subject.InsurerGuarantorTypeCode = insurerGuarantorTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("m", "F", true)]
	[InlineData("m", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredIndustryCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new IGI_InsurerOrGuarantorInformation();
		//Required fields
		subject.InsurerGuarantorTypeCode = "h";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
