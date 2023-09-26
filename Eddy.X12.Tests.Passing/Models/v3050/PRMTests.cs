using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class PRMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "PRM*y*n*Nw*xnyLh8*nujZEh*A*R8*Nh*Si*79*LauVSU*oe*v*M*7";

		var expected = new PRM_BasicTraceParameters()
		{
			CarTypeCode = "y",
			LoadEmptyStatusCode = "n",
			StandardCarrierAlphaCode = "Nw",
			StandardPointLocationCode = "xnyLh8",
			StandardPointLocationCode2 = "nujZEh",
			CommodityCode = "A",
			IdentificationCode = "R8",
			IdentificationCode2 = "Nh",
			StandardCarrierAlphaCode2 = "Si",
			StandardCarrierAlphaCode3 = "79",
			StandardPointLocationCode3 = "LauVSU",
			StandardCarrierAlphaCode4 = "oe",
			TransportationConditionCode = "v",
			AssociationOfAmericanRailroadsCarGradeCode = "M",
			IntermodalServiceCode = "7",
		};

		var actual = Map.MapObject<PRM_BasicTraceParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
