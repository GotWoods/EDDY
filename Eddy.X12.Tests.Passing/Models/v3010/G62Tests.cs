using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G62Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G62*FO*ocUhat*S*wzXU*jj";

		var expected = new G62_DateTime()
		{
			DateQualifier = "FO",
			Date = "ocUhat",
			TimeQualifier = "S",
			Time = "wzXU",
			TimeCode = "jj",
		};

		var actual = Map.MapObject<G62_DateTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
