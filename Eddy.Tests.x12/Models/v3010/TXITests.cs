using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TXITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TXI*Zs*7*5*T2*w";

		var expected = new TXI_TaxInformation()
		{
			TaxTypeCode = "Zs",
			MonetaryAmount = 7,
			Percent = 5,
			TaxJurisdictionCodeQualifier = "T2",
			TaxJurisdictionCode = "w",
		};

		var actual = Map.MapObject<TXI_TaxInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zs", true)]
	public void Validation_RequiredTaxTypeCode(string taxTypeCode, bool isValidExpected)
	{
		var subject = new TXI_TaxInformation();
		subject.TaxTypeCode = taxTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
