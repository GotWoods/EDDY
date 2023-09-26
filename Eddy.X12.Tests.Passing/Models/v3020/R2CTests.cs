using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class R2CTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R2C*z*1Z*8";

		var expected = new R2C_DivisionBasis()
		{
			DivisionTypeCode = "z",
			RateValueQualifier = "1Z",
			FactorAmount = 8,
		};

		var actual = Map.MapObject<R2C_DivisionBasis>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredDivisionTypeCode(string divisionTypeCode, bool isValidExpected)
	{
		var subject = new R2C_DivisionBasis();
		//Required fields
		//Test Parameters
		subject.DivisionTypeCode = divisionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
