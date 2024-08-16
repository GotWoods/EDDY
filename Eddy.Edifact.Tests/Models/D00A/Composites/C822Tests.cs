using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C822Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "6:Y:A:w";

		var expected = new C822_DamageArea()
		{
			DamageAreaDescriptionCode = "6",
			CodeListIdentificationCode = "Y",
			CodeListResponsibleAgencyCode = "A",
			DamageAreaDescription = "w",
		};

		var actual = Map.MapComposite<C822_DamageArea>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
