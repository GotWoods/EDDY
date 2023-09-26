using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class R2CTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R2C*8*KG*5*9";

		var expected = new R2C_DivisionBasis()
		{
			DivisionTypeCode = "8",
			RateValueQualifier = "KG",
			FactorAmount = 5,
			AssignedNumber = 9,
		};

		var actual = Map.MapObject<R2C_DivisionBasis>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredDivisionTypeCode(string divisionTypeCode, bool isValidExpected)
	{
		var subject = new R2C_DivisionBasis();
		//Required fields
		//Test Parameters
		subject.DivisionTypeCode = divisionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
