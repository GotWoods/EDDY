using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D05B;
using Eddy.Edifact.Models.D05B.Composites;

namespace Eddy.Edifact.Tests.Models.D05B;

public class CNITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CNI+V++S";

		var expected = new CNI_ConsignmentInformation()
		{
			ConsolidationItemNumber = "V",
			DocumentMessageDetails = null,
			ConsignmentLoadSequenceIdentifier = "S",
		};

		var actual = Map.MapObject<CNI_ConsignmentInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
