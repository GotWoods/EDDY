using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C241Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "c:V:M:v";

		var expected = new C241_DutyTaxFeeType()
		{
			DutyOrTaxOrFeeTypeNameCode = "c",
			CodeListIdentificationCode = "V",
			CodeListResponsibleAgencyCode = "M",
			DutyOrTaxOrFeeTypeName = "v",
		};

		var actual = Map.MapComposite<C241_DutyTaxFeeType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
