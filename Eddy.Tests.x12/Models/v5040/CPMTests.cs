using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class CPMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CPM*3f*d*b6*S*gP*j";

		var expected = new CPM_CustomsProfileManagementInformation()
		{
			TransactionSetPurposeCode = "3f",
			IdentificationCodeQualifier = "d",
			IdentificationCode = "b6",
			Name = "S",
			StandardCarrierAlphaCode = "gP",
			ReferenceIdentification = "j",
		};

		var actual = Map.MapObject<CPM_CustomsProfileManagementInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3f", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new CPM_CustomsProfileManagementInformation();
		//Required fields
		subject.IdentificationCodeQualifier = "d";
		subject.IdentificationCode = "b6";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new CPM_CustomsProfileManagementInformation();
		//Required fields
		subject.TransactionSetPurposeCode = "3f";
		subject.IdentificationCode = "b6";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b6", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new CPM_CustomsProfileManagementInformation();
		//Required fields
		subject.TransactionSetPurposeCode = "3f";
		subject.IdentificationCodeQualifier = "d";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
