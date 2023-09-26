using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class DRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DR*UMpL6T*5J*o*5*7*F";

		var expected = new DR_DocketRange()
		{
			Date = "UMpL6T",
			StandardCarrierAlphaCode = "5J",
			DocketControlNumber = "o",
			DocketIdentification = "5",
			RevisionNumber = 7,
			DocketIdentification2 = "F",
		};

		var actual = Map.MapObject<DR_DocketRange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UMpL6T", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		//Required fields
		subject.StandardCarrierAlphaCode = "5J";
		subject.DocketControlNumber = "o";
		subject.DocketIdentification = "5";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5J", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		//Required fields
		subject.Date = "UMpL6T";
		subject.DocketControlNumber = "o";
		subject.DocketIdentification = "5";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredDocketControlNumber(string docketControlNumber, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		//Required fields
		subject.Date = "UMpL6T";
		subject.StandardCarrierAlphaCode = "5J";
		subject.DocketIdentification = "5";
		//Test Parameters
		subject.DocketControlNumber = docketControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredDocketIdentification(string docketIdentification, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		//Required fields
		subject.Date = "UMpL6T";
		subject.StandardCarrierAlphaCode = "5J";
		subject.DocketControlNumber = "o";
		//Test Parameters
		subject.DocketIdentification = docketIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
