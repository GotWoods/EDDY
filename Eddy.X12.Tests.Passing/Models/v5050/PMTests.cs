using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class PMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PM*S3Z*q*X*V*S*MJ*9*z";

		var expected = new PM_ElectronicFundsTransferInformation()
		{
			DFIIdentificationNumber = "S3Z",
			AccountNumber = "q",
			YesNoConditionOrResponseCode = "X",
			YesNoConditionOrResponseCode2 = "V",
			AccountNumberQualifier = "S",
			DFIIDNumberQualifier = "MJ",
			YesNoConditionOrResponseCode3 = "9",
			YesNoConditionOrResponseCode4 = "z",
		};

		var actual = Map.MapObject<PM_ElectronicFundsTransferInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S3Z", true)]
	public void Validation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		//Required fields
		subject.AccountNumber = "q";
		subject.YesNoConditionOrResponseCode = "X";
		subject.YesNoConditionOrResponseCode2 = "V";
		//Test Parameters
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		//Required fields
		subject.DFIIdentificationNumber = "S3Z";
		subject.YesNoConditionOrResponseCode = "X";
		subject.YesNoConditionOrResponseCode2 = "V";
		//Test Parameters
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		//Required fields
		subject.DFIIdentificationNumber = "S3Z";
		subject.AccountNumber = "q";
		subject.YesNoConditionOrResponseCode2 = "V";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode2(string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		//Required fields
		subject.DFIIdentificationNumber = "S3Z";
		subject.AccountNumber = "q";
		subject.YesNoConditionOrResponseCode = "X";
		//Test Parameters
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
