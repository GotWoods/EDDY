using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class L10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L10*4*e*R";

		var expected = new L10_Weight()
		{
			Weight = 4,
			WeightQualifier = "e",
			WeightUnitQualifier = "R",
		};

		var actual = Map.MapObject<L10_Weight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new L10_Weight();
		subject.WeightQualifier = "e";
		if (weight > 0)
			subject.Weight = weight;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new L10_Weight();
		subject.Weight = 4;
		subject.WeightQualifier = weightQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
