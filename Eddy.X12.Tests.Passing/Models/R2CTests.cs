using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class R2CTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R2C*p*dK*3*7";

		var expected = new R2C_DivisionBasis()
		{
			DivisionTypeCode = "p",
			RateValueQualifier = "dK",
			FactorAmount = 3,
			AssignedNumber = 7,
		};

		var actual = Map.MapObject<R2C_DivisionBasis>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredDivisionTypeCode(string divisionTypeCode, bool isValidExpected)
	{
		var subject = new R2C_DivisionBasis();
		subject.DivisionTypeCode = divisionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
