using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class N4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N4*MO*A4*Fgyz*Kb*o*N";

		var expected = new N4_GeographicLocation()
		{
			CityName = "MO",
			StateOrProvinceCode = "A4",
			PostalCode = "Fgyz",
			CountryCode = "Kb",
			LocationQualifier = "o",
			LocationIdentifier = "N",
		};

		var actual = Map.MapObject<N4_GeographicLocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
