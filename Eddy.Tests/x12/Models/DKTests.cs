using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DK*GK*h*r*4*j*E*45Kvtzxc*hqqHVxPJ*o4*bV";

		var expected = new DK_DocketHeader()
		{
			StandardCarrierAlphaCode = "GK",
			DocketControlNumber = "h",
			DocketIdentification = "r",
			RevisionNumber = 4,
			ConveyanceCode = "j",
			DocketTypeCode = "E",
			Date = "45Kvtzxc",
			Date2 = "hqqHVxPJ",
			ApplicationTypeCode = "o4",
			GroupTitle = "bV",
		};

		var actual = Map.MapObject<DK_DocketHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GK", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.DocketControlNumber = "h";
		subject.DocketIdentification = "r";
		subject.RevisionNumber = 4;
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validatation_RequiredDocketControlNumber(string docketControlNumber, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "GK";
		subject.DocketIdentification = "r";
		subject.RevisionNumber = 4;
		subject.DocketControlNumber = docketControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validatation_RequiredDocketIdentification(string docketIdentification, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "GK";
		subject.DocketControlNumber = "h";
		subject.RevisionNumber = 4;
		subject.DocketIdentification = docketIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validatation_RequiredRevisionNumber(int revisionNumber, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "GK";
		subject.DocketControlNumber = "h";
		subject.DocketIdentification = "r";
		if (revisionNumber > 0)
		subject.RevisionNumber = revisionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
