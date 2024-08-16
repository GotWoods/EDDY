using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class UCFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UCF+9+++q+A+M++x+x";

		var expected = new UCF_GroupResponse()
		{
			GroupReferenceNumber = "9",
			ApplicationSenderIdentification = null,
			ApplicationRecipientIdentification = null,
			ActionCoded = "q",
			SyntaxErrorCoded = "A",
			ServiceSegmentTagCoded = "M",
			DataElementIdentification = null,
			SecurityReferenceNumber = "x",
			SecuritySegmentPosition = "x",
		};

		var actual = Map.MapObject<UCF_GroupResponse>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredGroupReferenceNumber(string groupReferenceNumber, bool isValidExpected)
	{
		var subject = new UCF_GroupResponse();
		//Required fields
		subject.ActionCoded = "q";
		//Test Parameters
		subject.GroupReferenceNumber = groupReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredActionCoded(string actionCoded, bool isValidExpected)
	{
		var subject = new UCF_GroupResponse();
		//Required fields
		subject.GroupReferenceNumber = "9";
		//Test Parameters
		subject.ActionCoded = actionCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
