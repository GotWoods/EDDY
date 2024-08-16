using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class MAPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MAP++5+";

		var expected = new MAP_MessageApplicationProductInformation()
		{
			InstructionInformation = null,
			PartyName = "5",
			MessageApplicationProductSpecification = null,
		};

		var actual = Map.MapObject<MAP_MessageApplicationProductInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
