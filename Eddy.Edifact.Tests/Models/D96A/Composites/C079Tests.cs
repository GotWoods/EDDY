using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C079Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "s:c:9:7:0:V:f";

		var expected = new C079_ComputerEnvironmentIdentification()
		{
			ComputerEnvironmentCoded = "s",
			CodeListQualifier = "c",
			CodeListResponsibleAgencyCoded = "9",
			ComputerEnvironment = "7",
			Version = "0",
			Release = "V",
			IdentityNumber = "f",
		};

		var actual = Map.MapComposite<C079_ComputerEnvironmentIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
