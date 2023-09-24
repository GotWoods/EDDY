using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class N5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N5*5419*87*94*h*X*7*u2*v*Xx";

		var expected = new N5_EquipmentOrdered()
		{
			EquipmentLength = 5419,
			WeightCapacity = 87,
			CubicCapacity = 94,
			CarTypeCode = "h",
			MetricQualifier = "X",
			Height = 7,
			LadingPercentage = "u2",
			LadingPercentQualifier = "v",
			EquipmentDescriptionCode = "Xx",
		};

		var actual = Map.MapObject<N5_EquipmentOrdered>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("u2", "v", true)]
	[InlineData("", "v", false)]
	[InlineData("u2", "", false)]
	public void Validation_AllAreRequiredLadingPercentage(string ladingPercentage, string ladingPercentQualifier, bool isValidExpected)
	{
		var subject = new N5_EquipmentOrdered();
		subject.LadingPercentage = ladingPercentage;
		subject.LadingPercentQualifier = ladingPercentQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
