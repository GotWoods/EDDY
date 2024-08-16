using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class PCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PCI+d++F+";

		var expected = new PCI_PackageIdentification()
		{
			MarkingInstructionsCoded = "d",
			MarksAndLabels = null,
			ContainerOrPackageStateCoded = "F",
			TypeOfMarking = null,
		};

		var actual = Map.MapObject<PCI_PackageIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
