using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class DKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DK*zs*c*r*7*K*V*agnm0d*WrhFJ6";

		var expected = new DK_DocketHeader()
		{
			StandardCarrierAlphaCode = "zs",
			DocketControlNumber = "c",
			DocketIdentification = "r",
			RevisionNumber = 7,
			ConveyanceCode = "K",
			DocketTypeCode = "V",
			Date = "agnm0d",
			Date2 = "WrhFJ6",
		};

		var actual = Map.MapObject<DK_DocketHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zs", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.DocketControlNumber = "c";
		subject.DocketIdentification = "r";
		subject.RevisionNumber = 7;
		subject.ConveyanceCode = "K";
		subject.DocketTypeCode = "V";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredDocketControlNumber(string docketControlNumber, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "zs";
		subject.DocketIdentification = "r";
		subject.RevisionNumber = 7;
		subject.ConveyanceCode = "K";
		subject.DocketTypeCode = "V";
		subject.DocketControlNumber = docketControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredDocketIdentification(string docketIdentification, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "zs";
		subject.DocketControlNumber = "c";
		subject.RevisionNumber = 7;
		subject.ConveyanceCode = "K";
		subject.DocketTypeCode = "V";
		subject.DocketIdentification = docketIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredRevisionNumber(int revisionNumber, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "zs";
		subject.DocketControlNumber = "c";
		subject.DocketIdentification = "r";
		subject.ConveyanceCode = "K";
		subject.DocketTypeCode = "V";
		if (revisionNumber > 0)
			subject.RevisionNumber = revisionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredConveyanceCode(string conveyanceCode, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "zs";
		subject.DocketControlNumber = "c";
		subject.DocketIdentification = "r";
		subject.RevisionNumber = 7;
		subject.DocketTypeCode = "V";
		subject.ConveyanceCode = conveyanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredDocketTypeCode(string docketTypeCode, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "zs";
		subject.DocketControlNumber = "c";
		subject.DocketIdentification = "r";
		subject.RevisionNumber = 7;
		subject.ConveyanceCode = "K";
		subject.DocketTypeCode = docketTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
