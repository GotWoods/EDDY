using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class DGSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DGS+0++++G+E+0+n+++g+b+F";

		var expected = new DGS_DangerousGoods()
		{
			DangerousGoodsRegulationsCode = "0",
			HazardCode = null,
			UNDGInformation = null,
			DangerousGoodsShipmentFlashpoint = null,
			PackingGroupCoded = "G",
			EMSNumber = "E",
			MFAG = "0",
			TremCardNumber = "n",
			HazardIdentificationPlacardDetails = null,
			DangerousGoodsLabel = null,
			PackingInstructionCoded = "g",
			CategoryOfMeansOfTransportCoded = "b",
			PermissionForTransportCoded = "F",
		};

		var actual = Map.MapObject<DGS_DangerousGoods>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

}
