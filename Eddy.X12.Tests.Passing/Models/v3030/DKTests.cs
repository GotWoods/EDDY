using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class DKTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DK*6k*t*B*2*A*U*FiVY8v*p6HNbm*Ym";

		var expected = new DK_DocketHeader()
		{
			StandardCarrierAlphaCode = "6k",
			DocketControlNumber = "t",
			DocketIdentification = "B",
			RevisionNumber = 2,
			ConveyanceCode = "A",
			DocketTypeCode = "U",
			Date = "FiVY8v",
			Date2 = "p6HNbm",
			ApplicationType = "Ym",
		};

		var actual = Map.MapObject<DK_DocketHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6k", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.DocketControlNumber = "t";
		subject.DocketIdentification = "B";
		subject.RevisionNumber = 2;
		subject.ConveyanceCode = "A";
		subject.DocketTypeCode = "U";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredDocketControlNumber(string docketControlNumber, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "6k";
		subject.DocketIdentification = "B";
		subject.RevisionNumber = 2;
		subject.ConveyanceCode = "A";
		subject.DocketTypeCode = "U";
		subject.DocketControlNumber = docketControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredDocketIdentification(string docketIdentification, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "6k";
		subject.DocketControlNumber = "t";
		subject.RevisionNumber = 2;
		subject.ConveyanceCode = "A";
		subject.DocketTypeCode = "U";
		subject.DocketIdentification = docketIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredRevisionNumber(int revisionNumber, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "6k";
		subject.DocketControlNumber = "t";
		subject.DocketIdentification = "B";
		subject.ConveyanceCode = "A";
		subject.DocketTypeCode = "U";
		if (revisionNumber > 0)
			subject.RevisionNumber = revisionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredConveyanceCode(string conveyanceCode, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "6k";
		subject.DocketControlNumber = "t";
		subject.DocketIdentification = "B";
		subject.RevisionNumber = 2;
		subject.DocketTypeCode = "U";
		subject.ConveyanceCode = conveyanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredDocketTypeCode(string docketTypeCode, bool isValidExpected)
	{
		var subject = new DK_DocketHeader();
		subject.StandardCarrierAlphaCode = "6k";
		subject.DocketControlNumber = "t";
		subject.DocketIdentification = "B";
		subject.RevisionNumber = 2;
		subject.ConveyanceCode = "A";
		subject.DocketTypeCode = docketTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
