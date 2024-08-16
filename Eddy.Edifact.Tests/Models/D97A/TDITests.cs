using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class TDITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "TDI+++5+2";

		var expected = new TDI_TravellerDocumentInformation()
		{
			DocumentInformation = null,
			ValidityDates = null,
			Surname = "5",
			GivenName = "2",
		};

		var actual = Map.MapObject<TDI_TravellerDocumentInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDocumentInformation(string documentInformation, bool isValidExpected)
	{
		var subject = new TDI_TravellerDocumentInformation();
		//Required fields
		//Test Parameters
		if (documentInformation != "") 
			subject.DocumentInformation = new E968_DocumentInformation();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
