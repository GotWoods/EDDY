using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class PMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PM*UPo*c*Z*I";

		var expected = new PM_ElectronicFundsTransferInformation()
		{
			DFIIdentificationNumber = "UPo",
			AccountNumber = "c",
			YesNoConditionOrResponseCode = "Z",
			YesNoConditionOrResponseCode2 = "I",
		};

		var actual = Map.MapObject<PM_ElectronicFundsTransferInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UPo", true)]
	public void Validation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		//Required fields
		subject.AccountNumber = "c";
		subject.YesNoConditionOrResponseCode = "Z";
		subject.YesNoConditionOrResponseCode2 = "I";
		//Test Parameters
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredAccountNumber(string accountNumber, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		//Required fields
		subject.DFIIdentificationNumber = "UPo";
		subject.YesNoConditionOrResponseCode = "Z";
		subject.YesNoConditionOrResponseCode2 = "I";
		//Test Parameters
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		//Required fields
		subject.DFIIdentificationNumber = "UPo";
		subject.AccountNumber = "c";
		subject.YesNoConditionOrResponseCode2 = "I";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode2(string yesNoConditionOrResponseCode2, bool isValidExpected)
	{
		var subject = new PM_ElectronicFundsTransferInformation();
		//Required fields
		subject.DFIIdentificationNumber = "UPo";
		subject.AccountNumber = "c";
		subject.YesNoConditionOrResponseCode = "Z";
		//Test Parameters
		subject.YesNoConditionOrResponseCode2 = yesNoConditionOrResponseCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
