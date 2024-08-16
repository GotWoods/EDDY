using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class PIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PIA+C+++++";

		var expected = new PIA_AdditionalProductId()
		{
			ProductIdFunctionQualifier = "C",
			ItemNumberIdentification = null,
			ItemNumberIdentification2 = null,
			ItemNumberIdentification3 = null,
			ItemNumberIdentification4 = null,
			ItemNumberIdentification5 = null,
		};

		var actual = Map.MapObject<PIA_AdditionalProductId>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredProductIdFunctionQualifier(string productIdFunctionQualifier, bool isValidExpected)
	{
		var subject = new PIA_AdditionalProductId();
		//Required fields
		subject.ItemNumberIdentification = new C212_ItemNumberIdentification();
		//Test Parameters
		subject.ProductIdFunctionQualifier = productIdFunctionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredItemNumberIdentification(string itemNumberIdentification, bool isValidExpected)
	{
		var subject = new PIA_AdditionalProductId();
		//Required fields
		subject.ProductIdFunctionQualifier = "C";
		//Test Parameters
		if (itemNumberIdentification != "") 
			subject.ItemNumberIdentification = new C212_ItemNumberIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
