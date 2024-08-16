using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class CNITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CNI+c++c";

		var expected = new CNI_ConsignmentInformation()
		{
			ConsolidationItemNumber = "c",
			DocumentMessageDetails = null,
			ConsignmentLoadSequenceIdentifier = "c",
		};

		var actual = Map.MapObject<CNI_ConsignmentInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
