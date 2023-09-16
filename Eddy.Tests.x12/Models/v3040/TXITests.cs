using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class TXITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TXI*l4*1*9*fR*a*p*D*9*3";

		var expected = new TXI_TaxInformation()
		{
			TaxTypeCode = "l4",
			MonetaryAmount = 1,
			Percent = 9,
			TaxJurisdictionCodeQualifier = "fR",
			TaxJurisdictionCode = "a",
			TaxExemptCode = "p",
			PriceRelationshipCode = "D",
			DollarBasisForPercent = 9,
			TaxIdentificationNumber = "3",
		};

		var actual = Map.MapObject<TXI_TaxInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l4", true)]
	public void Validation_RequiredTaxTypeCode(string taxTypeCode, bool isValidExpected)
	{
		var subject = new TXI_TaxInformation();
		subject.TaxTypeCode = taxTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "fR";
			subject.TaxJurisdictionCode = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fR", "a", true)]
	[InlineData("fR", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredTaxJurisdictionCodeQualifier(string taxJurisdictionCodeQualifier, string taxJurisdictionCode, bool isValidExpected)
	{
		var subject = new TXI_TaxInformation();
		subject.TaxTypeCode = "l4";
		subject.TaxJurisdictionCodeQualifier = taxJurisdictionCodeQualifier;
		subject.TaxJurisdictionCode = taxJurisdictionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(9, 9, true)]
	[InlineData(9, 0, false)]
	[InlineData(0, 9, true)]
	public void Validation_ARequiresBDollarBasisForPercent(decimal dollarBasisForPercent, decimal percent, bool isValidExpected)
	{
		var subject = new TXI_TaxInformation();
		subject.TaxTypeCode = "l4";
		if (dollarBasisForPercent > 0)
			subject.DollarBasisForPercent = dollarBasisForPercent;
		if (percent > 0)
			subject.Percent = percent;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "fR";
			subject.TaxJurisdictionCode = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
