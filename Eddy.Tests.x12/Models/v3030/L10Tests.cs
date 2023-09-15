using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class L10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L10*9*M*n";

		var expected = new L10_Weight()
		{
			Weight = 9,
			WeightQualifier = "M",
			WeightUnitCode = "n",
		};

		var actual = Map.MapObject<L10_Weight>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredWeight(decimal weight, bool isValidExpected)
	{
		var subject = new L10_Weight();
		subject.WeightQualifier = "M";
		if (weight > 0)
			subject.Weight = weight;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new L10_Weight();
		subject.Weight = 9;
		subject.WeightQualifier = weightQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
