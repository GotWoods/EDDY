using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3050;
using Eddy.x12.Models.v3050.Composites;

namespace Eddy.x12.Tests.Models.v3050.Composites;

public class C005Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "V*v*7*A*G";

		var expected = new C005_ToothSurface()
		{
			ToothSurfaceCode = "V",
			ToothSurfaceCode2 = "v",
			ToothSurfaceCode3 = "7",
			ToothSurfaceCode4 = "A",
			ToothSurfaceCode5 = "G",
		};

		var actual = Map.MapObject<C005_ToothSurface>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredToothSurfaceCode(string toothSurfaceCode, bool isValidExpected)
	{
		var subject = new C005_ToothSurface();
		//Required fields
		//Test Parameters
		subject.ToothSurfaceCode = toothSurfaceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
