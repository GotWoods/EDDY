using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class E7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E7*Zt*or*th8SOe*YP*CD8tWX*OLDt";

		var expected = new E7_CarHandlingInformation()
		{
			CityName = "Zt",
			StateOrProvinceCode = "or",
			StandardPointLocationCode = "th8SOe",
			RailCarStatusOrderCode = "YP",
			EstimatedInterchangeDate = "CD8tWX",
			EstimatedInterchangeTime = "OLDt",
		};

		var actual = Map.MapObject<E7_CarHandlingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
