using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TD4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD4*bx*u*2O*X";

		var expected = new TD4_CarrierDetailsSpecialHandlingHazardousMaterials()
		{
			SpecialHandlingCode = "bx",
			HazardousMaterialCodeQualifier = "u",
			HazardousMaterialClassCode = "2O",
			Description = "X",
		};

		var actual = Map.MapObject<TD4_CarrierDetailsSpecialHandlingHazardousMaterials>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
