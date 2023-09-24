using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class SATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SA*gxC2YA*mq*BJ*ET*GAqRsZ";

		var expected = new SA_StatusAction()
		{
			Date = "gxC2YA",
			ActionCode = "mq",
			StandardCarrierAlphaCode = "BJ",
			Name30CharacterFormat = "ET",
			Date2 = "GAqRsZ",
		};

		var actual = Map.MapObject<SA_StatusAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gxC2YA", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SA_StatusAction();
		subject.ActionCode = "mq";
		subject.StandardCarrierAlphaCode = "BJ";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mq", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new SA_StatusAction();
		subject.Date = "gxC2YA";
		subject.StandardCarrierAlphaCode = "BJ";
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BJ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SA_StatusAction();
		subject.Date = "gxC2YA";
		subject.ActionCode = "mq";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
