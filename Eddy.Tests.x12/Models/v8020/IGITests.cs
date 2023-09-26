using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class IGITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IGI*7*x*S*I*d*2";

		var expected = new IGI_InsurerOrGuarantorInformation()
		{
			InsurerGuarantorTypeCode = "7",
			CodeListQualifierCode = "x",
			IndustryCode = "S",
			MortgageInsuranceCoverageTypeCode = "I",
			InsurerCoverageIndicatorCode = "d",
			PayerResponsibilitySequenceNumberCode = "2",
		};

		var actual = Map.MapObject<IGI_InsurerOrGuarantorInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredInsurerGuarantorTypeCode(string insurerGuarantorTypeCode, bool isValidExpected)
	{
		var subject = new IGI_InsurerOrGuarantorInformation();
		//Required fields
		//Test Parameters
		subject.InsurerGuarantorTypeCode = insurerGuarantorTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "x";
			subject.IndustryCode = "S";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x", "S", true)]
	[InlineData("x", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new IGI_InsurerOrGuarantorInformation();
		//Required fields
		subject.InsurerGuarantorTypeCode = "7";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
