using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class LH3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH3*z*n";

		var expected = new LH3_HazardousMaterialShippingName()
		{
			HazardousMaterialShippingName = "z",
			AdditionalHazardousInformation = "n",
		};

		var actual = Map.MapObject<LH3_HazardousMaterialShippingName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
