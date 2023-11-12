using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class PTSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PTS*tR*G*i*t3*y*mc*De*x*b*zt*f5";

		var expected = new PTS_PropertyTaxStatus()
		{
			StatusCode = "tR",
			ReferenceIdentification = "G",
			TaxServicePaymentCode = "i",
			DateTimePeriodFormatQualifier = "t3",
			DateTimePeriod = "y",
			StatusCode2 = "mc",
			TaxJurisdictionCodeQualifier = "De",
			TaxJurisdictionCode = "x",
			Description = "b",
			TypeOfTaxingAuthorityCode = "zt",
			StatusCode3 = "f5",
		};

		var actual = Map.MapObject<PTS_PropertyTaxStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tR", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		//Required fields
		subject.ReferenceIdentification = "G";
		//Test Parameters
		subject.StatusCode = statusCode;
		//At Least one
		subject.TaxJurisdictionCode = "x";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "t3";
			subject.DateTimePeriod = "y";
		}
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "De";
			subject.TaxJurisdictionCode = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		//Required fields
		subject.StatusCode = "tR";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//At Least one
		subject.TaxJurisdictionCode = "x";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "t3";
			subject.DateTimePeriod = "y";
		}
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "De";
			subject.TaxJurisdictionCode = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t3", "y", true)]
	[InlineData("t3", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		//Required fields
		subject.StatusCode = "tR";
		subject.ReferenceIdentification = "G";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;
		//At Least one
		subject.TaxJurisdictionCode = "x";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "De";
			subject.TaxJurisdictionCode = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("De", "x", true)]
	[InlineData("De", "", false)]
	[InlineData("", "x", false)]
	public void Validation_AllAreRequiredTaxJurisdictionCodeQualifier(string taxJurisdictionCodeQualifier, string taxJurisdictionCode, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		//Required fields
		subject.StatusCode = "tR";
		subject.ReferenceIdentification = "G";
		//Test Parameters
		subject.TaxJurisdictionCodeQualifier = taxJurisdictionCodeQualifier;
		subject.TaxJurisdictionCode = taxJurisdictionCode;
		//At Least one
		subject.Description = "b";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "t3";
			subject.DateTimePeriod = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("x", "b", true)]
	[InlineData("x", "", true)]
	[InlineData("", "b", true)]
	public void Validation_AtLeastOneTaxJurisdictionCode(string taxJurisdictionCode, string description, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		//Required fields
		subject.StatusCode = "tR";
		subject.ReferenceIdentification = "G";
		//Test Parameters
		subject.TaxJurisdictionCode = taxJurisdictionCode;
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriodFormatQualifier) || !string.IsNullOrEmpty(subject.DateTimePeriod))
		{
			subject.DateTimePeriodFormatQualifier = "t3";
			subject.DateTimePeriod = "y";
		}
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "De";
			subject.TaxJurisdictionCode = "x";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
