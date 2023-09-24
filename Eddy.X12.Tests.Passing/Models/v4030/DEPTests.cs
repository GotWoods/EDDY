using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class DEPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DEP*X*uBVKoyKp*aqh5*A*OU*p5V*H*0";

		var expected = new DEP_Deposit()
		{
			ReferenceIdentification = "X",
			Date = "uBVKoyKp",
			Time = "aqh5",
			ReferenceIdentification2 = "A",
			DFIIDNumberQualifier = "OU",
			DFIIdentificationNumber = "p5V",
			AccountNumberQualifier = "H",
			AccountNumber = "0",
		};

		var actual = Map.MapObject<DEP_Deposit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.Date = "uBVKoyKp";
		subject.DFIIDNumberQualifier = "OU";
		subject.DFIIdentificationNumber = "p5V";
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "H";
			subject.AccountNumber = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uBVKoyKp", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceIdentification = "X";
		subject.DFIIDNumberQualifier = "OU";
		subject.DFIIdentificationNumber = "p5V";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "H";
			subject.AccountNumber = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OU", true)]
	public void Validation_RequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceIdentification = "X";
		subject.Date = "uBVKoyKp";
		subject.DFIIdentificationNumber = "p5V";
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "H";
			subject.AccountNumber = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p5V", true)]
	public void Validation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceIdentification = "X";
		subject.Date = "uBVKoyKp";
		subject.DFIIDNumberQualifier = "OU";
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "H";
			subject.AccountNumber = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("H", "0", true)]
	[InlineData("H", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredAccountNumberQualifier(string accountNumberQualifier, string accountNumber, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceIdentification = "X";
		subject.Date = "uBVKoyKp";
		subject.DFIIDNumberQualifier = "OU";
		subject.DFIIdentificationNumber = "p5V";
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
