using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C525Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "4:4:t:T";

		var expected = new C525_PurposeOfConveyanceCall()
		{
			ConveyanceCallPurposeDescriptionCode = "4",
			CodeListIdentificationCode = "4",
			CodeListResponsibleAgencyCode = "t",
			ConveyanceCallPurposeDescription = "T",
		};

		var actual = Map.MapComposite<C525_PurposeOfConveyanceCall>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
