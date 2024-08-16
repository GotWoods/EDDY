using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class C812Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "p:H:k:a";

		var expected = new C812_ResponseDetails()
		{
			ResponseCoded = "p",
			CodeListQualifier = "H",
			CodeListResponsibleAgencyCoded = "k",
			Response = "a",
		};

		var actual = Map.MapComposite<C812_ResponseDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
