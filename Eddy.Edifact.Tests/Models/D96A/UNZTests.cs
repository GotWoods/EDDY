using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class UNZTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "UNZ+e+d";

		var expected = new UNZ_InterchangeTrailer()
		{
			InterchangeControlCount = "e",
			InterchangeControlReference = "d",
		};

		var actual = Map.MapObject<UNZ_InterchangeTrailer>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredInterchangeControlCount(string interchangeControlCount, bool isValidExpected)
	{
		var subject = new UNZ_InterchangeTrailer();
		//Required fields
		subject.InterchangeControlReference = "d";
		//Test Parameters
		subject.InterchangeControlCount = interchangeControlCount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredInterchangeControlReference(string interchangeControlReference, bool isValidExpected)
	{
		var subject = new UNZ_InterchangeTrailer();
		//Required fields
		subject.InterchangeControlCount = "e";
		//Test Parameters
		subject.InterchangeControlReference = interchangeControlReference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
