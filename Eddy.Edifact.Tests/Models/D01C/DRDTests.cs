using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class DRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DRD+c+z+w+N";

		var expected = new DRD_DataRepresentationDetails()
		{
			StructureComponentIdentifier = "c",
			StructureTypeCode = "z",
			DataRepresentationTypeCode = "w",
			SizeMeasure = "N",
		};

		var actual = Map.MapObject<DRD_DataRepresentationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
