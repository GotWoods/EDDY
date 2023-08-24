using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class DKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DK*QQ*1*p*6*v*j*VeCFbe*80hvFq";

		var expected = new DK_DocketHeader()
		{
			StandardCarrierAlphaCode = "QQ",
			DocketControlNumber = "1",
			DocketIdentification = "p",
			RevisionNumber = 6,
			ConveyanceCode = "v",
			DocketTypeCode = "j",
			Date = "VeCFbe",
			Date2 = "80hvFq",
		};

		var actual = Map.MapObject<DK_DocketHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QQ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.DocketControlNumber = "1";
		subject.DocketIdentification = "p";
		subject.RevisionNumber = 6;
		subject.ConveyanceCode = "v";
		subject.DocketTypeCode = "j";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredDocketControlNumber(string docketControlNumber, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "QQ";
		subject.DocketIdentification = "p";
		subject.RevisionNumber = 6;
		subject.ConveyanceCode = "v";
		subject.DocketTypeCode = "j";
		subject.DocketControlNumber = docketControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredDocketIdentification(string docketIdentification, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "QQ";
		subject.DocketControlNumber = "1";
		subject.RevisionNumber = 6;
		subject.ConveyanceCode = "v";
		subject.DocketTypeCode = "j";
		subject.DocketIdentification = docketIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredRevisionNumber(int revisionNumber, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "QQ";
		subject.DocketControlNumber = "1";
		subject.DocketIdentification = "p";
		subject.ConveyanceCode = "v";
		subject.DocketTypeCode = "j";
		if (revisionNumber > 0)
		subject.RevisionNumber = revisionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredConveyanceCode(string conveyanceCode, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "QQ";
		subject.DocketControlNumber = "1";
		subject.DocketIdentification = "p";
		subject.RevisionNumber = 6;
		subject.DocketTypeCode = "j";
		subject.ConveyanceCode = conveyanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredDocketTypeCode(string docketTypeCode, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "QQ";
		subject.DocketControlNumber = "1";
		subject.DocketIdentification = "p";
		subject.RevisionNumber = 6;
		subject.ConveyanceCode = "v";
		subject.DocketTypeCode = docketTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
