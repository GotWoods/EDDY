using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IGITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IGI*J*o*1*3*X*P";

		var expected = new IGI_InsurerOrGuarantorInformation()
		{
			InsurerGuarantorTypeCode = "J",
			CodeListQualifierCode = "o",
			IndustryCode = "1",
			MortgageInsuranceCoverageTypeCode = "3",
			InsurerCoverageIndicatorCode = "X",
			PayerResponsibilitySequenceNumberCode = "P",
		};

		var actual = Map.MapObject<IGI_InsurerOrGuarantorInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredInsurerGuarantorTypeCode(string insurerGuarantorTypeCode, bool isValidExpected)
	{
		var subject = new IGI_InsurerOrGuarantorInformation();
		subject.InsurerGuarantorTypeCode = insurerGuarantorTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("o", "1", true)]
	[InlineData("", "1", false)]
	[InlineData("o", "", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new IGI_InsurerOrGuarantorInformation();
		subject.InsurerGuarantorTypeCode = "J";
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
