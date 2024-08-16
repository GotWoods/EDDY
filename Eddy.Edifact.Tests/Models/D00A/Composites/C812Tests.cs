using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C812Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "n:P:r:H";

		var expected = new C812_ResponseDetails()
		{
			ResponseDescriptionCode = "n",
			CodeListIdentificationCode = "P",
			CodeListResponsibleAgencyCode = "r",
			ResponseDescription = "H",
		};

		var actual = Map.MapComposite<C812_ResponseDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}