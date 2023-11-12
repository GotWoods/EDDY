using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class FAATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FAA*j*k*gBLILC*9*io*9**7*WpG*ME*g*yQ*P*J";

		var expected = new FAA_FinancialAssetAccount()
		{
			AccountNumberQualifier = "j",
			AccountNumber = "k",
			Date = "gBLILC",
			MonetaryAmount = 9,
			TypeOfAccountCode = "io",
			MonetaryAmount2 = 9,
			CompositeUnitOfMeasure = null,
			Quantity = 7,
			DateTimeQualifier = "WpG",
			DateTimePeriodFormatQualifier = "ME",
			DateTimePeriod = "g",
			ReferenceIdentificationQualifier = "yQ",
			ReferenceIdentification = "P",
			ReferenceIdentification2 = "J",
		};

		var actual = Map.MapObject<FAA_FinancialAssetAccount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredAccountNumberQualifier(string accountNumberQualifier, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		//Required fields
		//Test Parameters
		subject.AccountNumberQualifier = accountNumberQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ME";
			subject.DateTimePeriod = "g";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "yQ";
			subject.ReferenceIdentification = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("WpG", "g", true)]
	[InlineData("WpG", "", false)]
	[InlineData("", "g", true)]
	public void Validation_ARequiresBDateTimeQualifier(string dateTimeQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		//Required fields
		subject.AccountNumberQualifier = "j";
		//Test Parameters
		subject.DateTimeQualifier = dateTimeQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ME";
			subject.DateTimePeriod = "g";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "yQ";
			subject.ReferenceIdentification = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ME", "g", true)]
	[InlineData("ME", "", false)]
	[InlineData("", "g", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		//Required fields
		subject.AccountNumberQualifier = "j";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "yQ";
			subject.ReferenceIdentification = "P";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yQ", "P", true)]
	[InlineData("yQ", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new FAA_FinancialAssetAccount();
		//Required fields
		subject.AccountNumberQualifier = "j";
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "ME";
			subject.DateTimePeriod = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
