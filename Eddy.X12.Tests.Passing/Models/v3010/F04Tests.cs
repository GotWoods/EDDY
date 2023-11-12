using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class F04Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F04*9*k*7*6*l*P*4*u*3*d";

		var expected = new F04_WeightVolumeLoss()
		{
			Weight = 9,
			WeightUnitQualifier = "k",
			WeightQualifier = "7",
			Weight2 = 6,
			WeightUnitQualifier2 = "l",
			WeightQualifier2 = "P",
			Volume = 4,
			VolumeUnitQualifier = "u",
			Volume2 = 3,
			VolumeUnitQualifier2 = "d",
		};

		var actual = Map.MapObject<F04_WeightVolumeLoss>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
