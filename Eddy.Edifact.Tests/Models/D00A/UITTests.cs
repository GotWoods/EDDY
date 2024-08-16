using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UITTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UIT+s+M";

		var expected = new UIT_InteractiveMessageTrailer()
		{
			InteractiveMessageReferenceNumber = "s",
			NumberOfSegmentsInAMessage = "M",
		};

		var actual = Map.MapObject<UIT_InteractiveMessageTrailer>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
