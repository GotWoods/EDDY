using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class ADSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ADS+++D+V+1++";

		var expected = new ADS_Address()
		{
			AddressUsage = null,
			AddressDetails = null,
			CityName = "D",
			PostalIdentificationCode = "V",
			CountryNameCode = "1",
			CountrySubEntityDetails = null,
			LocationIdentification = null,
		};

		var actual = Map.MapObject<ADS_Address>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
