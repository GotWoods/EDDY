using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class ADRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ADR+++Z+l+w++";

		var expected = new ADR_Address()
		{
			AddressUsage = null,
			AddressDetails = null,
			CityName = "Z",
			PostalIdentificationCode = "l",
			CountryIdentifier = "w",
			CountrySubdivisionDetails = null,
			LocationIdentification = null,
		};

		var actual = Map.MapObject<ADR_Address>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
