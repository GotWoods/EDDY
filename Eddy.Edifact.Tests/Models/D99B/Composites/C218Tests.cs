using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C218Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "V:R:0:N";

		var expected = new C218_HazardousMaterial()
		{
			HazardousMaterialClassCodeIdentification = "V",
			CodeListIdentificationCode = "R",
			CodeListResponsibleAgencyCode = "0",
			HazardousMaterialClass = "N",
		};

		var actual = Map.MapComposite<C218_HazardousMaterial>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
