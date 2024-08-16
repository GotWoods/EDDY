using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class QTYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "QTY+";

		var expected = new QTY_Quantity()
		{
			QuantityDetails = null,
		};

		var actual = Map.MapObject<QTY_Quantity>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredQuantityDetails(string quantityDetails, bool isValidExpected)
	{
		var subject = new QTY_Quantity();
		//Required fields
		//Test Parameters
		if (quantityDetails != "") 
			subject.QuantityDetails = new C186_QuantityDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
