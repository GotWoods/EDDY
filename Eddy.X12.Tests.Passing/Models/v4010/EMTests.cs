using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class EMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EM*R*6*b*9*wJ*h*S8IO963M";

		var expected = new EM_EquipmentCharacteristics()
		{
			WeightUnitCode = "R",
			Weight = 6,
			VolumeUnitQualifier = "b",
			Volume = 9,
			CountryCode = "wJ",
			ConstructionType = "h",
			Date = "S8IO963M",
		};

		var actual = Map.MapObject<EM_EquipmentCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "R", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "R", true)]
	public void Validation_ARequiresBWeight(decimal weight, string weightUnitCode, bool isValidExpected)
	{
		var subject = new EM_EquipmentCharacteristics();
		//Required fields
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.WeightUnitCode = weightUnitCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "b", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "b", true)]
	public void Validation_ARequiresBVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new EM_EquipmentCharacteristics();
		//Required fields
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
