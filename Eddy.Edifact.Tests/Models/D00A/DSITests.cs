using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class DSITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DSI+++f++v";

		var expected = new DSI_DataSetIdentification()
		{
			DataSetIdentification = null,
			PartyIdentificationDetails = null,
			StatusDescriptionCode = "f",
			SequenceInformation = null,
			RevisionIdentifier = "v",
		};

		var actual = Map.MapObject<DSI_DataSetIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDataSetIdentification(string dataSetIdentification, bool isValidExpected)
	{
		var subject = new DSI_DataSetIdentification();
		//Required fields
		//Test Parameters
		if (dataSetIdentification != "") 
			subject.DataSetIdentification = new C782_DataSetIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
