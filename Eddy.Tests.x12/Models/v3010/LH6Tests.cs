using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class LH6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH6*V*z*3";

		var expected = new LH6_HazardousCertification()
		{
			Name = "V",
			HazardousCertificationCode = "z",
			HazardousCertificationDeclaration = "3",
		};

		var actual = Map.MapObject<LH6_HazardousCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
