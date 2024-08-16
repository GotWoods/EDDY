using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class CNXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CNX+";

		var expected = new CNX_ConnectionDetails()
		{
			ConnectionDetails = null,
		};

		var actual = Map.MapObject<CNX_ConnectionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
