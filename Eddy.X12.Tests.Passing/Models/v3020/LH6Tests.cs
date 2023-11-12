using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class LH6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH6*y*W*3*U";

		var expected = new LH6_HazardousCertification()
		{
			Name = "y",
			HazardousCertificationCode = "W",
			HazardousCertificationDeclaration = "3",
			HazardousCertificationDeclaration2 = "U",
		};

		var actual = Map.MapObject<LH6_HazardousCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("W", "3", true)]
	[InlineData("W", "", false)]
	[InlineData("", "3", false)]
	public void Validation_AllAreRequiredHazardousCertificationCode(string hazardousCertificationCode, string hazardousCertificationDeclaration, bool isValidExpected)
	{
		var subject = new LH6_HazardousCertification();
		subject.HazardousCertificationCode = hazardousCertificationCode;
		subject.HazardousCertificationDeclaration = hazardousCertificationDeclaration;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
