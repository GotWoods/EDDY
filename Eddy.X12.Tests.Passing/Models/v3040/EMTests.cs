using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class EMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EM*7*7*z*2*om*K*WHyeZt";

		var expected = new EM_EquipmentCharacteristics()
		{
			WeightUnitCode = "7",
			Weight = 7,
			VolumeUnitQualifier = "z",
			Volume = 2,
			CountryCode = "om",
			ConstructionType = "K",
			Date = "WHyeZt",
		};

		var actual = Map.MapObject<EM_EquipmentCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "7", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "7", true)]
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
	[InlineData(2, "z", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "z", true)]
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
