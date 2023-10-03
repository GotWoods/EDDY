using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v5050;
using Eddy.x12.Models.v5050.Composites;

namespace Eddy.x12.Tests.Models.v5050.Composites;

public class C058Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "d*E*V*h*Z*R*6";

		var expected = new C058_AdjustmentReason()
		{
			ClaimAdjustmentReasonCode = "d",
			CodeListQualifierCode = "E",
			IndustryCode = "V",
			IndustryCode2 = "h",
			IndustryCode3 = "Z",
			IndustryCode4 = "R",
			IndustryCode5 = "6",
		};

		var actual = Map.MapObject<C058_AdjustmentReason>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredClaimAdjustmentReasonCode(string claimAdjustmentReasonCode, bool isValidExpected)
	{
		var subject = new C058_AdjustmentReason();
		//Required fields
		//Test Parameters
		subject.ClaimAdjustmentReasonCode = claimAdjustmentReasonCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "E";
			subject.IndustryCode = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E", "V", true)]
	[InlineData("E", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredCodeListQualifierCode(string codeListQualifierCode, string industryCode, bool isValidExpected)
	{
		var subject = new C058_AdjustmentReason();
		//Required fields
		subject.ClaimAdjustmentReasonCode = "d";
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h", "V", true)]
	[InlineData("h", "", false)]
	[InlineData("", "V", true)]
	public void Validation_ARequiresBIndustryCode2(string industryCode2, string industryCode, bool isValidExpected)
	{
		var subject = new C058_AdjustmentReason();
		//Required fields
		subject.ClaimAdjustmentReasonCode = "d";
		//Test Parameters
		subject.IndustryCode2 = industryCode2;
		subject.IndustryCode = industryCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "E";
			subject.IndustryCode = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Z", "h", true)]
	[InlineData("Z", "", false)]
	[InlineData("", "h", true)]
	public void Validation_ARequiresBIndustryCode3(string industryCode3, string industryCode2, bool isValidExpected)
	{
		var subject = new C058_AdjustmentReason();
		//Required fields
		subject.ClaimAdjustmentReasonCode = "d";
		//Test Parameters
		subject.IndustryCode3 = industryCode3;
		subject.IndustryCode2 = industryCode2;
		//A Requires B
		if (industryCode2 != "")
			subject.IndustryCode = "V";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "E";
			subject.IndustryCode = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("R", "", false)]
	public void Validation_ARequiresBIndustryCode4(string industryCode4, string industryCode3, bool isValidExpected)
	{
		var subject = new C058_AdjustmentReason();
		//Required fields
		subject.ClaimAdjustmentReasonCode = "d";
		//Test Parameters
		subject.IndustryCode4 = industryCode4;
		subject.IndustryCode3 = industryCode3;
		//A Requires B
		if (industryCode3 != "")
			subject.IndustryCode2 = "h";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "E";
			subject.IndustryCode = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6", "", false)]
	public void Validation_ARequiresBIndustryCode5(string industryCode5, string industryCode4, bool isValidExpected)
	{
		var subject = new C058_AdjustmentReason();
		//Required fields
		subject.ClaimAdjustmentReasonCode = "d";
		//Test Parameters
		subject.IndustryCode5 = industryCode5;
		subject.IndustryCode4 = industryCode4;
		//A Requires B
		if (industryCode4 != "")
			subject.IndustryCode3 = "Z";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.CodeListQualifierCode) || !string.IsNullOrEmpty(subject.IndustryCode))
		{
			subject.CodeListQualifierCode = "E";
			subject.IndustryCode = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
