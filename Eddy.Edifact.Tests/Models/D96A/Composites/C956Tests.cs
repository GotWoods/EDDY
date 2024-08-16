using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C956Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "X:4:X:b";

		var expected = new C956_AttributeDetails()
		{
			AttributeCoded = "X",
			CodeListQualifier = "4",
			CodeListResponsibleAgencyCoded = "X",
			Attribute = "b",
		};

		var actual = Map.MapComposite<C956_AttributeDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
