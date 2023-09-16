using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class N5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "N5*9898*21*81*rpCT*B*1*Fw*K*ly";

		var expected = new N5_EquipmentOrdered()
		{
			EquipmentLength = 9898,
			WeightCapacity = 21,
			CubicCapacity = 81,
			CarTypeCode = "rpCT",
			MetricQualifier = "B",
			Height = 1,
			LadingPercentage = "Fw",
			LadingPercentQualifier = "K",
			EquipmentDescriptionCode = "ly",
		};

		var actual = Map.MapObject<N5_EquipmentOrdered>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Fw", "K", true)]
	[InlineData("Fw", "", false)]
	[InlineData("", "K", false)]
	public void Validation_AllAreRequiredLadingPercentage(string ladingPercentage, string ladingPercentQualifier, bool isValidExpected)
	{
		var subject = new N5_EquipmentOrdered();
		subject.LadingPercentage = ladingPercentage;
		subject.LadingPercentQualifier = ladingPercentQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
