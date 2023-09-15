using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class DKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DK*JS*c*E*2*L*6*RSywFpLt*71s4W2Rq*gb*t8";

		var expected = new DK_DocketHeader()
		{
			StandardCarrierAlphaCode = "JS",
			DocketControlNumber = "c",
			DocketIdentification = "E",
			RevisionNumber = 2,
			ConveyanceCode = "L",
			DocketTypeCode = "6",
			Date = "RSywFpLt",
			Date2 = "71s4W2Rq",
			ApplicationType = "gb",
			GroupTitle = "t8",
		};

		var actual = Map.MapObject<DK_DocketHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JS", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.DocketControlNumber = "c";
		subject.DocketIdentification = "E";
		subject.RevisionNumber = 2;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredDocketControlNumber(string docketControlNumber, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "JS";
		subject.DocketIdentification = "E";
		subject.RevisionNumber = 2;
		subject.DocketControlNumber = docketControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredDocketIdentification(string docketIdentification, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "JS";
		subject.DocketControlNumber = "c";
		subject.RevisionNumber = 2;
		subject.DocketIdentification = docketIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredRevisionNumber(int revisionNumber, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "JS";
		subject.DocketControlNumber = "c";
		subject.DocketIdentification = "E";
		if (revisionNumber > 0)
			subject.RevisionNumber = revisionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
