using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E007Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "K:x:X:a";

		var expected = new E007_TrafficRestrictionDetails()
		{
			TrafficRestrictionCode = "K",
			TrafficRestrictionApplicationCode = "x",
			TrafficRestrictionTypeCodeQualifier = "X",
			FreeText = "a",
		};

		var actual = Map.MapComposite<E007_TrafficRestrictionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
