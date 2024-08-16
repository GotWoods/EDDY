using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class ADRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ADR+++E+N+i++";

		var expected = new ADR_Address()
		{
			AddressUsage = null,
			AddressDetails = null,
			CityName = "E",
			PostcodeIdentification = "N",
			CountryCoded = "i",
			CountrySubEntityDetails = null,
			LocationIdentification = null,
		};

		var actual = Map.MapObject<ADR_Address>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
