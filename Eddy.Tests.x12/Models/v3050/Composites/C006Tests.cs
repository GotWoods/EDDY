using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3050;
using Eddy.x12.Models.v3050.Composites;

namespace Eddy.x12.Tests.Models.v3050.Composites;

public class C006Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "B*b*x*B*1";

		var expected = new C006_OralCavityDesignation()
		{
			OralCavityDesignationCode = "B",
			OralCavityDesignationCode2 = "b",
			OralCavityDesignationCode3 = "x",
			OralCavityDesignationCode4 = "B",
			OralCavityDesignationCode5 = "1",
		};

		var actual = Map.MapObject<C006_OralCavityDesignation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredOralCavityDesignationCode(string oralCavityDesignationCode, bool isValidExpected)
	{
		var subject = new C006_OralCavityDesignation();
		//Required fields
		//Test Parameters
		subject.OralCavityDesignationCode = oralCavityDesignationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
