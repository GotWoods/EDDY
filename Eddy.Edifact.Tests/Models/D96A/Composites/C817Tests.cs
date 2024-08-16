using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C817Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "A:q:6";

		var expected = new C817_AddressUsage()
		{
			AddressPurposeCoded = "A",
			AddressTypeCoded = "q",
			AddressStatusCoded = "6",
		};

		var actual = Map.MapComposite<C817_AddressUsage>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
