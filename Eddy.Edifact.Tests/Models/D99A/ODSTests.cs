using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A;

public class ODSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ODS+z+";

		var expected = new ODS_AdditionalProductDetails()
		{
			DataQualifier = "z",
			ProductDataInformation = null,
		};

		var actual = Map.MapObject<ODS_AdditionalProductDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredDataQualifier(string dataQualifier, bool isValidExpected)
	{
		var subject = new ODS_AdditionalProductDetails();
		//Required fields
		subject.ProductDataInformation = new E015_ProductDataInformation();
		//Test Parameters
		subject.DataQualifier = dataQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredProductDataInformation(string productDataInformation, bool isValidExpected)
	{
		var subject = new ODS_AdditionalProductDetails();
		//Required fields
		subject.DataQualifier = "z";
		//Test Parameters
		if (productDataInformation != "") 
			subject.ProductDataInformation = new E015_ProductDataInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
