using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C564Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "l:0:U:T";

		var expected = new C564_PhysicalOrLogicalStateInformation()
		{
			PhysicalOrLogicalStateDescriptionCode = "l",
			CodeListIdentificationCode = "0",
			CodeListResponsibleAgencyCode = "U",
			PhysicalOrLogicalStateDescription = "T",
		};

		var actual = Map.MapComposite<C564_PhysicalOrLogicalStateInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
