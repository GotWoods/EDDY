using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class ODSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ODS+u+";

		var expected = new ODS_AdditionalProductDetails()
		{
			DataCodeQualifier = "u",
			ProductDataInformation = null,
		};

		var actual = Map.MapObject<ODS_AdditionalProductDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredDataCodeQualifier(string dataCodeQualifier, bool isValidExpected)
	{
		var subject = new ODS_AdditionalProductDetails();
		//Required fields
		subject.ProductDataInformation = new E015_ProductDataInformation();
		//Test Parameters
		subject.DataCodeQualifier = dataCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredProductDataInformation(string productDataInformation, bool isValidExpected)
	{
		var subject = new ODS_AdditionalProductDetails();
		//Required fields
		subject.DataCodeQualifier = "u";
		//Test Parameters
		if (productDataInformation != "") 
			subject.ProductDataInformation = new E015_ProductDataInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
