using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.Tests.Models.v7040;

public class ISXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISX*a*t";

		var expected = new ISX_InterchangeSyntaxExtension()
		{
			ReleaseCharacter = "a",
			CharacterEncoding = "t",
		};

		var actual = Map.MapObject<ISX_InterchangeSyntaxExtension>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
