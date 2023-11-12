using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class TATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TA*si*l*g*Tm*U*g*0u";

		var expected = new TA_TaxAuthority()
		{
			TaxJurisdictionCodeQualifier = "si",
			TaxJurisdictionCode = "l",
			Description = "g",
			TypeOfTaxingAuthorityCode = "Tm",
			Description2 = "U",
			TaxServicePaymentCode = "g",
			StatusCode = "0u",
		};

		var actual = Map.MapObject<TA_TaxAuthority>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("si", "l", true)]
	[InlineData("si", "", false)]
	[InlineData("", "l", false)]
	public void Validation_AllAreRequiredTaxJurisdictionCodeQualifier(string taxJurisdictionCodeQualifier, string taxJurisdictionCode, bool isValidExpected)
	{
		var subject = new TA_TaxAuthority();
		//Required fields
		//Test Parameters
		subject.TaxJurisdictionCodeQualifier = taxJurisdictionCodeQualifier;
		subject.TaxJurisdictionCode = taxJurisdictionCode;
		//At Least one
		subject.Description = "g";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TypeOfTaxingAuthorityCode) || !string.IsNullOrEmpty(subject.TypeOfTaxingAuthorityCode) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.TypeOfTaxingAuthorityCode = "Tm";
			subject.Description2 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("l", "g", true)]
	[InlineData("l", "", true)]
	[InlineData("", "g", true)]
	public void Validation_AtLeastOneTaxJurisdictionCode(string taxJurisdictionCode, string description, bool isValidExpected)
	{
		var subject = new TA_TaxAuthority();
		//Required fields
		//Test Parameters
		subject.TaxJurisdictionCode = taxJurisdictionCode;
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "si";
			subject.TaxJurisdictionCode = "l";
		}
		if(!string.IsNullOrEmpty(subject.TypeOfTaxingAuthorityCode) || !string.IsNullOrEmpty(subject.TypeOfTaxingAuthorityCode) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.TypeOfTaxingAuthorityCode = "Tm";
			subject.Description2 = "U";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Tm", "U", true)]
	[InlineData("Tm", "", false)]
	[InlineData("", "U", false)]
	public void Validation_AllAreRequiredTypeOfTaxingAuthorityCode(string typeOfTaxingAuthorityCode, string description2, bool isValidExpected)
	{
		var subject = new TA_TaxAuthority();
		//Required fields
		//Test Parameters
		subject.TypeOfTaxingAuthorityCode = typeOfTaxingAuthorityCode;
		subject.Description2 = description2;
		//At Least one
		subject.TaxJurisdictionCode = "l";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "si";
			subject.TaxJurisdictionCode = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
