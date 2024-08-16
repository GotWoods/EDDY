using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class FNSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FNS+++9+t";

		var expected = new FNS_FootnoteSet()
		{
			FootnoteSetIdentification = null,
			PartyIdentificationDetails = null,
			StatusDescriptionCode = "9",
			MaintenanceOperationCoded = "t",
		};

		var actual = Map.MapObject<FNS_FootnoteSet>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredFootnoteSetIdentification(string footnoteSetIdentification, bool isValidExpected)
	{
		var subject = new FNS_FootnoteSet();
		//Required fields
		//Test Parameters
		if (footnoteSetIdentification != "") 
			subject.FootnoteSetIdentification = new C783_FootnoteSetIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
