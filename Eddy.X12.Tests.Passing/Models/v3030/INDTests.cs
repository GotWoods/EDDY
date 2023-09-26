using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class INDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IND*j8*eo*4ytu3*oC*gP*j";

		var expected = new IND_AdditionalIndividualDemographicInformation()
		{
			CountryCode = "j8",
			StateOrProvinceCode = "eo",
			CountyDesignator = "4ytu3",
			CityName = "oC",
			LanguageCode = "gP",
			YesNoConditionOrResponseCode = "j",
		};

		var actual = Map.MapObject<IND_AdditionalIndividualDemographicInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
