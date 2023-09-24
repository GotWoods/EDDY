using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SA*YMvTkI4t*0*SV*4*nq7eRkxq";

		var expected = new SA_StatusAction()
		{
			Date = "YMvTkI4t",
			ActionCode = "0",
			StandardCarrierAlphaCode = "SV",
			Name = "4",
			Date2 = "nq7eRkxq",
		};

		var actual = Map.MapObject<SA_StatusAction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YMvTkI4t", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new SA_StatusAction();
		subject.ActionCode = "0";
		subject.StandardCarrierAlphaCode = "SV";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new SA_StatusAction();
		subject.Date = "YMvTkI4t";
		subject.StandardCarrierAlphaCode = "SV";
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SV", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new SA_StatusAction();
		subject.Date = "YMvTkI4t";
		subject.ActionCode = "0";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
