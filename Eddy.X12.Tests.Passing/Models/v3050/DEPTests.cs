using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class DEPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DEP*l*QZl2M3*LeZZ*5*px*bY9*I*2";

		var expected = new DEP_Deposit()
		{
			ReferenceNumber = "l",
			Date = "QZl2M3",
			Time = "LeZZ",
			ReferenceNumber2 = "5",
			DFIIDNumberQualifier = "px",
			DFIIdentificationNumber = "bY9",
			AccountNumberQualifier = "I",
			AccountNumber = "2",
		};

		var actual = Map.MapObject<DEP_Deposit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.Date = "QZl2M3";
		subject.DFIIDNumberQualifier = "px";
		subject.DFIIdentificationNumber = "bY9";
		subject.ReferenceNumber = referenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "I";
			subject.AccountNumber = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QZl2M3", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceNumber = "l";
		subject.DFIIDNumberQualifier = "px";
		subject.DFIIdentificationNumber = "bY9";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "I";
			subject.AccountNumber = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("px", true)]
	public void Validation_RequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceNumber = "l";
		subject.Date = "QZl2M3";
		subject.DFIIdentificationNumber = "bY9";
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "I";
			subject.AccountNumber = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bY9", true)]
	public void Validation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceNumber = "l";
		subject.Date = "QZl2M3";
		subject.DFIIDNumberQualifier = "px";
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumberQualifier) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifier = "I";
			subject.AccountNumber = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "2", true)]
	[InlineData("I", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredAccountNumberQualifier(string accountNumberQualifier, string accountNumber, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceNumber = "l";
		subject.Date = "QZl2M3";
		subject.DFIIDNumberQualifier = "px";
		subject.DFIIdentificationNumber = "bY9";
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
