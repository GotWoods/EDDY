using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PCSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PCS*C*uk*V*9*4*w*sa*n*RL4*M*S";

		var expected = new PCS_ProductClaimStatus()
		{
			ClaimStatusCode = "C",
			AgencyQualifierCode = "uk",
			SourceSubqualifier = "V",
			ClaimResponseReasonCode = "9",
			MonetaryAmount = 4,
			FollowUpActionCode = "w",
			AgencyQualifierCode2 = "sa",
			SourceSubqualifier2 = "n",
			DispositionCode = "RL4",
			Description = "M",
			AuthorizationIdentification = "S",
		};

		var actual = Map.MapObject<PCS_ProductClaimStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("C", "9", true)]
	[InlineData("C", "", true)]
	[InlineData("", "9", true)]
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
	[InlineData("uk", "9", true)]
	[InlineData("uk", "", false)]
	[InlineData("", "9", true)]
	public void Validation_ARequiresBAgencyQualifierCode(string agencyQualifierCode, string claimResponseReasonCode, bool isValidExpected)
	{
		var subject = new PCS_ProductClaimStatus();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode = agencyQualifierCode;
		subject.ClaimResponseReasonCode = claimResponseReasonCode;
		//At Least one
		subject.ClaimStatusCode = "C";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "uk", true)]
	[InlineData("V", "", false)]
	[InlineData("", "uk", true)]
	public void Validation_ARequiresBSourceSubqualifier(string sourceSubqualifier, string agencyQualifierCode, bool isValidExpected)
	{
		var subject = new PCS_ProductClaimStatus();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier = sourceSubqualifier;
		subject.AgencyQualifierCode = agencyQualifierCode;
		//A Requires B
		if (agencyQualifierCode != "")
			subject.ClaimResponseReasonCode = "9";
		//At Least one
		subject.ClaimStatusCode = "C";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sa", "RL4", true)]
	[InlineData("sa", "", false)]
	[InlineData("", "RL4", true)]
	public void Validation_ARequiresBAgencyQualifierCode2(string agencyQualifierCode2, string dispositionCode, bool isValidExpected)
	{
		var subject = new PCS_ProductClaimStatus();
		//Required fields
		//Test Parameters
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		subject.DispositionCode = dispositionCode;
		//At Least one
		subject.ClaimStatusCode = "C";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("n", "sa", true)]
	[InlineData("n", "", false)]
	[InlineData("", "sa", true)]
	public void Validation_ARequiresBSourceSubqualifier2(string sourceSubqualifier2, string agencyQualifierCode2, bool isValidExpected)
	{
		var subject = new PCS_ProductClaimStatus();
		//Required fields
		//Test Parameters
		subject.SourceSubqualifier2 = sourceSubqualifier2;
		subject.AgencyQualifierCode2 = agencyQualifierCode2;
		//A Requires B
		if (agencyQualifierCode2 != "")
			subject.DispositionCode = "RL4";
		//At Least one
		subject.ClaimStatusCode = "C";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
