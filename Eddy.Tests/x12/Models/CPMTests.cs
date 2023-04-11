using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CPMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CPM*Sc*l*v3*8*4f*W";

		var expected = new CPM_CustomsProfileManagementInformation()
		{
			TransactionSetPurposeCode = "Sc",
			IdentificationCodeQualifier = "l",
			IdentificationCode = "v3",
			Name = "8",
			StandardCarrierAlphaCode = "4f",
			ReferenceIdentification = "W",
		};

		var actual = Map.MapObject<CPM_CustomsProfileManagementInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sc", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new CPM_CustomsProfileManagementInformation();
		subject.IdentificationCodeQualifier = "l";
		subject.IdentificationCode = "v3";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new CPM_CustomsProfileManagementInformation();
		subject.TransactionSetPurposeCode = "Sc";
		subject.IdentificationCode = "v3";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v3", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new CPM_CustomsProfileManagementInformation();
		subject.TransactionSetPurposeCode = "Sc";
		subject.IdentificationCodeQualifier = "l";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
