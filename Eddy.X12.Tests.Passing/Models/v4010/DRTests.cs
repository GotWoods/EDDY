using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class DRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DR*y7pMXhxV*ur*f*u*5*K";

		var expected = new DR_DocketRange()
		{
			Date = "y7pMXhxV",
			StandardCarrierAlphaCode = "ur",
			DocketControlNumber = "f",
			DocketIdentification = "u",
			RevisionNumber = 5,
			DocketIdentification2 = "K",
		};

		var actual = Map.MapObject<DR_DocketRange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y7pMXhxV", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		//Required fields
		subject.StandardCarrierAlphaCode = "ur";
		subject.DocketControlNumber = "f";
		subject.DocketIdentification = "u";
		//Test Parameters
		subject.Date = date;
		//At Least one
		subject.DocketIdentification2 = "K";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ur", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		//Required fields
		subject.Date = "y7pMXhxV";
		subject.DocketControlNumber = "f";
		subject.DocketIdentification = "u";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//At Least one
		subject.DocketIdentification2 = "K";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredDocketControlNumber(string docketControlNumber, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		//Required fields
		subject.Date = "y7pMXhxV";
		subject.StandardCarrierAlphaCode = "ur";
		subject.DocketIdentification = "u";
		//Test Parameters
		subject.DocketControlNumber = docketControlNumber;
		//At Least one
		subject.DocketIdentification2 = "K";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredDocketIdentification(string docketIdentification, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		//Required fields
		subject.Date = "y7pMXhxV";
		subject.StandardCarrierAlphaCode = "ur";
		subject.DocketControlNumber = "f";
		//Test Parameters
		subject.DocketIdentification = docketIdentification;
		//At Least one
		subject.DocketIdentification2 = "K";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("K", 0, true)]
	[InlineData("", 5, true)]
	public void Validation_AtLeastOneDocketIdentification2(string docketIdentification2, int revisionNumber, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		//Required fields
		subject.Date = "y7pMXhxV";
		subject.StandardCarrierAlphaCode = "ur";
		subject.DocketControlNumber = "f";
		subject.DocketIdentification = "u";
		//Test Parameters
		subject.DocketIdentification2 = docketIdentification2;
		if (revisionNumber > 0) 
			subject.RevisionNumber = revisionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("K", 5, false)]
	[InlineData("K", 0, true)]
	[InlineData("", 5, true)]
	public void Validation_OnlyOneOfDocketIdentification2(string docketIdentification2, int revisionNumber, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		//Required fields
		subject.Date = "y7pMXhxV";
		subject.StandardCarrierAlphaCode = "ur";
		subject.DocketControlNumber = "f";
		subject.DocketIdentification = "u";
		//Test Parameters
		subject.DocketIdentification2 = docketIdentification2;
		if (revisionNumber > 0) 
			subject.RevisionNumber = revisionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
