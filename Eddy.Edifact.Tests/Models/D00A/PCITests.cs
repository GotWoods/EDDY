using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class PCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PCI+Y++h+";

		var expected = new PCI_PackageIdentification()
		{
			MarkingInstructionsCode = "Y",
			MarksAndLabels = null,
			ContainerOrPackageContentsIndicatorCode = "h",
			TypeOfMarking = null,
		};

		var actual = Map.MapObject<PCI_PackageIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
