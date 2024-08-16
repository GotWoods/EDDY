using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UNGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UNG+v++++5+s++p";

		var expected = new UNG_GroupHeader()
		{
			MessageGroupIdentification = "v",
			ApplicationSenderIdentification = null,
			ApplicationRecipientIdentification = null,
			DateAndTimeOfPreparation = null,
			GroupReferenceNumber = "5",
			ControllingAgencyCoded = "s",
			MessageVersion = null,
			ApplicationPassword = "p",
		};

		var actual = Map.MapObject<UNG_GroupHeader>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredGroupReferenceNumber(string groupReferenceNumber, bool isValidExpected)
	{
		var subject = new UNG_GroupHeader();
		//Required fields
		//Test Parameters
		subject.GroupReferenceNumber = groupReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
