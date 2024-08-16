using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00B;
using Eddy.Edifact.Models.D00B.Composites;

namespace Eddy.Edifact.Tests.Models.D00B;

public class QTITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "QTI+";

		var expected = new QTI_Quantity()
		{
			QuantityDetails = null,
		};

		var actual = Map.MapObject<QTI_Quantity>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredQuantityDetails(string quantityDetails, bool isValidExpected)
	{
		var subject = new QTI_Quantity();
		//Required fields
		//Test Parameters
		if (quantityDetails != "") 
			subject.QuantityDetails = new E035_QuantityDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
