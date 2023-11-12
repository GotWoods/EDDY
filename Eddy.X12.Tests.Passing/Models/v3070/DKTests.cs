using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class DKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DK*NJ*9*L*6*c*j*dPr86x*6USzul*dw*J5*88*85";

		var expected = new DK_DocketHeader()
		{
			StandardCarrierAlphaCode = "NJ",
			DocketControlNumber = "9",
			DocketIdentification = "L",
			RevisionNumber = 6,
			ConveyanceCode = "c",
			DocketTypeCode = "j",
			Date = "dPr86x",
			Date2 = "6USzul",
			ApplicationType = "dw",
			GroupTitle = "J5",
			Century = 88,
			Century2 = 85,
		};

		var actual = Map.MapObject<DK_DocketHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NJ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.DocketControlNumber = "9";
		subject.DocketIdentification = "L";
		subject.RevisionNumber = 6;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredDocketControlNumber(string docketControlNumber, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "NJ";
		subject.DocketIdentification = "L";
		subject.RevisionNumber = 6;
		subject.DocketControlNumber = docketControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredDocketIdentification(string docketIdentification, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "NJ";
		subject.DocketControlNumber = "9";
		subject.RevisionNumber = 6;
		subject.DocketIdentification = docketIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredRevisionNumber(int revisionNumber, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "NJ";
		subject.DocketControlNumber = "9";
		subject.DocketIdentification = "L";
		if (revisionNumber > 0)
			subject.RevisionNumber = revisionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(88, "dPr86x", true)]
	[InlineData(88, "", false)]
	[InlineData(0, "dPr86x", true)]
	public void Validation_ARequiresBCentury(int century, string date, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "NJ";
		subject.DocketControlNumber = "9";
		subject.DocketIdentification = "L";
		subject.RevisionNumber = 6;
		if (century > 0)
			subject.Century = century;
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(85, "6USzul", true)]
	[InlineData(85, "", false)]
	[InlineData(0, "6USzul", true)]
	public void Validation_ARequiresBCentury2(int century2, string date2, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "NJ";
		subject.DocketControlNumber = "9";
		subject.DocketIdentification = "L";
		subject.RevisionNumber = 6;
		if (century2 > 0)
			subject.Century2 = century2;
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
