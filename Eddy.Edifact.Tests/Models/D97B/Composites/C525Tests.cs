using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B.Composites;

public class C525Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "k:T:V:c";

		var expected = new C525_PurposeOfConveyanceCall()
		{
			PurposeOfConveyanceCallCoded = "k",
			CodeListQualifier = "T",
			CodeListResponsibleAgencyCoded = "V",
			PurposeOfConveyanceCall = "c",
		};

		var actual = Map.MapComposite<C525_PurposeOfConveyanceCall>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
