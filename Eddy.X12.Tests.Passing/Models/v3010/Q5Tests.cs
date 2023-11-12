using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class Q5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "Q5*y*k44NYx*kfJO*RC*Eog*Dk*rV*O4*n*2";

		var expected = new Q5_StatusDetails()
		{
			StatusCode = "y",
			StatusDate = "k44NYx",
			StatusTime = "kfJO",
			TimeCode = "RC",
			StatusReasonCode = "Eog",
			CityName = "Dk",
			StateOrProvinceCode = "rV",
			CountryCode = "O4",
			EquipmentInitial = "n",
			EquipmentNumber = "2",
		};

		var actual = Map.MapObject<Q5_StatusDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
