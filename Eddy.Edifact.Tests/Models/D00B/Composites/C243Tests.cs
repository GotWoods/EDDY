using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C243Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "j:b:A:l:P:E:g";

		var expected = new C243_DutyTaxFeeDetail()
		{
			DutyOrTaxOrFeeRateCode = "j",
			CodeListIdentificationCode = "b",
			CodeListResponsibleAgencyCode = "A",
			DutyOrTaxOrFeeRate = "l",
			DutyOrTaxOrFeeRateBasisCode = "P",
			CodeListIdentificationCode2 = "E",
			CodeListResponsibleAgencyCode2 = "g",
		};

		var actual = Map.MapComposite<C243_DutyTaxFeeDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
