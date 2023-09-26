using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class PTSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PTS*Lu*E*1*h9*9*J7*MJ*q*a*AL";

		var expected = new PTS_PropertyTaxStatus()
		{
			StatusCode = "Lu",
			ReferenceIdentification = "E",
			TaxServicePaymentCode = "1",
			DateTimePeriodFormatQualifier = "h9",
			DateTimePeriod = "9",
			StatusCode2 = "J7",
			TaxJurisdictionCodeQualifier = "MJ",
			TaxJurisdictionCode = "q",
			Description = "a",
			TypeOfTaxingAuthorityCode = "AL",
		};

		var actual = Map.MapObject<PTS_PropertyTaxStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lu", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		//Required fields
		subject.ReferenceIdentification = "E";
		//Test Parameters
		subject.StatusCode = statusCode;
		//At Least one
		subject.TaxJurisdictionCode = "q";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "h9";
			subject.DateTimePeriod = "9";
		}
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "MJ";
			subject.TaxJurisdictionCode = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		//Required fields
		subject.StatusCode = "Lu";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//At Least one
		subject.TaxJurisdictionCode = "q";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "h9";
			subject.DateTimePeriod = "9";
		}
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "MJ";
			subject.TaxJurisdictionCode = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h9", "9", true)]
	[InlineData("h9", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		//Required fields
		subject.StatusCode = "Lu";
		subject.ReferenceIdentification = "E";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//At Least one
		subject.TaxJurisdictionCode = "q";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "MJ";
			subject.TaxJurisdictionCode = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("MJ", "q", true)]
	[InlineData("MJ", "", false)]
	[InlineData("", "q", false)]
	public void Validation_AllAreRequiredTaxJurisdictionCodeQualifier(string taxJurisdictionCodeQualifier, string taxJurisdictionCode, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		//Required fields
		subject.StatusCode = "Lu";
		subject.ReferenceIdentification = "E";
		//Test Parameters
		subject.TaxJurisdictionCodeQualifier = taxJurisdictionCodeQualifier;
		subject.TaxJurisdictionCode = taxJurisdictionCode;
		//At Least one
		subject.Description = "a";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "h9";
			subject.DateTimePeriod = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("q", "a", true)]
	[InlineData("q", "", true)]
	[InlineData("", "a", true)]
	public void Validation_AtLeastOneTaxJurisdictionCode(string taxJurisdictionCode, string description, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		//Required fields
		subject.StatusCode = "Lu";
		subject.ReferenceIdentification = "E";
		//Test Parameters
		subject.TaxJurisdictionCode = taxJurisdictionCode;
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "h9";
			subject.DateTimePeriod = "9";
		}
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "MJ";
			subject.TaxJurisdictionCode = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
