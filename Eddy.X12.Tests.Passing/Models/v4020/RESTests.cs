using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class RESTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RES*8*f*Y1*7*C*j*DfHTjMJW";

		var expected = new RES_RealEstateSalesPriceChange()
		{
			RealEstateSalesPriceChangeCode = "8",
			SourceOfFundsCode = "f",
			TypeOfFundsCode = "Y1",
			MonetaryAmount = 7,
			Description = "C",
			YesNoConditionOrResponseCode = "j",
			Date = "DfHTjMJW",
		};

		var actual = Map.MapObject<RES_RealEstateSalesPriceChange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredRealEstateSalesPriceChangeCode(string realEstateSalesPriceChangeCode, bool isValidExpected)
	{
		var subject = new RES_RealEstateSalesPriceChange();
		//Required fields
		//Test Parameters
		subject.RealEstateSalesPriceChangeCode = realEstateSalesPriceChangeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("j", "Y1", true)]
	[InlineData("j", "", false)]
	[InlineData("", "Y1", true)]
	public void Validation_ARequiresBYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, string typeOfFundsCode, bool isValidExpected)
	{
		var subject = new RES_RealEstateSalesPriceChange();
		//Required fields
		subject.RealEstateSalesPriceChangeCode = "8";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		subject.TypeOfFundsCode = typeOfFundsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
