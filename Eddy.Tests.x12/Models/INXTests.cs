using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class INXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "INX*p*";

		var expected = new INX_IndexDetail()
		{
			IndexQualifier = "p",
			IndexIdentification = null,
		};

		var actual = Map.MapObject<INX_IndexDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredIndexQualifier(string indexQualifier, bool isValidExpected)
	{
		var subject = new INX_IndexDetail();
		subject.IndexIdentification = new C036_IndexIdentification();
		subject.IndexQualifier = indexQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AB", true)]
	public void Validation_RequiredIndexIdentification(string indexIdentification, bool isValidExpected)
	{
		var subject = new INX_IndexDetail();
		subject.IndexQualifier = "p";
		if (indexIdentification != "")
			subject.IndexIdentification = new C036_IndexIdentification() { ReferenceIdentification = indexIdentification }; 
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
