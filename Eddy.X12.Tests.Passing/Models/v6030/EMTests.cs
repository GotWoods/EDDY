using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class EMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EM*g*8*Y*3*6y*k*W84x8KTq";

		var expected = new EM_EquipmentCharacteristics()
		{
			WeightUnitCode = "g",
			Weight = 8,
			VolumeUnitQualifier = "Y",
			Volume = 3,
			CountryCode = "6y",
			ConstructionTypeCode = "k",
			Date = "W84x8KTq",
		};

		var actual = Map.MapObject<EM_EquipmentCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "g", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "g", true)]
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
	[InlineData(3, "Y", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "Y", true)]
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
