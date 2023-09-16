using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class TXITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TXI*Mq*3*4*v0*K*x*A*4*Y*F";

		var expected = new TXI_TaxInformation()
		{
			TaxTypeCode = "Mq",
			MonetaryAmount = 3,
			Percent = 4,
			TaxJurisdictionCodeQualifier = "v0",
			TaxJurisdictionCode = "K",
			TaxExemptCode = "x",
			RelationshipCode = "A",
			DollarBasisForPercent = 4,
			TaxIdentificationNumber = "Y",
			AssignedIdentification = "F",
		};

		var actual = Map.MapObject<TXI_TaxInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Mq", true)]
	public void Validation_RequiredTaxTypeCode(string taxTypeCode, bool isValidExpected)
	{
		var subject = new TXI_TaxInformation();
		subject.TaxTypeCode = taxTypeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "v0";
			subject.TaxJurisdictionCode = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("v0", "K", true)]
	[InlineData("v0", "", false)]
	[InlineData("", "K", false)]
	public void Validation_AllAreRequiredTaxJurisdictionCodeQualifier(string taxJurisdictionCodeQualifier, string taxJurisdictionCode, bool isValidExpected)
	{
		var subject = new TXI_TaxInformation();
		subject.TaxTypeCode = "Mq";
		subject.TaxJurisdictionCodeQualifier = taxJurisdictionCodeQualifier;
		subject.TaxJurisdictionCode = taxJurisdictionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(4, 4, true)]
	[InlineData(4, 0, false)]
	[InlineData(0, 4, true)]
	public void Validation_ARequiresBDollarBasisForPercent(decimal dollarBasisForPercent, decimal percent, bool isValidExpected)
	{
		var subject = new TXI_TaxInformation();
		subject.TaxTypeCode = "Mq";
		if (dollarBasisForPercent > 0)
			subject.DollarBasisForPercent = dollarBasisForPercent;
		if (percent > 0)
			subject.Percent = percent;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCodeQualifier) || !string.IsNullOrEmpty(subject.TaxJurisdictionCode))
		{
			subject.TaxJurisdictionCodeQualifier = "v0";
			subject.TaxJurisdictionCode = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
