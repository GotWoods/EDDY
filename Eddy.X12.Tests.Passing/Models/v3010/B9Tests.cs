using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B9*pAN*7S*Hg7njj*13867*1*h*ISL7IK*7G";

		var expected = new B9_BeginningSegmentForRepetitivePatternMaintenance()
		{
			TransactionSetIdentifierCode = "pAN",
			StandardCarrierAlphaCode = "7S",
			StandardPointLocationCode = "Hg7njj",
			RepetitivePatternNumber = 13867,
			ReferencedPatternIdentifier = "1",
			PatternFunctionCode = "h",
			EffectiveDate = "ISL7IK",
			ShipmentMethodOfPayment = "7G",
		};

		var actual = Map.MapObject<B9_BeginningSegmentForRepetitivePatternMaintenance>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7S", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B9_BeginningSegmentForRepetitivePatternMaintenance();
		subject.StandardPointLocationCode = "Hg7njj";
		subject.PatternFunctionCode = "h";
		subject.EffectiveDate = "ISL7IK";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hg7njj", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new B9_BeginningSegmentForRepetitivePatternMaintenance();
		subject.StandardCarrierAlphaCode = "7S";
		subject.PatternFunctionCode = "h";
		subject.EffectiveDate = "ISL7IK";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredPatternFunctionCode(string patternFunctionCode, bool isValidExpected)
	{
		var subject = new B9_BeginningSegmentForRepetitivePatternMaintenance();
		subject.StandardCarrierAlphaCode = "7S";
		subject.StandardPointLocationCode = "Hg7njj";
		subject.EffectiveDate = "ISL7IK";
		subject.PatternFunctionCode = patternFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ISL7IK", true)]
	public void Validation_RequiredEffectiveDate(string effectiveDate, bool isValidExpected)
	{
		var subject = new B9_BeginningSegmentForRepetitivePatternMaintenance();
		subject.StandardCarrierAlphaCode = "7S";
		subject.StandardPointLocationCode = "Hg7njj";
		subject.PatternFunctionCode = "h";
		subject.EffectiveDate = effectiveDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
