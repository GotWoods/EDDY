using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class B9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B9*Ulz*a7*WEGzUu*22152*c*j*YppJbv*AE";

		var expected = new B9_BeginningSegmentForRepetitivePatternMaintenance()
		{
			TransactionSetIdentifierCode = "Ulz",
			StandardCarrierAlphaCode = "a7",
			StandardPointLocationCode = "WEGzUu",
			RepetitivePatternNumber = 22152,
			ReferencedPatternIdentifier = "c",
			PatternFunctionCode = "j",
			Date = "YppJbv",
			ShipmentMethodOfPayment = "AE",
		};

		var actual = Map.MapObject<B9_BeginningSegmentForRepetitivePatternMaintenance>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a7", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B9_BeginningSegmentForRepetitivePatternMaintenance();
		subject.StandardPointLocationCode = "WEGzUu";
		subject.PatternFunctionCode = "j";
		subject.Date = "YppJbv";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WEGzUu", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new B9_BeginningSegmentForRepetitivePatternMaintenance();
		subject.StandardCarrierAlphaCode = "a7";
		subject.PatternFunctionCode = "j";
		subject.Date = "YppJbv";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(22152, "c", false)]
	[InlineData(22152, "", true)]
	[InlineData(0, "c", true)]
	public void Validation_OnlyOneOfRepetitivePatternNumber(int repetitivePatternNumber, string referencedPatternIdentifier, bool isValidExpected)
	{
		var subject = new B9_BeginningSegmentForRepetitivePatternMaintenance();
		subject.StandardCarrierAlphaCode = "a7";
		subject.StandardPointLocationCode = "WEGzUu";
		subject.PatternFunctionCode = "j";
		subject.Date = "YppJbv";
		if (repetitivePatternNumber > 0)
			subject.RepetitivePatternNumber = repetitivePatternNumber;
		subject.ReferencedPatternIdentifier = referencedPatternIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredPatternFunctionCode(string patternFunctionCode, bool isValidExpected)
	{
		var subject = new B9_BeginningSegmentForRepetitivePatternMaintenance();
		subject.StandardCarrierAlphaCode = "a7";
		subject.StandardPointLocationCode = "WEGzUu";
		subject.Date = "YppJbv";
		subject.PatternFunctionCode = patternFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YppJbv", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new B9_BeginningSegmentForRepetitivePatternMaintenance();
		subject.StandardCarrierAlphaCode = "a7";
		subject.StandardPointLocationCode = "WEGzUu";
		subject.PatternFunctionCode = "j";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
