using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class CNITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CNI+4++p";

		var expected = new CNI_ConsignmentInformation()
		{
			ConsolidationItemNumber = "4",
			DocumentMessageDetails = null,
			ConsignmentLoadSequenceNumber = "p",
		};

		var actual = Map.MapObject<CNI_ConsignmentInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
