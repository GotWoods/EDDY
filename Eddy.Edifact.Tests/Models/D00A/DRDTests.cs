using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class DRDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DRD+g+J+9+f";

		var expected = new DRD_DataRepresentationDetails()
		{
			StructureComponentIdentifier = "g",
			StructureTypeCode = "J",
			DataRepresentationTypeCode = "9",
			SizeValue = "f",
		};

		var actual = Map.MapObject<DRD_DataRepresentationDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
