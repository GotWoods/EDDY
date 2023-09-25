using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class FAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FAA*p*t*s4odR6Jb*7*dX*5**5*5g7*9x*B*h3*z*U*WiD";

		var expected = new FAA_FinancialAssetAccount()
		{
			AccountNumberQualifier = "p",
			AccountNumber = "t",
			Date = "s4odR6Jb",
			MonetaryAmount = 7,
			TypeOfAccountCode = "dX",
			MonetaryAmount2 = 5,
			CompositeUnitOfMeasure = null,
			Quantity = 5,
			DateTimeQualifier = "5g7",
			DateTimePeriodFormatQualifier = "9x",
			DateTimePeriod = "B",
			ReferenceIdentificationQualifier = "h3",
			ReferenceIdentification = "z",
			ReferenceIdentification2 = "U",
			MaintenanceTypeCode = "WiD",
		};

		var actual = Map.MapObject<FAA_FinancialAssetAccount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredAccountNumberQualifier(string accountNumberQualifier, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		//Required fields
		//Test Parameters
		subject.AccountNumberQualifier = accountNumberQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "9x";
			subject.DateTimePeriod = "B";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "h3";
			subject.ReferenceIdentification = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5g7", "B", true)]
	[InlineData("5g7", "", false)]
	[InlineData("", "B", true)]
	public void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		//Required fields
		subject.AccountNumberQualifier = "p";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "9x";
			subject.DateTimePeriod = "B";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "h3";
			subject.ReferenceIdentification = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9x", "B", true)]
	[InlineData("9x", "", false)]
	[InlineData("", "B", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		//Required fields
		subject.AccountNumberQualifier = "p";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "h3";
			subject.ReferenceIdentification = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h3", "z", true)]
	[InlineData("h3", "", false)]
	[InlineData("", "z", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		//Required fields
		subject.AccountNumberQualifier = "p";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "9x";
			subject.DateTimePeriod = "B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
