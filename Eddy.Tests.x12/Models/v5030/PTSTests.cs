using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class PTSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PTS*AA*i*2*fe*y*XJ*oE*H*W*q1*7r";

		var expected = new PTS_PropertyTaxStatus()
		{
			StatusCode = "AA",
			ReferenceIdentification = "i",
			TaxServicePaymentCode = "2",
			DateTimePeriodFormatQualifier = "fe",
			DateTimePeriod = "y",
			StatusCode2 = "XJ",
			TaxJurisdictionCodeQualifier = "oE",
			TaxJurisdictionCode = "H",
			Description = "W",
			TypeOfTaxingAuthorityCode = "q1",
			StatusCode3 = "7r",
		};

		var actual = Map.MapObject<PTS_PropertyTaxStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AA", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		//Required fields
		subject.ReferenceIdentification = "i";
		//Test Parameters
		subject.StatusCode = statusCode;
		//At Least one
		subject.TaxJurisdictionCode = "H";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "fe";
			subject.DateTimePeriod = "y";
		}
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "oE";
			subject.TaxJurisdictionCode = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		//Required fields
		subject.StatusCode = "AA";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//At Least one
		subject.TaxJurisdictionCode = "H";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "fe";
			subject.DateTimePeriod = "y";
		}
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "oE";
			subject.TaxJurisdictionCode = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fe", "y", true)]
	[InlineData("fe", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		//Required fields
		subject.StatusCode = "AA";
		subject.ReferenceIdentification = "i";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//At Least one
		subject.TaxJurisdictionCode = "H";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "oE";
			subject.TaxJurisdictionCode = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("oE", "H", true)]
	[InlineData("oE", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredTaxJurisdictionCodeQualifier(string taxJurisdictionCodeQualifier, string taxJurisdictionCode, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		//Required fields
		subject.StatusCode = "AA";
		subject.ReferenceIdentification = "i";
		//Test Parameters
		subject.TaxJurisdictionCodeQualifier = taxJurisdictionCodeQualifier;
		subject.TaxJurisdictionCode = taxJurisdictionCode;
		//At Least one
		subject.Description = "W";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "fe";
			subject.DateTimePeriod = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("H", "W", true)]
	[InlineData("H", "", true)]
	[InlineData("", "W", true)]
	public void Validation_AtLeastOneTaxJurisdictionCode(string taxJurisdictionCode, string description, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		//Required fields
		subject.StatusCode = "AA";
		subject.ReferenceIdentification = "i";
		//Test Parameters
		subject.TaxJurisdictionCode = taxJurisdictionCode;
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "fe";
			subject.DateTimePeriod = "y";
		}
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "oE";
			subject.TaxJurisdictionCode = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
