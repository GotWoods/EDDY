using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class PMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PM*3mD*z*l*N*V*QU";

		var expected = new PM_ElectronicFundsTransferInformation()
		{
			DFIIdentificationNumber = "3mD",
			AccountNumber = "z",
			YesNoConditionOrResponseCode = "l",
			YesNoConditionOrResponseCode2 = "N",
			AccountNumberQualifier = "V",
			DFIIDNumberQualifier = "QU",
		};

		var actual = Map.MapObject<PM_ElectronicFundsTransferInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3mD", true)]
	public void Validation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		//Required fields
		subject.AccountNumber = "z";
		subject.YesNoConditionOrResponseCode = "l";
		subject.YesNoConditionOrResponseCode2 = "N";
		//Test Parameters
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		//Required fields
		subject.DFIIdentificationNumber = "3mD";
		subject.YesNoConditionOrResponseCode = "l";
		subject.YesNoConditionOrResponseCode2 = "N";
		//Test Parameters
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		//Required fields
		subject.DFIIdentificationNumber = "3mD";
		subject.AccountNumber = "z";
		subject.YesNoConditionOrResponseCode2 = "N";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode2(string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		//Required fields
		subject.DFIIdentificationNumber = "3mD";
		subject.AccountNumber = "z";
		subject.YesNoConditionOrResponseCode = "l";
		//Test Parameters
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
