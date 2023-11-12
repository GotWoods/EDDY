using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v7060;
using Eddy.x12.Models.v7060.Composites;

namespace Eddy.x12.Tests.Models.v7060.Composites;

public class C067Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "4*c*z*8*4*V*8*W*U*7*H*M";

		var expected = new C067_CompositeProductWeightBasis()
		{
			UnitWeight = 4,
			WeightQualifier = "c",
			WeightUnitCode = "z",
			UnitWeight2 = 8,
			WeightQualifier2 = "4",
			WeightUnitCode2 = "V",
			UnitWeight3 = 8,
			WeightQualifier3 = "W",
			WeightUnitCode3 = "U",
			UnitWeight4 = 7,
			WeightQualifier4 = "H",
			WeightUnitCode4 = "M",
		};

		var actual = Map.MapObject<C067_CompositeProductWeightBasis>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredUnitWeight(decimal unitWeight, bool isValidExpected)
	{
		var subject = new C067_CompositeProductWeightBasis();
		//Required fields
		subject.WeightQualifier = "c";
		subject.WeightUnitCode = "z";
		//Test Parameters
		if (unitWeight > 0) 
			subject.UnitWeight = unitWeight;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new C067_CompositeProductWeightBasis();
		//Required fields
		subject.UnitWeight = 4;
		subject.WeightUnitCode = "z";
		//Test Parameters
		subject.WeightQualifier = weightQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredWeightUnitCode(string weightUnitCode, bool isValidExpected)
	{
		var subject = new C067_CompositeProductWeightBasis();
		//Required fields
		subject.UnitWeight = 4;
		subject.WeightQualifier = "c";
		//Test Parameters
		subject.WeightUnitCode = weightUnitCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
