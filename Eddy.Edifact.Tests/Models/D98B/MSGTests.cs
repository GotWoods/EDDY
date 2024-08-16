using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98B;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Tests.Models.D98B;

public class MSGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MSG++y+J+";

		var expected = new MSG_MessageTypeIdentification()
		{
			MessageIdentifier = null,
			ClassDesignatorCoded = "y",
			MaintenanceOperationCoded = "J",
			Relationship = null,
		};

		var actual = Map.MapObject<MSG_MessageTypeIdentification>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredMessageIdentifier(string messageIdentifier, bool isValidExpected)
	{
		var subject = new MSG_MessageTypeIdentification();
		//Required fields
		//Test Parameters
		if (messageIdentifier != "") 
			subject.MessageIdentifier = new C709_MessageIdentifier();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
