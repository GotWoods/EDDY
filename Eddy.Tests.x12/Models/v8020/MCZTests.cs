using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class MCZTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MCZ*78*wko0U20V";

		var expected = new MCZ_MarineCatchZone()
		{
			MarineCatchZone = "78",
			Date = "wko0U20V",
		};

		var actual = Map.MapObject<MCZ_MarineCatchZone>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("78", true)]
	public void Validation_RequiredMarineCatchZone(string marineCatchZone, bool isValidExpected)
	{
		var subject = new MCZ_MarineCatchZone();
		//Required fields
		//Test Parameters
		subject.MarineCatchZone = marineCatchZone;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
