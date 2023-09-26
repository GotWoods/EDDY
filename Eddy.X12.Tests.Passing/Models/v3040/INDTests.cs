using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class INDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IND*sm*xx*L5j5d*p4*ns*r";

		var expected = new IND_AdditionalIndividualDemographicInformation()
		{
			CountryCode = "sm",
			StateOrProvinceCode = "xx",
			CountyDesignator = "L5j5d",
			CityName = "p4",
			LanguageCode = "ns",
			LanguageProficiencyIndicator = "r",
		};

		var actual = Map.MapObject<IND_AdditionalIndividualDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
