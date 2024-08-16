using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class UNETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UNE+p+r";

		var expected = new UNE_FunctionalGroupTrailer()
		{
			NumberOfMessages = "p",
			FunctionalGroupReferenceNumber = "r",
		};

		var actual = Map.MapObject<UNE_FunctionalGroupTrailer>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredNumberOfMessages(string numberOfMessages, bool isValidExpected)
	{
		var subject = new UNE_FunctionalGroupTrailer();
		//Required fields
		subject.FunctionalGroupReferenceNumber = "r";
		//Test Parameters
		subject.NumberOfMessages = numberOfMessages;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredFunctionalGroupReferenceNumber(string functionalGroupReferenceNumber, bool isValidExpected)
	{
		var subject = new UNE_FunctionalGroupTrailer();
		//Required fields
		subject.NumberOfMessages = "p";
		//Test Parameters
		subject.FunctionalGroupReferenceNumber = functionalGroupReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
