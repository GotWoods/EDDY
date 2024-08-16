using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C241Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "N:V:w:w";

		var expected = new C241_DutyTaxFeeType()
		{
			DutyTaxFeeTypeCoded = "N",
			CodeListQualifier = "V",
			CodeListResponsibleAgencyCoded = "w",
			DutyTaxFeeType = "w",
		};

		var actual = Map.MapComposite<C241_DutyTaxFeeType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
