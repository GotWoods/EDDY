using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C709Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "w:2:P:H:x:N:a";

		var expected = new C709_MessageIdentifier()
		{
			MessageTypeCode = "w",
			VersionIdentifier = "2",
			ReleaseIdentifier = "P",
			ControllingAgencyIdentifier = "H",
			MessageImplementationIdentificationCode = "x",
			RevisionIdentifier = "N",
			DocumentStatusCode = "a",
		};

		var actual = Map.MapComposite<C709_MessageIdentifier>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredMessageTypeCode(string messageTypeCode, bool isValidExpected)
	{
		var subject = new C709_MessageIdentifier();
		//Required fields
		//Test Parameters
		subject.MessageTypeCode = messageTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
