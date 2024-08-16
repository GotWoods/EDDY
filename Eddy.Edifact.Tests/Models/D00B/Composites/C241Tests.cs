using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C241Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "a:X:U:1";

		var expected = new C241_DutyTaxFeeType()
		{
			DutyOrTaxOrFeeTypeNameCode = "a",
			CodeListIdentificationCode = "X",
			CodeListResponsibleAgencyCode = "U",
			DutyOrTaxOrFeeTypeName = "1",
		};

		var actual = Map.MapComposite<C241_DutyTaxFeeType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
