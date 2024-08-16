using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class ADRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ADR+++T+F+j++";

		var expected = new ADR_Address()
		{
			AddressUsage = null,
			AddressDetails = null,
			CityName = "T",
			PostalIdentificationCode = "F",
			CountryNameCode = "j",
			CountrySubEntityDetails = null,
			LocationIdentification = null,
		};

		var actual = Map.MapObject<ADR_Address>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
