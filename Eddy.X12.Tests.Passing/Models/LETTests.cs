using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LETTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LET*Vd*7a*5*L";

		var expected = new LET_LoadAndEquipmentType()
		{
			SurfaceLayerPositionCode = "Vd",
			EquipmentDescriptionCode = "7a",
			ShapeCode = "5",
			CarTypeCode = "L",
		};

		var actual = Map.MapObject<LET_LoadAndEquipmentType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("7a","L", true)]
	[InlineData("", "L", true)]
	[InlineData("7a", "", true)]
	public void Validation_AtLeastOneEquipmentDescriptionCode(string equipmentDescriptionCode, string carTypeCode, bool isValidExpected)
	{
		var subject = new LET_LoadAndEquipmentType();
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		subject.CarTypeCode = carTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
