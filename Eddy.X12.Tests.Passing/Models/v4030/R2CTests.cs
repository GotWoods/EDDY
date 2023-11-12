using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class R2CTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R2C*h*xA*1*7";

		var expected = new R2C_DivisionBasis()
		{
			DivisionTypeCode = "h",
			RateValueQualifier = "xA",
			FactorAmount = 1,
			AssignedNumber = 7,
		};

		var actual = Map.MapObject<R2C_DivisionBasis>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredDivisionTypeCode(string divisionTypeCode, bool isValidExpected)
	{
		var subject = new R2C_DivisionBasis();
		//Required fields
		//Test Parameters
		subject.DivisionTypeCode = divisionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
