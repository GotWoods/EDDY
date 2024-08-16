using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class FNTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FNT+++f+N";

		var expected = new FNT_Footnote()
		{
			FootnoteIdentification = null,
			PartyIdentificationDetails = null,
			StatusDescriptionCode = "f",
			MaintenanceOperationCode = "N",
		};

		var actual = Map.MapObject<FNT_Footnote>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredFootnoteIdentification(string footnoteIdentification, bool isValidExpected)
	{
		var subject = new FNT_Footnote();
		//Required fields
		//Test Parameters
		if (footnoteIdentification != "") 
			subject.FootnoteIdentification = new C784_FootnoteIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
