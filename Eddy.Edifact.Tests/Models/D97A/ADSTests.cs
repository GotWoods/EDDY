using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class ADSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ADS+++S+K+h++";

		var expected = new ADS_Address()
		{
			AddressUsage = null,
			AddressDetails = null,
			CityName = "S",
			PostcodeIdentification = "K",
			CountryCoded = "h",
			CountrySubEntityDetails = null,
			LocationIdentification = null,
		};

		var actual = Map.MapObject<ADS_Address>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
