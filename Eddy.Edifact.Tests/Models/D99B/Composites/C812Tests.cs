using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C812Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "y:d:q:F";

		var expected = new C812_ResponseDetails()
		{
			ResponseCoded = "y",
			CodeListIdentificationCode = "d",
			CodeListResponsibleAgencyCode = "q",
			Response = "F",
		};

		var actual = Map.MapComposite<C812_ResponseDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
