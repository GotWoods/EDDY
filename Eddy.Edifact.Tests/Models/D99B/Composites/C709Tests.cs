using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C709Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "b:G:l:7:o:O:y";

		var expected = new C709_MessageIdentifier()
		{
			MessageTypeIdentifier = "b",
			Version = "G",
			Release = "l",
			ControlAgency = "7",
			AssociationAssignedIdentification = "o",
			RevisionNumber = "O",
			DocumentStatusCode = "y",
		};

		var actual = Map.MapComposite<C709_MessageIdentifier>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredMessageTypeIdentifier(string messageTypeIdentifier, bool isValidExpected)
	{
		var subject = new C709_MessageIdentifier();
		//Required fields
		//Test Parameters
		subject.MessageTypeIdentifier = messageTypeIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
