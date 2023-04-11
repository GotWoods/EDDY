using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class EMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "EM*I*3*u*9*ck*7*3QI6ltRR";

		var expected = new EM_EquipmentCharacteristics()
		{
			WeightUnitCode = "I",
			Weight = 3,
			VolumeUnitQualifier = "u",
			Volume = 9,
			CountryCode = "ck",
			ConstructionTypeCode = "7",
			Date = "3QI6ltRR",
		};

		var actual = Map.MapObject<EM_EquipmentCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "I", true)]
	[InlineData(3, "", false)]
	public void Validation_ARequiresBWeight(decimal weight, string weightUnitCode, bool isValidExpected)
	{
		var subject = new EM_EquipmentCharacteristics();
		if (weight > 0)
		subject.Weight = weight;
		subject.WeightUnitCode = weightUnitCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "u", true)]
	[InlineData(9, "", false)]
	public void Validation_ARequiresBVolume(decimal volume, string volumeUnitQualifier, bool isValidExpected)
	{
		var subject = new EM_EquipmentCharacteristics();
		if (volume > 0)
		subject.Volume = volume;
		subject.VolumeUnitQualifier = volumeUnitQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
