using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class LETTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LET*RN*kV*r*Z";

		var expected = new LET_LoadAndEquipmentType()
		{
			SurfaceLayerPositionCode = "RN",
			EquipmentDescriptionCode = "kV",
			ShapeCode = "r",
			CarTypeCode = "Z",
		};

		var actual = Map.MapObject<LET_LoadAndEquipmentType>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("kV", "Z", true)]
	[InlineData("kV", "", true)]
	[InlineData("", "Z", true)]
	public void Validation_AtLeastOneEquipmentDescriptionCode(string equipmentDescriptionCode, string carTypeCode, bool isValidExpected)
	{
		var subject = new LET_LoadAndEquipmentType();
		//Required fields
		//Test Parameters
		subject.EquipmentDescriptionCode = equipmentDescriptionCode;
		subject.CarTypeCode = carTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
