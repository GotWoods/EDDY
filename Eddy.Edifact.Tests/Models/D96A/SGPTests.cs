using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class SGPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "SGP++L";

		var expected = new SGP_SplitGoodsPlacement()
		{
			EquipmentIdentification = null,
			NumberOfPackages = "L",
		};

		var actual = Map.MapObject<SGP_SplitGoodsPlacement>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredEquipmentIdentification(string equipmentIdentification, bool isValidExpected)
	{
		var subject = new SGP_SplitGoodsPlacement();
		//Required fields
		//Test Parameters
		if (equipmentIdentification != "") 
			subject.EquipmentIdentification = new C237_EquipmentIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
