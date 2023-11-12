using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PCS*w*1K*E*z*5*I*ur*1*EeX*M*T";

		var expected = new PCS_ProductClaimStatus()
		{
			ClaimStatusCode = "w",
			AgencyQualifierCode = "1K",
			SourceSubqualifier = "E",
			ClaimResponseReasonCode = "z",
			MonetaryAmount = 5,
			FollowUpActionCode = "I",
			AgencyQualifierCode2 = "ur",
			SourceSubqualifier2 = "1",
			DispositionCode = "EeX",
			Description = "M",
			AuthorizationIdentification = "T",
		};

		var actual = Map.MapObject<PCS_ProductClaimStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("w", "z", true)]
	[InlineData("w", "", true)]
	[InlineData("", "z", true)]
	public void Validation_AtLeastOneClaimStatusCode(string claimStatusCode, string claimResponseReasonCode, bool isValidExpected)
	{
		var subject = new PCS_ProductClaimStatus();
		//Required fields
		//Test Parameters
		subject.ClaimStatusCode = claimStatusCode;
		subject.ClaimResponseReasonCode = claimResponseReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1K", "z", true)]
	[InlineData("1K", "", false)]
	[InlineData("", "z", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string claimResponseReasonCode, bool isValidExpected)
	{
		var subject = new PCS_ProductClaimStatus();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ClaimResponseReasonCode = claimResponseReasonCode;
		//At Least one
		subject.ClaimStatusCode = "w";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("E", "1K", true)]
	[InlineData("E", "", false)]
	[InlineData("", "1K", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PCS_ProductClaimStatus();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.ClaimResponseReasonCode = "z";
		//At Least one
		subject.ClaimStatusCode = "w";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ur", "EeX", true)]
	[InlineData("ur", "", false)]
	[InlineData("", "EeX", true)]
	public void Validation_ARequiresBAgencyQualifierCode2(string agencyQualifierCode2, string dispositionCode, bool isValidExpected)
	{
		var subject = new PCS_ProductClaimStatus();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		subject.DispositionCode = dispositionCode;
		//At Least one
		subject.ClaimStatusCode = "w";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("1", "ur", true)]
	[InlineData("1", "", false)]
	[InlineData("", "ur", true)]
	public void Validation_ARequiresBSourceSubqualifier2(string sourceSubqualifier2, string agencyQualifierCode2, bool isValidExpected)
	{
		var subject = new PCS_ProductClaimStatus();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier2 = sourceSubqualifier2;
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		//A Requires B
		if (agencyQualifierCode2 != "")
			subject.DispositionCode = "EeX";
		//At Least one
		subject.ClaimStatusCode = "w";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
