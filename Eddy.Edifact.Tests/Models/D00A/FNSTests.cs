using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class FNSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FNS+++H+y";

		var expected = new FNS_FootnoteSet()
		{
			FootnoteSetIdentification = null,
			PartyIdentificationDetails = null,
			StatusDescriptionCode = "H",
			MaintenanceOperationCode = "y",
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
