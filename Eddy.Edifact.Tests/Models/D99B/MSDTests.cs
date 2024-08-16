using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class MSDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MSD++4+";

		var expected = new MSD_MessageActionDetails()
		{
			MessageProcessingDetails = null,
			ResponseTypeCode = "4",
			ObjectIdentification = null,
		};

		var actual = Map.MapObject<MSD_MessageActionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
