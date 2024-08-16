using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class MSGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "MSG++9+N";

		var expected = new MSG_MessageTypeIdentification()
		{
			MessageIdentifier = null,
			ClassDesignatorCoded = "9",
			MaintenanceOperationCoded = "N",
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
