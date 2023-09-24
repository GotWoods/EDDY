using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SA*tyN9xBEd*u*5i*6t*HMm231gD";

		var expected = new SA_StatusAction()
		{
			Date = "tyN9xBEd",
			ActionCode = "u",
			StandardCarrierAlphaCode = "5i",
			Name30CharacterFormat = "6t",
			Date2 = "HMm231gD",
		};

		var actual = Map.MapObject<SA_StatusAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tyN9xBEd", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SA_StatusAction();
		subject.ActionCode = "u";
		subject.StandardCarrierAlphaCode = "5i";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new SA_StatusAction();
		subject.Date = "tyN9xBEd";
		subject.StandardCarrierAlphaCode = "5i";
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5i", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SA_StatusAction();
		subject.Date = "tyN9xBEd";
		subject.ActionCode = "u";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
