using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B.Composites;

public class E007Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "P:Z:A:f";

		var expected = new E007_TrafficRestrictionDetails()
		{
			TrafficRestrictionCoded = "P",
			TrafficRestrictionTypeCoded = "Z",
			TrafficRestrictionTypeQualifier = "A",
			FreeText = "f",
		};

		var actual = Map.MapComposite<E007_TrafficRestrictionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
