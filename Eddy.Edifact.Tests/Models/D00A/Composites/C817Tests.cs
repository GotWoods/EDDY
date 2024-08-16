using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C817Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "H:x:p";

		var expected = new C817_AddressUsage()
		{
			AddressPurposeCode = "H",
			AddressTypeCode = "x",
			AddressStatusCode = "p",
		};

		var actual = Map.MapComposite<C817_AddressUsage>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
