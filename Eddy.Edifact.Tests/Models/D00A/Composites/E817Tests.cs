using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E817Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "W:U:k";

		var expected = new E817_AddressUsage()
		{
			AddressPurposeCode = "W",
			AddressTypeCode = "U",
			AddressStatusCode = "k",
		};

		var actual = Map.MapComposite<E817_AddressUsage>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
