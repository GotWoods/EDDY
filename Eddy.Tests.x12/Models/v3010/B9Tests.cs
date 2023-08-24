using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B9*KZd*Dk*C1Zh2s*76499*k*r*WAPrw3*RX";

		var expected = new B9_BeginningSegmentForRepetitivePatternMaintenance()
		{
			TransactionSetIdentifierCode = "KZd",
			StandardCarrierAlphaCode = "Dk",
			StandardPointLocationCode = "C1Zh2s",
			RepetitivePatternNumber = 76499,
			ReferencedPatternIdentifier = "k",
			PatternFunctionCode = "r",
			EffectiveDate = "WAPrw3",
			ShipmentMethodOfPayment = "RX",
		};

		var actual = Map.MapObject<B9_BeginningSegmentForRepetitivePatternMaintenance>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dk", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new B9_BeginningSegmentForRepetitivePatternMaintenance();
		subject.StandardPointLocationCode = "C1Zh2s";
		subject.PatternFunctionCode = "r";
		subject.EffectiveDate = "WAPrw3";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C1Zh2s", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new B9_BeginningSegmentForRepetitivePatternMaintenance();
		subject.StandardCarrierAlphaCode = "Dk";
		subject.PatternFunctionCode = "r";
		subject.EffectiveDate = "WAPrw3";
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredPatternFunctionCode(string patternFunctionCode, bool isValidExpected)
	{
		var subject = new B9_BeginningSegmentForRepetitivePatternMaintenance();
		subject.StandardCarrierAlphaCode = "Dk";
		subject.StandardPointLocationCode = "C1Zh2s";
		subject.EffectiveDate = "WAPrw3";
		subject.PatternFunctionCode = patternFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WAPrw3", true)]
	public void Validation_RequiredEffectiveDate(string effectiveDate, bool isValidExpected)
	{
		var subject = new B9_BeginningSegmentForRepetitivePatternMaintenance();
		subject.StandardCarrierAlphaCode = "Dk";
		subject.StandardPointLocationCode = "C1Zh2s";
		subject.PatternFunctionCode = "r";
		subject.EffectiveDate = effectiveDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
