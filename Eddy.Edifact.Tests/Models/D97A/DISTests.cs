using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class DISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DIS+";

		var expected = new DIS_DiscountInformation()
		{
			DiscountInformation = null,
		};

		var actual = Map.MapObject<DIS_DiscountInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDiscountInformation(string discountInformation, bool isValidExpected)
	{
		var subject = new DIS_DiscountInformation();
		//Required fields
		//Test Parameters
		if (discountInformation != "") 
			subject.DiscountInformation = new E998_DiscountInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
