using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MCZTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MCZ*Zc*D1OHqNx4";

		var expected = new MCZ_MarineCatchZone()
		{
			MarineCatchZone = "Zc",
			Date = "D1OHqNx4",
		};

		var actual = Map.MapObject<MCZ_MarineCatchZone>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zc", true)]
	public void Validation_RequiredMarineCatchZone(string marineCatchZone, bool isValidExpected)
	{
		var subject = new MCZ_MarineCatchZone();
		subject.MarineCatchZone = marineCatchZone;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
