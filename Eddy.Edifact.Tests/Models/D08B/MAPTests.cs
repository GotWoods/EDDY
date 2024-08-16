using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;
using Eddy.Edifact.Models.D08B.Composites;

namespace Eddy.Edifact.Tests.Models.D08B;

public class MAPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MAP++b+";

		var expected = new MAP_MessageApplicationProductInformation()
		{
			InstructionInformation = null,
			PartyName = "b",
			MessageApplicationProductSpecification = null,
		};

		var actual = Map.MapObject<MAP_MessageApplicationProductInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
