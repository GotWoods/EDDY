using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class USXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "USX+V+++R+++M++G+";

		var expected = new USX_SecurityReferences()
		{
			InterchangeControlReference = "V",
			InterchangeSender = null,
			InterchangeRecipient = null,
			GroupReferenceNumber = "R",
			ApplicationSenderIdentification = null,
			ApplicationRecipientIdentification = null,
			MessageReferenceNumber = "M",
			MessageIdentifier = null,
			PackageReferenceNumber = "G",
			SecurityDateAndTime = null,
		};

		var actual = Map.MapObject<USX_SecurityReferences>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredInterchangeControlReference(string interchangeControlReference, bool isValidExpected)
	{
		var subject = new USX_SecurityReferences();
		//Required fields
		//Test Parameters
		subject.InterchangeControlReference = interchangeControlReference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
