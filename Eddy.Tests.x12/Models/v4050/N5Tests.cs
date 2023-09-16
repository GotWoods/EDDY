using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class N5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N5*7423*57*79*z*r*1*qu*B*6v";

		var expected = new N5_EquipmentOrdered()
		{
			EquipmentLength = 7423,
			WeightCapacity = 57,
			CubicCapacity = 79,
			CarTypeCode = "z",
			MetricQualifier = "r",
			Height = 1,
			LadingPercentage = "qu",
			LadingPercentQualifier = "B",
			EquipmentDescriptionCode = "6v",
		};

		var actual = Map.MapObject<N5_EquipmentOrdered>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qu", "B", true)]
	[InlineData("qu", "", false)]
	[InlineData("", "B", false)]
	public void Validation_AllAreRequiredLadingPercentage(string ladingPercentage, string ladingPercentQualifier, bool isValidExpected)
	{
		var subject = new N5_EquipmentOrdered();
		subject.LadingPercentage = ladingPercentage;
		subject.LadingPercentQualifier = ladingPercentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
