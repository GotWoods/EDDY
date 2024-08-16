using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A.Composites;

public class C956Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "e:W:k:S";

		var expected = new C956_AttributeDetails()
		{
			AttributeIdentification = "e",
			CodeListQualifier = "W",
			CodeListResponsibleAgencyCoded = "k",
			Attribute = "S",
		};

		var actual = Map.MapComposite<C956_AttributeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
