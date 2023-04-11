using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PSATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PSA*U*yK*1*7*p";

		var expected = new PSA_PartnerShareAccounting()
		{
			IdentificationCodeQualifier = "U",
			IdentificationCode = "yK",
			OwnersShare = 1,
			MonetaryAmount = 7,
			AmountQualifierCode = "p",
		};

		var actual = Map.MapObject<PSA_PartnerShareAccounting>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new PSA_PartnerShareAccounting();
		subject.IdentificationCode = "yK";
		subject.OwnersShare = 1;
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yK", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new PSA_PartnerShareAccounting();
		subject.IdentificationCodeQualifier = "U";
		subject.OwnersShare = 1;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredOwnersShare(decimal ownersShare, bool isValidExpected)
	{
		var subject = new PSA_PartnerShareAccounting();
		subject.IdentificationCodeQualifier = "U";
		subject.IdentificationCode = "yK";
		if (ownersShare > 0)
		subject.OwnersShare = ownersShare;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 7, true)]
	[InlineData("p", 0, false)]
	public void Validation_ARequiresBAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PSA_PartnerShareAccounting();
		subject.IdentificationCodeQualifier = "U";
		subject.IdentificationCode = "yK";
		subject.OwnersShare = 1;
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
