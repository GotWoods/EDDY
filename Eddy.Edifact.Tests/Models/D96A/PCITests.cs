using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class PCITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PCI+8++s+";

		var expected = new PCI_PackageIdentification()
		{
			MarkingInstructionsCoded = "8",
			MarksAndLabels = null,
			ContainerPackageStatusCoded = "s",
			TypeOfMarking = null,
		};

		var actual = Map.MapObject<PCI_PackageIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
