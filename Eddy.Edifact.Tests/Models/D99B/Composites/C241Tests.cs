using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C241Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "B:i:c:m";

		var expected = new C241_DutyTaxFeeType()
		{
			DutyTaxFeeTypeNameCode = "B",
			CodeListIdentificationCode = "i",
			CodeListResponsibleAgencyCode = "c",
			DutyTaxFeeTypeName = "m",
		};

		var actual = Map.MapComposite<C241_DutyTaxFeeType>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
