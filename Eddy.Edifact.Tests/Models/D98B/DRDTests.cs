using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class DRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DRD+2+U+H+r";

		var expected = new DRD_DataRepresentationDetails()
		{
			StructureComponentIdentifier = "2",
			StructureTypeCoded = "U",
			DataRepresentationTypeCoded = "H",
			Size = "r",
		};

		var actual = Map.MapObject<DRD_DataRepresentationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
