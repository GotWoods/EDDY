using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C079Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "x:v:V:z:M:N:l";

		var expected = new C079_ComputerEnvironmentIdentification()
		{
			ComputerEnvironmentCoded = "x",
			CodeListIdentificationCode = "v",
			CodeListResponsibleAgencyCode = "V",
			ComputerEnvironment = "z",
			Version = "M",
			Release = "N",
			ObjectIdentifier = "l",
		};

		var actual = Map.MapComposite<C079_ComputerEnvironmentIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
