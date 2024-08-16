using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B.Composites;

public class C709Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "9:M:m:6:F:J:h";

		var expected = new C709_MessageIdentifier()
		{
			MessageTypeIdentifier = "9",
			Version = "M",
			Release = "m",
			ControlAgency = "6",
			AssociationAssignedIdentification = "F",
			RevisionNumber = "J",
			DocumentMessageStatusCoded = "h",
		};

		var actual = Map.MapComposite<C709_MessageIdentifier>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredMessageTypeIdentifier(string messageTypeIdentifier, bool isValidExpected)
	{
		var subject = new C709_MessageIdentifier();
		//Required fields
		//Test Parameters
		subject.MessageTypeIdentifier = messageTypeIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
