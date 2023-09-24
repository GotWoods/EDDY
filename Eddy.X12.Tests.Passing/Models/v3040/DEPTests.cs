using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class DEPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DEP*r*cstuNh*XEHR*k*ZO*zxv*xh*T";

		var expected = new DEP_Deposit()
		{
			ReferenceNumber = "r",
			Date = "cstuNh",
			Time = "XEHR",
			ReferenceNumber2 = "k",
			DFIIDNumberQualifier = "ZO",
			DFIIdentificationNumber = "zxv",
			AccountNumberQualifierCode = "xh",
			AccountNumber = "T",
		};

		var actual = Map.MapObject<DEP_Deposit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.Date = "cstuNh";
		subject.DFIIDNumberQualifier = "ZO";
		subject.DFIIdentificationNumber = "zxv";
		subject.ReferenceNumber = referenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifierCode) || !string.IsNullOrEmpty(subject.AccountNumberQualifierCode) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifierCode = "xh";
			subject.AccountNumber = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cstuNh", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceNumber = "r";
		subject.DFIIDNumberQualifier = "ZO";
		subject.DFIIdentificationNumber = "zxv";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifierCode) || !string.IsNullOrEmpty(subject.AccountNumberQualifierCode) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifierCode = "xh";
			subject.AccountNumber = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZO", true)]
	public void Validation_RequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceNumber = "r";
		subject.Date = "cstuNh";
		subject.DFIIdentificationNumber = "zxv";
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifierCode) || !string.IsNullOrEmpty(subject.AccountNumberQualifierCode) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifierCode = "xh";
			subject.AccountNumber = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zxv", true)]
	public void Validation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceNumber = "r";
		subject.Date = "cstuNh";
		subject.DFIIDNumberQualifier = "ZO";
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifierCode) || !string.IsNullOrEmpty(subject.AccountNumberQualifierCode) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifierCode = "xh";
			subject.AccountNumber = "T";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xh", "T", true)]
	[InlineData("xh", "", false)]
	[InlineData("", "T", false)]
	public void Validation_AllAreRequiredAccountNumberQualifierCode(string accountNumberQualifierCode, string accountNumber, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceNumber = "r";
		subject.Date = "cstuNh";
		subject.DFIIDNumberQualifier = "ZO";
		subject.DFIIdentificationNumber = "zxv";
		subject.AccountNumberQualifierCode = accountNumberQualifierCode;
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
