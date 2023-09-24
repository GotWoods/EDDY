using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RESTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RES*R*A*FC*1*W*f*hGnsJIoS";

		var expected = new RES_RealEstateSalesPriceChange()
		{
			RealEstateSalesPriceChangeCode = "R",
			SourceOfFundsCode = "A",
			TypeOfFundsCode = "FC",
			MonetaryAmount = 1,
			Description = "W",
			YesNoConditionOrResponseCode = "f",
			Date = "hGnsJIoS",
		};

		var actual = Map.MapObject<RES_RealEstateSalesPriceChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredRealEstateSalesPriceChangeCode(string realEstateSalesPriceChangeCode, bool isValidExpected)
	{
		var subject = new RES_RealEstateSalesPriceChange();
		subject.RealEstateSalesPriceChangeCode = realEstateSalesPriceChangeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "FC", true)]
	[InlineData("f", "", false)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string typeOfFundsCode, bool isValidExpected)
	{
		var subject = new RES_RealEstateSalesPriceChange();
		subject.RealEstateSalesPriceChangeCode = "R";
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		subject.TypeOfFundsCode = typeOfFundsCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
