using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class PSATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PSA*9*3n*7*7*6";

		var expected = new PSA_PartnerShareAccounting()
		{
			IdentificationCodeQualifier = "9",
			IdentificationCode = "3n",
			OwnersShare = 7,
			MonetaryAmount = 7,
			AmountQualifierCode = "6",
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
		subject.IdentificationCode = "3n";
		subject.OwnersShare = 7;
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3n", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new PSA_PartnerShareAccounting();
		subject.IdentificationCodeQualifier = "9";
		subject.OwnersShare = 7;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredOwnersShare(decimal ownersShare, bool isValidExpected)
	{
		var subject = new PSA_PartnerShareAccounting();
		subject.IdentificationCodeQualifier = "9";
		subject.IdentificationCode = "3n";
		if (ownersShare > 0)
			subject.OwnersShare = ownersShare;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("6", 7, true)]
	[InlineData("6", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new PSA_PartnerShareAccounting();
		subject.IdentificationCodeQualifier = "9";
		subject.IdentificationCode = "3n";
		subject.OwnersShare = 7;
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
