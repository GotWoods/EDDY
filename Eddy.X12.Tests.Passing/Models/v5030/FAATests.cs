using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class FAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FAA*W*g*vUWbDus0*6*bw*1**4*Y5W*Q4*g*yC*H*5*x1m";

		var expected = new FAA_FinancialAssetAccount()
		{
			AccountNumberQualifier = "W",
			AccountNumber = "g",
			Date = "vUWbDus0",
			MonetaryAmount = 6,
			TypeOfAccountCode = "bw",
			MonetaryAmount2 = 1,
			CompositeUnitOfMeasure = null,
			Quantity = 4,
			DateTimeQualifier = "Y5W",
			DateTimePeriodFormatQualifier = "Q4",
			DateTimePeriod = "g",
			ReferenceIdentificationQualifier = "yC",
			ReferenceIdentification = "H",
			ReferenceIdentification2 = "5",
			MaintenanceTypeCode = "x1m",
		};

		var actual = Map.MapObject<FAA_FinancialAssetAccount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredAccountNumberQualifier(string accountNumberQualifier, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		//Required fields
		//Test Parameters
		subject.AccountNumberQualifier = accountNumberQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Q4";
			subject.DateTimePeriod = "g";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "yC";
			subject.ReferenceIdentification = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Y5W", "g", true)]
	[InlineData("Y5W", "", false)]
	[InlineData("", "g", true)]
	public void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		//Required fields
		subject.AccountNumberQualifier = "W";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Q4";
			subject.DateTimePeriod = "g";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "yC";
			subject.ReferenceIdentification = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Q4", "g", true)]
	[InlineData("Q4", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		//Required fields
		subject.AccountNumberQualifier = "W";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "yC";
			subject.ReferenceIdentification = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yC", "H", true)]
	[InlineData("yC", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		//Required fields
		subject.AccountNumberQualifier = "W";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "Q4";
			subject.DateTimePeriod = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
