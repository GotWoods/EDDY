using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class DSITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "DSI+++E++h";

		var expected = new DSI_DataSetIdentification()
		{
			DataSetIdentification = null,
			PartyIdentificationDetails = null,
			StatusDescriptionCode = "E",
			SequenceInformation = null,
			RevisionNumber = "h",
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
