using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DR*31cclvgg*si*T*j*8*s";

		var expected = new DR_DocketRange()
		{
			Date = "31cclvgg",
			StandardCarrierAlphaCode = "si",
			DocketControlNumber = "T",
			DocketIdentification = "j",
			RevisionNumber = 8,
			DocketIdentification2 = "s",
		};

		var actual = Map.MapObject<DR_DocketRange>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("31cclvgg", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		subject.StandardCarrierAlphaCode = "si";
		subject.DocketControlNumber = "T";
		subject.DocketIdentification = "j";
		subject.Date = date;

		subject.RevisionNumber = 1;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("si", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		subject.Date = "31cclvgg";
		subject.DocketControlNumber = "T";
		subject.DocketIdentification = "j";
        subject.RevisionNumber = 1;

        subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validatation_RequiredDocketControlNumber(string docketControlNumber, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		subject.Date = "31cclvgg";
		subject.StandardCarrierAlphaCode = "si";
		subject.DocketIdentification = "j";
        subject.RevisionNumber = 1;
        subject.DocketControlNumber = docketControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validatation_RequiredDocketIdentification(string docketIdentification, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		subject.Date = "31cclvgg";
		subject.StandardCarrierAlphaCode = "si";
		subject.DocketControlNumber = "T";
        subject.RevisionNumber = 1;
        subject.DocketIdentification = docketIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, false)]
	[InlineData("", 8, true)]
	[InlineData("s", 0, true)]
	public void Validation_AtLeastOneDocketIdentification2(string docketIdentification2, int revisionNumber, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		subject.Date = "31cclvgg";
		subject.StandardCarrierAlphaCode = "si";
		subject.DocketControlNumber = "T";
		subject.DocketIdentification = "j";
        subject.DocketIdentification2 = docketIdentification2;
		if (revisionNumber > 0)
		    subject.RevisionNumber = revisionNumber;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 8, true)]
	[InlineData("s", 0, true)]
	public void Validation_OnlyOneOfDocketIdentification2(string docketIdentification2, int revisionNumber, bool isValidExpected)
	{
		var subject = new DR_DocketRange();
		subject.Date = "31cclvgg";
		subject.StandardCarrierAlphaCode = "si";
		subject.DocketControlNumber = "T";
		subject.DocketIdentification = "j";
        subject.DocketIdentification2 = docketIdentification2;
		if (revisionNumber > 0)
		{
			subject.RevisionNumber = revisionNumber;
		}

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
