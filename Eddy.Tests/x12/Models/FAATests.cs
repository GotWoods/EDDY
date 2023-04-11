using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FAA*O*p*SBgtcUxd*2*ew*1**9*emz*F4*E*B6*l*v*Sle";

		var expected = new FAA_FinancialAssetAccount()
		{
			AccountNumberQualifier = "O",
			AccountNumber = "p",
			Date = "SBgtcUxd",
			MonetaryAmount = 2,
			TypeOfAccountCode = "ew",
			MonetaryAmount2 = 1,
			CompositeUnitOfMeasure = null,
			Quantity = 9,
			DateTimeQualifier = "emz",
			DateTimePeriodFormatQualifier = "F4",
			DateTimePeriod = "E",
			ReferenceIdentificationQualifier = "B6",
			ReferenceIdentification = "l",
			ReferenceIdentification2 = "v",
			MaintenanceTypeCode = "Sle",
		};

		var actual = Map.MapObject<FAA_FinancialAssetAccount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredAccountNumberQualifier(string accountNumberQualifier, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		subject.AccountNumberQualifier = accountNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "E", true)]
	[InlineData("emz", "", false)]
	public void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		subject.AccountNumberQualifier = "O";
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		if (dateTimePeriod != "")
			subject.DateTimePeriodFormatQualifier = "AA";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("F4", "E", true)]
	[InlineData("", "E", false)]
	[InlineData("F4", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		subject.AccountNumberQualifier = "O";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("B6", "l", true)]
	[InlineData("", "l", false)]
	[InlineData("B6", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		subject.AccountNumberQualifier = "O";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
