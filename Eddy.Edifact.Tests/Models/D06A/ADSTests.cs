using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class ADSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ADS+++M+W+Q++";

		var expected = new ADS_Address()
		{
			AddressUsage = null,
			AddressDetails = null,
			CityName = "M",
			PostalIdentificationCode = "W",
			CountryIdentifier = "Q",
			CountrySubEntityDetails = null,
			LocationIdentification = null,
		};

		var actual = Map.MapObject<ADS_Address>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
