using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C079Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "V:H:h:4:P:T:U";

		var expected = new C079_ComputerEnvironmentIdentification()
		{
			ComputerEnvironmentNameCode = "V",
			CodeListIdentificationCode = "H",
			CodeListResponsibleAgencyCode = "h",
			ComputerEnvironmentName = "4",
			VersionIdentifier = "P",
			ReleaseIdentifier = "T",
			ObjectIdentifier = "U",
		};

		var actual = Map.MapComposite<C079_ComputerEnvironmentIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
