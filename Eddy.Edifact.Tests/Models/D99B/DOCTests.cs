using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class DOCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DOC+++9+a+T";

		var expected = new DOC_DocumentMessageDetails()
		{
			DocumentMessageName = null,
			DocumentMessageDetails = null,
			CommunicationMediumTypeCode = "9",
			NumberOfCopiesOfDocumentRequired = "a",
			NumberOfOriginalsOfDocumentRequired = "T",
		};

		var actual = Map.MapObject<DOC_DocumentMessageDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDocumentMessageName(string documentMessageName, bool isValidExpected)
	{
		var subject = new DOC_DocumentMessageDetails();
		//Required fields
		//Test Parameters
		if (documentMessageName != "") 
			subject.DocumentMessageName = new C002_DocumentMessageName();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
