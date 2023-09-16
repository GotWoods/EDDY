using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.Tests.Models.v7050;

public class TXITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TXI*oO*8*3*gF*A*L*o*1*U*E*H*8*M";

		var expected = new TXI_TaxInformation()
		{
			TaxTypeCode = "oO",
			MonetaryAmount = 8,
			PercentageAsDecimal = 3,
			TaxJurisdictionCodeQualifier = "gF",
			TaxJurisdictionCode = "A",
			TaxExemptCode = "L",
			RelationshipCode = "o",
			DollarBasisForPercent = 1,
			TaxIdentificationNumber = "U",
			AssignedIdentification = "E",
			Description = "H",
			Quantity = 8,
			NameLastOrOrganizationName = "M",
		};

		var actual = Map.MapObject<TXI_TaxInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oO", true)]
	public void Validation_RequiredTaxTypeCode(string taxTypeCode, bool isValidExpected)
	{
		var subject = new TXI_TaxInformation();
		subject.TaxTypeCode = taxTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "gF";
			subject.TaxJurisdictionCode = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gF", "A", true)]
	[InlineData("gF", "", false)]
	[InlineData("", "A", false)]
	public void Validation_AllAreRequiredTaxJurisdictionCodeQualifier(string taxJurisdictionCodeQualifier, string taxJurisdictionCode, bool isValidExpected)
	{
		var subject = new TXI_TaxInformation();
		subject.TaxTypeCode = "oO";
		subject.TaxJurisdictionCodeQualifier = taxJurisdictionCodeQualifier;
		subject.TaxJurisdictionCode = taxJurisdictionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(1, 3, true)]
	[InlineData(1, 0, false)]
	[InlineData(0, 3, true)]
	public void Validation_ARequiresBDollarBasisForPercent(decimal dollarBasisForPercent, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new TXI_TaxInformation();
		subject.TaxTypeCode = "oO";
		if (dollarBasisForPercent > 0)
			subject.DollarBasisForPercent = dollarBasisForPercent;
		if (percentageAsDecimal > 0)
			subject.PercentageAsDecimal = percentageAsDecimal;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "gF";
			subject.TaxJurisdictionCode = "A";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
