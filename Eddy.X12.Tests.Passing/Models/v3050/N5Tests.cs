using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class N5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N5*5652*11*34*c*i*9*Wb*y*Ie";

		var expected = new N5_EquipmentOrdered()
		{
			EquipmentLength = 5652,
			WeightCapacity = 11,
			CubicCapacity = 34,
			CarTypeCode = "c",
			MetricQualifier = "i",
			Height = 9,
			LadingPercentage = "Wb",
			LadingPercentQualifier = "y",
			EquipmentDescriptionCode = "Ie",
		};

		var actual = Map.MapObject<N5_EquipmentOrdered>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Wb", "y", true)]
	[InlineData("Wb", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredLadingPercentage(string ladingPercentage, string ladingPercentQualifier, bool isValidExpected)
	{
		var subject = new N5_EquipmentOrdered();
		subject.LadingPercentage = ladingPercentage;
		subject.LadingPercentQualifier = ladingPercentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
