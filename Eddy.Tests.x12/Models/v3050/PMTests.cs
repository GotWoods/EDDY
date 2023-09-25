using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PM*ubQ*i*h*K*Q";

		var expected = new PM_ElectronicFundsTransferInformation()
		{
			DFIIdentificationNumber = "ubQ",
			AccountNumber = "i",
			YesNoConditionOrResponseCode = "h",
			YesNoConditionOrResponseCode2 = "K",
			AccountNumberQualifier = "Q",
		};

		var actual = Map.MapObject<PM_ElectronicFundsTransferInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ubQ", true)]
	public void Validation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		//Required fields
		subject.AccountNumber = "i";
		subject.YesNoConditionOrResponseCode = "h";
		subject.YesNoConditionOrResponseCode2 = "K";
		subject.AccountNumberQualifier = "Q";
		//Test Parameters
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		//Required fields
		subject.DFIIdentificationNumber = "ubQ";
		subject.YesNoConditionOrResponseCode = "h";
		subject.YesNoConditionOrResponseCode2 = "K";
		subject.AccountNumberQualifier = "Q";
		//Test Parameters
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		//Required fields
		subject.DFIIdentificationNumber = "ubQ";
		subject.AccountNumber = "i";
		subject.YesNoConditionOrResponseCode2 = "K";
		subject.AccountNumberQualifier = "Q";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode2(string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		//Required fields
		subject.DFIIdentificationNumber = "ubQ";
		subject.AccountNumber = "i";
		subject.YesNoConditionOrResponseCode = "h";
		subject.AccountNumberQualifier = "Q";
		//Test Parameters
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredAccountNumberQualifier(string accountNumberQualifier, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		//Required fields
		subject.DFIIdentificationNumber = "ubQ";
		subject.AccountNumber = "i";
		subject.YesNoConditionOrResponseCode = "h";
		subject.YesNoConditionOrResponseCode2 = "K";
		//Test Parameters
		subject.AccountNumberQualifier = accountNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
