using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class FNTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FNT+++R+f";

		var expected = new FNT_Footnote()
		{
			FootnoteIdentification = null,
			PartyIdentificationDetails = null,
			StatusDescriptionCode = "R",
			MaintenanceOperationCoded = "f",
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
