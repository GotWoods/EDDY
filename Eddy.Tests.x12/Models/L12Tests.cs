using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class L12Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L12*i*B";

		var expected = new L12_AlternateLadingDescription()
		{
			LadingDescriptionQualifier = "i",
			Description = "B",
		};

		var actual = Map.MapObject<L12_AlternateLadingDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
