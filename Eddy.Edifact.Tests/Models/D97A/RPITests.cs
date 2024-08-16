using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class RPITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "RPI+";

		var expected = new RPI_QuantityAndActionDetails()
		{
			QuantityAndActionDetails = null,
		};

		var actual = Map.MapObject<RPI_QuantityAndActionDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredQuantityAndActionDetails(string quantityAndActionDetails, bool isValidExpected)
	{
		var subject = new RPI_QuantityAndActionDetails();
		//Required fields
		//Test Parameters
		if (quantityAndActionDetails != "") 
			subject.QuantityAndActionDetails = new E958_QuantityAndActionDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
