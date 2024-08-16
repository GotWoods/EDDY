using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class PCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PCI+m++C+";

		var expected = new PCI_PackageIdentification()
		{
			MarkingInstructionsCode = "m",
			MarksAndLabels = null,
			FullOrEmptyIndicatorCode = "C",
			TypeOfMarking = null,
		};

		var actual = Map.MapObject<PCI_PackageIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
