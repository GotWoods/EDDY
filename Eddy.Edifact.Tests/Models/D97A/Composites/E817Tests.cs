using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E817Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "n:y:l";

		var expected = new E817_AddressUsage()
		{
			AddressPurposeCoded = "n",
			AddressTypeCoded = "y",
			AddressStatusCoded = "l",
		};

		var actual = Map.MapComposite<E817_AddressUsage>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
