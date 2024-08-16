using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E007Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "i:U:R:J";

		var expected = new E007_TrafficRestrictionDetails()
		{
			TrafficRestrictionCoded = "i",
			TrafficRestrictionTypeCoded = "U",
			TrafficRestrictionTypeQualifier = "R",
			FreeTextValue = "J",
		};

		var actual = Map.MapComposite<E007_TrafficRestrictionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
