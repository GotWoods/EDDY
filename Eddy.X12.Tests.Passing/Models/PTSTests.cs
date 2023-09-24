using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PTSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PTS*vs*b*Z*bM*u*oD*YM*X*r*Ar*J1";

		var expected = new PTS_PropertyTaxStatus()
		{
			StatusCode = "vs",
			ReferenceIdentification = "b",
			TaxServicePaymentCode = "Z",
			DateTimePeriodFormatQualifier = "bM",
			DateTimePeriod = "u",
			StatusCode2 = "oD",
			TaxJurisdictionCodeQualifier = "YM",
			TaxJurisdictionCode = "X",
			Description = "r",
			TypeOfTaxingAuthorityCode = "Ar",
			StatusCode3 = "J1",
		};

		var actual = Map.MapObject<PTS_PropertyTaxStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vs", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		subject.ReferenceIdentification = "b";
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		subject.StatusCode = "vs";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("bM", "u", true)]
	[InlineData("", "u", false)]
	[InlineData("bM", "", false)]
	public void Validation_AllAreRequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, string dateTimePeriod, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		subject.StatusCode = "vs";
		subject.ReferenceIdentification = "b";
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		subject.DateTimePeriod = dateTimePeriod;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("YM", "X", true)]
	[InlineData("", "X", false)]
	[InlineData("YM", "", false)]
	public void Validation_AllAreRequiredTaxJurisdictionCodeQualifier(string taxJurisdictionCodeQualifier, string taxJurisdictionCode, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		subject.StatusCode = "vs";
		subject.ReferenceIdentification = "b";
		subject.TaxJurisdictionCodeQualifier = taxJurisdictionCodeQualifier;
		subject.TaxJurisdictionCode = taxJurisdictionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("X","r", true)]
	[InlineData("", "r", true)]
	[InlineData("X", "", true)]
	public void Validation_AtLeastOneTaxJurisdictionCode(string taxJurisdictionCode, string description, bool isValidExpected)
	{
		var subject = new PTS_PropertyTaxStatus();
		subject.StatusCode = "vs";
		subject.ReferenceIdentification = "b";
		subject.TaxJurisdictionCode = taxJurisdictionCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
