using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class CONTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CON+";

		var expected = new CON_ContactInformation()
		{
			ContactInformation = null,
		};

		var actual = Map.MapObject<CON_ContactInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
