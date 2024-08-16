using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C243Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "t:o:t:E:3:A:g";

		var expected = new C243_DutyTaxFeeDetail()
		{
			DutyOrTaxOrFeeRateDescriptionCode = "t",
			CodeListIdentificationCode = "o",
			CodeListResponsibleAgencyCode = "t",
			DutyOrTaxOrFeeRateDescription = "E",
			DutyOrTaxOrFeeRateBasisCode = "3",
			CodeListIdentificationCode2 = "A",
			CodeListResponsibleAgencyCode2 = "g",
		};

		var actual = Map.MapComposite<C243_DutyTaxFeeDetail>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
