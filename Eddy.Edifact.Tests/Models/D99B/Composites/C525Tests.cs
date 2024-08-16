using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C525Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "8:R:2:6";

		var expected = new C525_PurposeOfConveyanceCall()
		{
			ConveyanceCallPurposeDescriptionCode = "8",
			CodeListIdentificationCode = "R",
			CodeListResponsibleAgencyCode = "2",
			ConveyanceCallPurposeDescription = "6",
		};

		var actual = Map.MapComposite<C525_PurposeOfConveyanceCall>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
