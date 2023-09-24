using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PM*jJ9*r*n*x*w*cV*r*Z";

		var expected = new PM_ElectronicFundsTransferInformation()
		{
			DFIIdentificationNumber = "jJ9",
			AccountNumber = "r",
			YesNoConditionOrResponseCode = "n",
			YesNoConditionOrResponseCode2 = "x",
			AccountNumberQualifier = "w",
			DFIIDNumberQualifier = "cV",
			YesNoConditionOrResponseCode3 = "r",
			YesNoConditionOrResponseCode4 = "Z",
		};

		var actual = Map.MapObject<PM_ElectronicFundsTransferInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jJ9", true)]
	public void Validation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		subject.AccountNumber = "r";
		subject.YesNoConditionOrResponseCode = "n";
		subject.YesNoConditionOrResponseCode2 = "x";
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		subject.DFIIdentificationNumber = "jJ9";
		subject.YesNoConditionOrResponseCode = "n";
		subject.YesNoConditionOrResponseCode2 = "x";
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		subject.DFIIdentificationNumber = "jJ9";
		subject.AccountNumber = "r";
		subject.YesNoConditionOrResponseCode2 = "x";
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode2(string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		subject.DFIIdentificationNumber = "jJ9";
		subject.AccountNumber = "r";
		subject.YesNoConditionOrResponseCode = "n";
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
