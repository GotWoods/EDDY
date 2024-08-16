using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C812Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "h:Q:m:U";

		var expected = new C812_ResponseDetails()
		{
			ResponseDescriptionCode = "h",
			CodeListIdentificationCode = "Q",
			CodeListResponsibleAgencyCode = "m",
			ResponseDescription = "U",
		};

		var actual = Map.MapComposite<C812_ResponseDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
