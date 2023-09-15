using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class DKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DK*sE*j*M*9*M*d*giy0CuES*MKBSAuBm*Q2*ne";

		var expected = new DK_DocketHeader()
		{
			StandardCarrierAlphaCode = "sE",
			DocketControlNumber = "j",
			DocketIdentification = "M",
			RevisionNumber = 9,
			ConveyanceCode = "M",
			DocketTypeCode = "d",
			Date = "giy0CuES",
			Date2 = "MKBSAuBm",
			ApplicationTypeCode = "Q2",
			GroupTitle = "ne",
		};

		var actual = Map.MapObject<DK_DocketHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sE", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.DocketControlNumber = "j";
		subject.DocketIdentification = "M";
		subject.RevisionNumber = 9;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredDocketControlNumber(string docketControlNumber, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "sE";
		subject.DocketIdentification = "M";
		subject.RevisionNumber = 9;
		subject.DocketControlNumber = docketControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredDocketIdentification(string docketIdentification, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "sE";
		subject.DocketControlNumber = "j";
		subject.RevisionNumber = 9;
		subject.DocketIdentification = docketIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredRevisionNumber(int revisionNumber, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "sE";
		subject.DocketControlNumber = "j";
		subject.DocketIdentification = "M";
		if (revisionNumber > 0)
			subject.RevisionNumber = revisionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
