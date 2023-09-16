using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TC1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TC1*w*7*B*QQE*1*C";

		var expected = new TC1_TariffCommodity()
		{
			TariffItemNumber = "w",
			LineNumber = 7,
			FreeFormDescription = "B",
			NoteReferenceCode = "QQE",
			LadingLineItemNumber = 1,
			CommodityCode = "C",
		};

		var actual = Map.MapObject<TC1_TariffCommodity>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredTariffItemNumber(string tariffItemNumber, bool isValidExpected)
	{
		var subject = new TC1_TariffCommodity();
		subject.LineNumber = 7;
		subject.FreeFormDescription = "B";
		subject.NoteReferenceCode = "QQE";
		subject.LadingLineItemNumber = 1;
		subject.TariffItemNumber = tariffItemNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredLineNumber(int lineNumber, bool isValidExpected)
	{
		var subject = new TC1_TariffCommodity();
		subject.TariffItemNumber = "w";
		subject.FreeFormDescription = "B";
		subject.NoteReferenceCode = "QQE";
		subject.LadingLineItemNumber = 1;
		if (lineNumber > 0)
			subject.LineNumber = lineNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredFreeFormDescription(string freeFormDescription, bool isValidExpected)
	{
		var subject = new TC1_TariffCommodity();
		subject.TariffItemNumber = "w";
		subject.LineNumber = 7;
		subject.NoteReferenceCode = "QQE";
		subject.LadingLineItemNumber = 1;
		subject.FreeFormDescription = freeFormDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QQE", true)]
	public void Validation_RequiredNoteReferenceCode(string noteReferenceCode, bool isValidExpected)
	{
		var subject = new TC1_TariffCommodity();
		subject.TariffItemNumber = "w";
		subject.LineNumber = 7;
		subject.FreeFormDescription = "B";
		subject.LadingLineItemNumber = 1;
		subject.NoteReferenceCode = noteReferenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredLadingLineItemNumber(int ladingLineItemNumber, bool isValidExpected)
	{
		var subject = new TC1_TariffCommodity();
		subject.TariffItemNumber = "w";
		subject.LineNumber = 7;
		subject.FreeFormDescription = "B";
		subject.NoteReferenceCode = "QQE";
		if (ladingLineItemNumber > 0)
			subject.LadingLineItemNumber = ladingLineItemNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
