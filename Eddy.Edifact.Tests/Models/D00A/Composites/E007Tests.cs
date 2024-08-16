using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E007Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "Y:f:G:2";

		var expected = new E007_TrafficRestrictionDetails()
		{
			TrafficRestrictionCode = "Y",
			TrafficRestrictionApplicationCode = "f",
			TrafficRestrictionTypeCodeQualifier = "G",
			FreeTextValue = "2",
		};

		var actual = Map.MapComposite<E007_TrafficRestrictionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
