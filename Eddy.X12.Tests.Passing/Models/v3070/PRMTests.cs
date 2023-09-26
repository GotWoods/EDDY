using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class PRMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRM*E*1*jH*ynLvZb*WlIuFx*K*2G*o3*fEaJ6j*wm*q*S*K";

		var expected = new PRM_BasicTraceParameters()
		{
			CarTypeCode = "E",
			LoadEmptyStatusCode = "1",
			StandardCarrierAlphaCode = "jH",
			StandardPointLocationCode = "ynLvZb",
			StandardPointLocationCode2 = "WlIuFx",
			CommodityCode = "K",
			StandardCarrierAlphaCode2 = "2G",
			StandardCarrierAlphaCode3 = "o3",
			StandardPointLocationCode3 = "fEaJ6j",
			StandardCarrierAlphaCode4 = "wm",
			TransportationConditionCode = "q",
			AssociationOfAmericanRailroadsCarGradeCode = "S",
			IntermodalServiceCode = "K",
		};

		var actual = Map.MapObject<PRM_BasicTraceParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
