using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TXITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TXI*Ql*4*1*XX*S*5*0*8*e*k*U*8*L";

		var expected = new TXI_TaxInformation()
		{
			TaxTypeCode = "Ql",
			MonetaryAmount = 4,
			PercentageAsDecimal = 1,
			TaxJurisdictionCodeQualifier = "XX",
			TaxJurisdictionCode = "S",
			TaxExemptCode = "5",
			RelationshipCode = "0",
			DollarBasisForPercent = 8,
			TaxIdentificationNumber = "e",
			AssignedIdentification = "k",
			Description = "U",
			Quantity = 8,
			NameLastOrOrganizationName = "L",
		};

		var actual = Map.MapObject<TXI_TaxInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ql", true)]
	public void Validation_RequiredTaxTypeCode(string taxTypeCode, bool isValidExpected)
	{
		var subject = new TXI_TaxInformation();
		subject.TaxTypeCode = taxTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("XX", "S", true)]
	[InlineData("", "S", false)]
	[InlineData("XX", "", false)]
	public void Validation_AllAreRequiredTaxJurisdictionCodeQualifier(string taxJurisdictionCodeQualifier, string taxJurisdictionCode, bool isValidExpected)
	{
		var subject = new TXI_TaxInformation();
		subject.TaxTypeCode = "Ql";
		subject.TaxJurisdictionCodeQualifier = taxJurisdictionCodeQualifier;
		subject.TaxJurisdictionCode = taxJurisdictionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(0, 1, true)]
	[InlineData(8, 0, false)]
	public void Validation_ARequiresBDollarBasisForPercent(decimal dollarBasisForPercent, decimal percentageAsDecimal, bool isValidExpected)
	{
		var subject = new TXI_TaxInformation();
		subject.TaxTypeCode = "Ql";
		if (dollarBasisForPercent > 0)
		subject.DollarBasisForPercent = dollarBasisForPercent;
		if (percentageAsDecimal > 0)
		subject.PercentageAsDecimal = percentageAsDecimal;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
