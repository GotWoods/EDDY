using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class DEPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DEP*x*PAuRtg2Y*adoY*m*OF*0bp*a*P";

		var expected = new DEP_Deposit()
		{
			ReferenceIdentification = "x",
			Date = "PAuRtg2Y",
			Time = "adoY",
			ReferenceIdentification2 = "m",
			DFIIDNumberQualifier = "OF",
			DFIIdentificationNumber = "0bp",
			AccountNumberQualifier = "a",
			AccountNumber = "P",
		};

		var actual = Map.MapObject<DEP_Deposit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.Date = "PAuRtg2Y";
		subject.DFIIDNumberQualifier = "OF";
		subject.DFIIdentificationNumber = "0bp";
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "a";
			subject.AccountNumber = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PAuRtg2Y", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceIdentification = "x";
		subject.DFIIDNumberQualifier = "OF";
		subject.DFIIdentificationNumber = "0bp";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "a";
			subject.AccountNumber = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OF", true)]
	public void Validation_RequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceIdentification = "x";
		subject.Date = "PAuRtg2Y";
		subject.DFIIdentificationNumber = "0bp";
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "a";
			subject.AccountNumber = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0bp", true)]
	public void Validation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceIdentification = "x";
		subject.Date = "PAuRtg2Y";
		subject.DFIIDNumberQualifier = "OF";
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "a";
			subject.AccountNumber = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("a", "P", true)]
	[InlineData("a", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredAccountNumberQualifier(string accountNumberQualifier, string accountNumber, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceIdentification = "x";
		subject.Date = "PAuRtg2Y";
		subject.DFIIDNumberQualifier = "OF";
		subject.DFIIdentificationNumber = "0bp";
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
