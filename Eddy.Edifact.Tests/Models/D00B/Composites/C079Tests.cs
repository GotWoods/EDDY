using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B.Composites;

public class C079Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "H:p:n:J:z:u:d";

		var expected = new C079_ComputerEnvironmentIdentification()
		{
			ComputerEnvironmentNameCode = "H",
			CodeListIdentificationCode = "p",
			CodeListResponsibleAgencyCode = "n",
			ComputerEnvironmentName = "J",
			VersionIdentifier = "z",
			ReleaseIdentifier = "u",
			ObjectIdentifier = "d",
		};

		var actual = Map.MapComposite<C079_ComputerEnvironmentIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
