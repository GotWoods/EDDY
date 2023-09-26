using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class FAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FAA*S*o*UWJ5W3ec*8*su*9**8*GrU*r4*F*sa*y*P*eM0";

		var expected = new FAA_FinancialAssetAccount()
		{
			AccountNumberQualifier = "S",
			AccountNumber = "o",
			Date = "UWJ5W3ec",
			MonetaryAmount = 8,
			TypeOfAccountCode = "su",
			MonetaryAmount2 = 9,
			CompositeUnitOfMeasure = null,
			Quantity = 8,
			DateTimeQualifier = "GrU",
			DateTimePeriodFormatQualifier = "r4",
			DateTimePeriod = "F",
			ReferenceIdentificationQualifier = "sa",
			ReferenceIdentification = "y",
			ReferenceIdentification2 = "P",
			MaintenanceTypeCode = "eM0",
		};

		var actual = Map.MapObject<FAA_FinancialAssetAccount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredAccountNumberQualifier(string accountNumberQualifier, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		//Required fields
		//Test Parameters
		subject.AccountNumberQualifier = accountNumberQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "r4";
			subject.DateTimePeriod = "F";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "sa";
			subject.ReferenceIdentification = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("GrU", "F", true)]
	[InlineData("GrU", "", false)]
	[InlineData("", "F", true)]
	public void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		//Required fields
		subject.AccountNumberQualifier = "S";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "r4";
			subject.DateTimePeriod = "F";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "sa";
			subject.ReferenceIdentification = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r4", "F", true)]
	[InlineData("r4", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		//Required fields
		subject.AccountNumberQualifier = "S";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "sa";
			subject.ReferenceIdentification = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sa", "y", true)]
	[InlineData("sa", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		//Required fields
		subject.AccountNumberQualifier = "S";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "r4";
			subject.DateTimePeriod = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
