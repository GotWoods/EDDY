using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C243Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "f:g:Q:z:v:Q:B";

		var expected = new C243_DutyTaxFeeDetail()
		{
			DutyTaxFeeRateIdentification = "f",
			CodeListIdentificationCode = "g",
			CodeListResponsibleAgencyCode = "Q",
			DutyTaxFeeRate = "z",
			DutyTaxFeeRateBasisIdentification = "v",
			CodeListIdentificationCode2 = "Q",
			CodeListResponsibleAgencyCode2 = "B",
		};

		var actual = Map.MapComposite<C243_DutyTaxFeeDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
