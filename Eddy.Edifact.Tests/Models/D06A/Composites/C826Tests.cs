using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A.Composites;

public class C826Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "f:t:8:b";

		var expected = new C826_Action()
		{
			ActionCode = "f",
			CodeListIdentificationCode = "t",
			CodeListResponsibleAgencyCode = "8",
			ActionDescription = "b",
		};

		var actual = Map.MapComposite<C826_Action>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
