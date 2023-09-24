using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class DEPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DEP*T*ogOvil*H3Zu*7*eL*liS*3V*w";

		var expected = new DEP_Deposit()
		{
			ReferenceNumber = "T",
			Date = "ogOvil",
			Time = "H3Zu",
			ReferenceNumber2 = "7",
			DFIIDNumberQualifier = "eL",
			DFIIdentificationNumber = "liS",
			AccountNumberQualifierCode = "3V",
			AccountNumber = "w",
		};

		var actual = Map.MapObject<DEP_Deposit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.Date = "ogOvil";
		subject.DFIIDNumberQualifier = "eL";
		subject.DFIIdentificationNumber = "liS";
		subject.ReferenceNumber = referenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifierCode) || !string.IsNullOrEmpty(subject.AccountNumberQualifierCode) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifierCode = "3V";
			subject.AccountNumber = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ogOvil", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceNumber = "T";
		subject.DFIIDNumberQualifier = "eL";
		subject.DFIIdentificationNumber = "liS";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifierCode) || !string.IsNullOrEmpty(subject.AccountNumberQualifierCode) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifierCode = "3V";
			subject.AccountNumber = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eL", true)]
	public void Validation_RequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceNumber = "T";
		subject.Date = "ogOvil";
		subject.DFIIdentificationNumber = "liS";
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifierCode) || !string.IsNullOrEmpty(subject.AccountNumberQualifierCode) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifierCode = "3V";
			subject.AccountNumber = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("liS", true)]
	public void Validation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceNumber = "T";
		subject.Date = "ogOvil";
		subject.DFIIDNumberQualifier = "eL";
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.AccountNumberQualifierCode) || !string.IsNullOrEmpty(subject.AccountNumberQualifierCode) || !string.IsNullOrEmpty(subject.AccountNumber))
		{
			subject.AccountNumberQualifierCode = "3V";
			subject.AccountNumber = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3V", "w", true)]
	[InlineData("3V", "", false)]
	[InlineData("", "w", false)]
	public void Validation_AllAreRequiredAccountNumberQualifierCode(string accountNumberQualifierCode, string accountNumber, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceNumber = "T";
		subject.Date = "ogOvil";
		subject.DFIIDNumberQualifier = "eL";
		subject.DFIIdentificationNumber = "liS";
		subject.AccountNumberQualifierCode = accountNumberQualifierCode;
		subject.AccountNumber = accountNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
