using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class PRMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRM*l*n*1F*oTEyJi*LUPk5Z*j*cU*DW*vTy3w7*Ly*v*A*4";

		var expected = new PRM_BasicTraceParameters()
		{
			CarTypeCode = "l",
			LoadEmptyStatusCode = "n",
			StandardCarrierAlphaCode = "1F",
			StandardPointLocationCode = "oTEyJi",
			StandardPointLocationCode2 = "LUPk5Z",
			CommodityCode = "j",
			StandardCarrierAlphaCode2 = "cU",
			StandardCarrierAlphaCode3 = "DW",
			StandardPointLocationCode3 = "vTy3w7",
			StandardCarrierAlphaCode4 = "Ly",
			TransportationConditionCode = "v",
			AssociationOfAmericanRailroadsCarGradeCode = "A",
			IntermodalServiceCode = "4",
		};

		var actual = Map.MapObject<PRM_BasicTraceParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
