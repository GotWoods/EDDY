using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class INVTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INV*r*6*6";

		var expected = new INV_InvestmentVehicleSelection()
		{
			Description = "r",
			Percent = 6,
			MonetaryAmount = 6,
		};

		var actual = Map.MapObject<INV_InvestmentVehicleSelection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new INV_InvestmentVehicleSelection();
		//Required fields
		//Test Parameters
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(6, 6, false)]
	[InlineData(6, 0, true)]
	[InlineData(0, 6, true)]
	public void Validation_OnlyOneOfPercent(decimal percent, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new INV_InvestmentVehicleSelection();
		//Required fields
		subject.Description = "r";
		//Test Parameters
		if (percent > 0) 
			subject.Percent = percent;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
