using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class TATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TA*nl*J*t*lt*G*F";

		var expected = new TA_TaxAuthority()
		{
			TaxJurisdictionCodeQualifier = "nl",
			TaxJurisdictionCode = "J",
			Description = "t",
			TypeOfTaxingAuthorityCode = "lt",
			Description2 = "G",
			TaxServicePaymentCode = "F",
		};

		var actual = Map.MapObject<TA_TaxAuthority>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("nl", "J", true)]
	[InlineData("nl", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredTaxJurisdictionCodeQualifier(string taxJurisdictionCodeQualifier, string taxJurisdictionCode, bool isValidExpected)
	{
		var subject = new TA_TaxAuthority();
		//Required fields
		//Test Parameters
		subject.TaxJurisdictionCodeQualifier = taxJurisdictionCodeQualifier;
		subject.TaxJurisdictionCode = taxJurisdictionCode;
		//At Least one
		subject.Description = "t";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TypeOfTaxingAuthorityCode) || !string.IsNullOrEmpty(subject.TypeOfTaxingAuthorityCode) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.TypeOfTaxingAuthorityCode = "lt";
			subject.Description2 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("J", "t", true)]
	[InlineData("J", "", true)]
	[InlineData("", "t", true)]
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
			subject.TaxJurisdictionCodeQualifier = "nl";
			subject.TaxJurisdictionCode = "J";
		}
		if(!string.IsNullOrEmpty(subject.TypeOfTaxingAuthorityCode) || !string.IsNullOrEmpty(subject.TypeOfTaxingAuthorityCode) || !string.IsNullOrEmpty(subject.Description2))
		{
			subject.TypeOfTaxingAuthorityCode = "lt";
			subject.Description2 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("lt", "G", true)]
	[InlineData("lt", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredTypeOfTaxingAuthorityCode(string typeOfTaxingAuthorityCode, string description2, bool isValidExpected)
	{
		var subject = new TA_TaxAuthority();
		//Required fields
		//Test Parameters
		subject.TypeOfTaxingAuthorityCode = typeOfTaxingAuthorityCode;
		subject.Description2 = description2;
		//At Least one
		subject.TaxJurisdictionCode = "J";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "nl";
			subject.TaxJurisdictionCode = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
