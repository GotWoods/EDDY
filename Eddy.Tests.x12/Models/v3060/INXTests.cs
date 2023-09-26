using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class INXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INX*x*";

		var expected = new INX_IndexDetail()
		{
			IndexQualifier = "x",
			IndexIdentification = null,
		};

		var actual = Map.MapObject<INX_IndexDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredIndexQualifier(string indexQualifier, bool isValidExpected)
	{
		var subject = new INX_IndexDetail();
		//Required fields
		subject.IndexIdentification = new C036_IndexIdentification();
		//Test Parameters
		subject.IndexQualifier = indexQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredIndexIdentification(string indexIdentification, bool isValidExpected)
	{
		var subject = new INX_IndexDetail();
		//Required fields
		subject.IndexQualifier = "x";
		//Test Parameters
		if (indexIdentification != "") 
			subject.IndexIdentification = new C036_IndexIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
