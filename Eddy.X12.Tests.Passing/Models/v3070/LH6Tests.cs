using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class LH6Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH6*j*f*Q*b";

		var expected = new LH6_HazardousCertification()
		{
			Name = "j",
			HazardousCertificationCode = "f",
			HazardousCertificationDeclaration = "Q",
			HazardousCertificationDeclaration2 = "b",
		};

		var actual = Map.MapObject<LH6_HazardousCertification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "Q", true)]
	[InlineData("f", "", false)]
	[InlineData("", "Q", false)]
	public void Validation_AllAreRequiredHazardousCertificationCode(string hazardousCertificationCode, string hazardousCertificationDeclaration, bool isValidExpected)
	{
		var subject = new LH6_HazardousCertification();
		subject.HazardousCertificationCode = hazardousCertificationCode;
		subject.HazardousCertificationDeclaration = hazardousCertificationDeclaration;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
