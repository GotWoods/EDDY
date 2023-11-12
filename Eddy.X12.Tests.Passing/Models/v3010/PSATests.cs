using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class PSATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PSA*9*sx*6*9";

		var expected = new PSA_PartnerShareAccounting()
		{
			IdentificationCodeQualifier = "9",
			IdentificationCode = "sx",
			OwnersShare = 6,
			MonetaryAmount = 9,
		};

		var actual = Map.MapObject<PSA_PartnerShareAccounting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new PSA_PartnerShareAccounting();
		subject.IdentificationCode = "sx";
		subject.OwnersShare = 6;
		subject.MonetaryAmount = 9;
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sx", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new PSA_PartnerShareAccounting();
		subject.IdentificationCodeQualifier = "9";
		subject.OwnersShare = 6;
		subject.MonetaryAmount = 9;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredOwnersShare(decimal ownersShare, bool isValidExpected)
	{
		var subject = new PSA_PartnerShareAccounting();
		subject.IdentificationCodeQualifier = "9";
		subject.IdentificationCode = "sx";
		subject.MonetaryAmount = 9;
		if (ownersShare > 0)
			subject.OwnersShare = ownersShare;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PSA_PartnerShareAccounting();
		subject.IdentificationCodeQualifier = "9";
		subject.IdentificationCode = "sx";
		subject.OwnersShare = 6;
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
