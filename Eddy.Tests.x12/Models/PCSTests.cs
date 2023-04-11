using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PCS*T*ti*b*7*6*J*tR*q*zCU*Q*J";

		var expected = new PCS_ProductClaimStatus()
		{
			ClaimStatusCode = "T",
			AgencyQualifierCode = "ti",
			SourceSubqualifier = "b",
			ClaimResponseReasonCode = "7",
			MonetaryAmount = 6,
			FollowUpActionCode = "J",
			AgencyQualifierCode2 = "tR",
			SourceSubqualifier2 = "q",
			DispositionCode = "zCU",
			Description = "Q",
			AuthorizationIdentification = "J",
		};

		var actual = Map.MapObject<PCS_ProductClaimStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("T","7", true)]
	[InlineData("", "7", true)]
	[InlineData("T", "", true)]
	public void Validation_AtLeastOneClaimStatusCode(string claimStatusCode, string claimResponseReasonCode, bool isValidExpected)
	{
		var subject = new PCS_ProductClaimStatus();
		subject.ClaimStatusCode = claimStatusCode;
		subject.ClaimResponseReasonCode = claimResponseReasonCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "7", true)]
	[InlineData("ti", "", false)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string claimResponseReasonCode, bool isValidExpected)
	{
		var subject = new PCS_ProductClaimStatus();
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ClaimResponseReasonCode = claimResponseReasonCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "ti", true)]
	[InlineData("b", "", false)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PCS_ProductClaimStatus();
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "zCU", true)]
	[InlineData("tR", "", false)]
	public void Validation_ARequiresBAgencyQualifierCode2(string agencyQualifierCode2, string dispositionCode, bool isValidExpected)
	{
		var subject = new PCS_ProductClaimStatus();
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		subject.DispositionCode = dispositionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "tR", true)]
	[InlineData("q", "", false)]
	public void Validation_ARequiresBSourceSubqualifier2(string sourceSubqualifier2, string agencyQualifierCode2, bool isValidExpected)
	{
		var subject = new PCS_ProductClaimStatus();
		subject.SourceSubqualifier2 = sourceSubqualifier2;
		subject.AgencyQualifierCode2 = agencyQualifierCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
