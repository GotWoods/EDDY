using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C243Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "f:m:x:M:a:U:h";

		var expected = new C243_DutyTaxFeeDetail()
		{
			DutyTaxFeeRateIdentification = "f",
			CodeListQualifier = "m",
			CodeListResponsibleAgencyCoded = "x",
			DutyTaxFeeRate = "M",
			DutyTaxFeeRateBasisIdentification = "a",
			CodeListQualifier2 = "U",
			CodeListResponsibleAgencyCoded2 = "h",
		};

		var actual = Map.MapComposite<C243_DutyTaxFeeDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
