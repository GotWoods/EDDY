using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TA*eg*o*0*TB*x*T*c9";

		var expected = new TA_TaxAuthority()
		{
			TaxJurisdictionCodeQualifier = "eg",
			TaxJurisdictionCode = "o",
			Description = "0",
			TypeOfTaxingAuthorityCode = "TB",
			Description2 = "x",
			TaxServicePaymentCode = "T",
			StatusCode = "c9",
		};

		var actual = Map.MapObject<TA_TaxAuthority>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("eg", "o", true)]
	[InlineData("", "o", false)]
	[InlineData("eg", "", false)]
	public void Validation_AllAreRequiredTaxJurisdictionCodeQualifier(string taxJurisdictionCodeQualifier, string taxJurisdictionCode, bool isValidExpected)
	{
		var subject = new TA_TaxAuthority();
		subject.TaxJurisdictionCodeQualifier = taxJurisdictionCodeQualifier;
		subject.TaxJurisdictionCode = taxJurisdictionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("o","0", true)]
	[InlineData("", "0", true)]
	[InlineData("o", "", true)]
	public void Validation_AtLeastOneTaxJurisdictionCode(string taxJurisdictionCode, string description, bool isValidExpected)
	{
		var subject = new TA_TaxAuthority();
		subject.TaxJurisdictionCode = taxJurisdictionCode;
		subject.Description = description;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("TB", "x", true)]
	[InlineData("", "x", false)]
	[InlineData("TB", "", false)]
	public void Validation_AllAreRequiredTypeOfTaxingAuthorityCode(string typeOfTaxingAuthorityCode, string description2, bool isValidExpected)
	{
		var subject = new TA_TaxAuthority();
		subject.TypeOfTaxingAuthorityCode = typeOfTaxingAuthorityCode;
		subject.Description2 = description2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
