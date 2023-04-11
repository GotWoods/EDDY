using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DEPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DEP*s*zzHfghwp*NQz3*y*Z4*AtG*n*g";

		var expected = new DEP_Deposit()
		{
			ReferenceIdentification = "s",
			Date = "zzHfghwp",
			Time = "NQz3",
			ReferenceIdentification2 = "y",
			DFIIDNumberQualifier = "Z4",
			DFIIdentificationNumber = "AtG",
			AccountNumberQualifier = "n",
			AccountNumber = "g",
		};

		var actual = Map.MapObject<DEP_Deposit>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.Date = "zzHfghwp";
		subject.DFIIDNumberQualifier = "Z4";
		subject.DFIIdentificationNumber = "AtG";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zzHfghwp", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceIdentification = "s";
		subject.DFIIDNumberQualifier = "Z4";
		subject.DFIIdentificationNumber = "AtG";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z4", true)]
	public void Validatation_RequiredDFIIDNumberQualifier(string dFIIDNumberQualifier, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceIdentification = "s";
		subject.Date = "zzHfghwp";
		subject.DFIIdentificationNumber = "AtG";
		subject.DFIIDNumberQualifier = dFIIDNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AtG", true)]
	public void Validatation_RequiredDFIIdentificationNumber(string dFIIdentificationNumber, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceIdentification = "s";
		subject.Date = "zzHfghwp";
		subject.DFIIDNumberQualifier = "Z4";
		subject.DFIIdentificationNumber = dFIIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("n", "g", true)]
	[InlineData("", "g", false)]
	[InlineData("n", "", false)]
	public void Validation_AllAreRequiredAccountNumberQualifier(string accountNumberQualifier, string accountNumber, bool isValidExpected)
	{
		var subject = new DEP_Deposit();
		subject.ReferenceIdentification = "s";
		subject.Date = "zzHfghwp";
		subject.DFIIDNumberQualifier = "Z4";
		subject.DFIIdentificationNumber = "AtG";
		subject.AccountNumberQualifier = accountNumberQualifier;
		subject.AccountNumber = accountNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
