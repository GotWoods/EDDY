using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class DRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DR*aKT4vF*8l*W*7*8*R*56";

		var expected = new DR_DocketRange()
		{
			Date = "aKT4vF",
			StandardCarrierAlphaCode = "8l",
			DocketControlNumber = "W",
			DocketIdentification = "7",
			RevisionNumber = 8,
			DocketIdentification2 = "R",
			Century = 56,
		};

		var actual = Map.MapObject<DR_DocketRange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("aKT4vF", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		//Required fields
		subject.StandardCarrierAlphaCode = "8l";
		subject.DocketControlNumber = "W";
		subject.DocketIdentification = "7";
		//Test Parameters
		subject.Date = date;
		//At Least one
		subject.DocketIdentification2 = "R";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8l", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		//Required fields
		subject.Date = "aKT4vF";
		subject.DocketControlNumber = "W";
		subject.DocketIdentification = "7";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//At Least one
		subject.DocketIdentification2 = "R";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredDocketControlNumber(string docketControlNumber, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		//Required fields
		subject.Date = "aKT4vF";
		subject.StandardCarrierAlphaCode = "8l";
		subject.DocketIdentification = "7";
		//Test Parameters
		subject.DocketControlNumber = docketControlNumber;
		//At Least one
		subject.DocketIdentification2 = "R";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredDocketIdentification(string docketIdentification, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		//Required fields
		subject.Date = "aKT4vF";
		subject.StandardCarrierAlphaCode = "8l";
		subject.DocketControlNumber = "W";
		//Test Parameters
		subject.DocketIdentification = docketIdentification;
		//At Least one
		subject.DocketIdentification2 = "R";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("R", 8, true)]
	[InlineData("R", 0, true)]
	public void Validation_AtLeastOneDocketIdentification2(string docketIdentification2, int revisionNumber, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		//Required fields
		subject.Date = "aKT4vF";
		subject.StandardCarrierAlphaCode = "8l";
		subject.DocketControlNumber = "W";
		subject.DocketIdentification = "7";
		//Test Parameters
		subject.DocketIdentification2 = docketIdentification2;
		
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("R", 8, false)]
	[InlineData("R", 0, true)]
	[InlineData("", 8, true)]
	public void Validation_OnlyOneOfDocketIdentification2(string docketIdentification2, int revisionNumber, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		//Required fields
		subject.Date = "aKT4vF";
		subject.StandardCarrierAlphaCode = "8l";
		subject.DocketControlNumber = "W";
		subject.DocketIdentification = "7";
		//Test Parameters
		subject.DocketIdentification2 = docketIdentification2;
		if (revisionNumber > 0) 
			subject.RevisionNumber = revisionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
