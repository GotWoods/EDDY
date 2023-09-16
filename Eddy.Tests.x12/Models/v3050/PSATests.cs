using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PSATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PSA*j*Hq*5*5";

		var expected = new PSA_PartnerShareAccounting()
		{
			IdentificationCodeQualifier = "j",
			IdentificationCode = "Hq",
			OwnersShare = 5,
			MonetaryAmount = 5,
		};

		var actual = Map.MapObject<PSA_PartnerShareAccounting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new PSA_PartnerShareAccounting();
		subject.IdentificationCode = "Hq";
		subject.OwnersShare = 5;
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hq", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new PSA_PartnerShareAccounting();
		subject.IdentificationCodeQualifier = "j";
		subject.OwnersShare = 5;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredOwnersShare(decimal ownersShare, bool isValidExpected)
	{
		var subject = new PSA_PartnerShareAccounting();
		subject.IdentificationCodeQualifier = "j";
		subject.IdentificationCode = "Hq";
		if (ownersShare > 0)
			subject.OwnersShare = ownersShare;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
