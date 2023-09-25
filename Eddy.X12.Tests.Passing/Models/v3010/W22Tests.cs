using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W22Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W22*uHIBit*APhMNS";

		var expected = new W22_TransactionDateAndTime()
		{
			BeginningDate = "uHIBit",
			ThruDate = "APhMNS",
		};

		var actual = Map.MapObject<W22_TransactionDateAndTime>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uHIBit", true)]
	public void Validation_RequiredBeginningDate(string beginningDate, bool isValidExpected)
	{
		var subject = new W22_TransactionDateAndTime();
		//Required fields
		subject.ThruDate = "APhMNS";
		//Test Parameters
		subject.BeginningDate = beginningDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("APhMNS", true)]
	public void Validation_RequiredThruDate(string thruDate, bool isValidExpected)
	{
		var subject = new W22_TransactionDateAndTime();
		//Required fields
		subject.BeginningDate = "uHIBit";
		//Test Parameters
		subject.ThruDate = thruDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
