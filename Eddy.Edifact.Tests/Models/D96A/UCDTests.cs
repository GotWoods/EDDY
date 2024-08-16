using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class UCDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UCD+7+";

		var expected = new UCD_DataElementErrorIndication()
		{
			SyntaxErrorCoded = "7",
			DataElementIdentification = null,
		};

		var actual = Map.MapObject<UCD_DataElementErrorIndication>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredSyntaxErrorCoded(string syntaxErrorCoded, bool isValidExpected)
	{
		var subject = new UCD_DataElementErrorIndication();
		//Required fields
		subject.DataElementIdentification = new S011_DataElementIdentification();
		//Test Parameters
		subject.SyntaxErrorCoded = syntaxErrorCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDataElementIdentification(string dataElementIdentification, bool isValidExpected)
	{
		var subject = new UCD_DataElementErrorIndication();
		//Required fields
		subject.SyntaxErrorCoded = "7";
		//Test Parameters
		if (dataElementIdentification != "") 
			subject.DataElementIdentification = new S011_DataElementIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
