using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96B;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Tests.Models.D96B;

public class ERPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ERP++";

		var expected = new ERP_ErrorPointDetails()
		{
			ErrorPointDetails = null,
			ErrorSegmentPointDetails = null,
		};

		var actual = Map.MapObject<ERP_ErrorPointDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
