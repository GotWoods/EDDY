using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class TXITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TXI*qA*5*8*x0*w*E*d*4*S*R";

		var expected = new TXI_TaxInformation()
		{
			TaxTypeCode = "qA",
			MonetaryAmount = 5,
			PercentageAsDecimal = 8,
			TaxJurisdictionCodeQualifier = "x0",
			TaxJurisdictionCode = "w",
			TaxExemptCode = "E",
			RelationshipCode = "d",
			DollarBasisForPercent = 4,
			TaxIdentificationNumber = "S",
			AssignedIdentification = "R",
		};

		var actual = Map.MapObject<TXI_TaxInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qA", true)]
	public void Validation_RequiredTaxTypeCode(string taxTypeCode, bool isValidExpected)
	{
		var subject = new TXI_TaxInformation();
		subject.TaxTypeCode = taxTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "x0";
			subject.TaxJurisdictionCode = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x0", "w", true)]
	[InlineData("x0", "", false)]
	[InlineData("", "w", false)]
	public void Validation_AllAreRequiredTaxJurisdictionCodeQualifier(string taxJurisdictionCodeQualifier, string taxJurisdictionCode, bool isValidExpected)
	{
		var subject = new TXI_TaxInformation();
		subject.TaxTypeCode = "qA";
		subject.TaxJurisdictionCodeQualifier = taxJurisdictionCodeQualifier;
		subject.TaxJurisdictionCode = taxJurisdictionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(4, 8, true)]
	[InlineData(4, 0, false)]
	[InlineData(0, 8, true)]
	public void Validation_ARequiresBDollarBasisForPercent(decimal dollarBasisForPercent, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new TXI_TaxInformation();
		subject.TaxTypeCode = "qA";
		if (dollarBasisForPercent > 0)
			subject.DollarBasisForPercent = dollarBasisForPercent;
		if (percentageAsDecimal > 0)
			subject.PercentageAsDecimal = percentageAsDecimal;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "x0";
			subject.TaxJurisdictionCode = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
