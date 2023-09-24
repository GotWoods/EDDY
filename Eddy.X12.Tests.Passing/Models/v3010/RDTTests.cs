using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class RDTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RDT*7*a*n13*AiTSvH*Z490*Lg";

		var expected = new RDT_RevisionDateTime()
		{
			RevisionLevelCode = "7",
			RevisionValue = "a",
			DateTimeQualifier = "n13",
			Date = "AiTSvH",
			Time = "Z490",
			TimeCode = "Lg",
		};

		var actual = Map.MapObject<RDT_RevisionDateTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
