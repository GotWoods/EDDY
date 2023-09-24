using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class S8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S8*5*ys*625*d*9*kCtN6*X4*c*n*x2";

		var expected = new S8_StopOff()
		{
			StopSequenceNumber = 5,
			StopReasonCode = "ys",
			StopOffWeight = 625,
			WeightQualifier = "d",
			LadingQuantity = 9,
			PackagingCode = "kCtN6",
			StopReasonDescription = "X4",
			Name = "c",
			IdentificationCodeQualifier = "n",
			IdentificationCode = "x2",
		};

		var actual = Map.MapObject<S8_StopOff>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredStopSequenceNumber(int stopSequenceNumber, bool isValidExpected)
	{
		var subject = new S8_StopOff();
		subject.StopReasonCode = "ys";
		subject.StopOffWeight = 625;
		subject.WeightQualifier = "d";
		if (stopSequenceNumber > 0)
			subject.StopSequenceNumber = stopSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ys", true)]
	public void Validation_RequiredStopReasonCode(string stopReasonCode, bool isValidExpected)
	{
		var subject = new S8_StopOff();
		subject.StopSequenceNumber = 5;
		subject.StopOffWeight = 625;
		subject.WeightQualifier = "d";
		subject.StopReasonCode = stopReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(625, true)]
	public void Validation_RequiredStopOffWeight(int stopOffWeight, bool isValidExpected)
	{
		var subject = new S8_StopOff();
		subject.StopSequenceNumber = 5;
		subject.StopReasonCode = "ys";
		subject.WeightQualifier = "d";
		if (stopOffWeight > 0)
			subject.StopOffWeight = stopOffWeight;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new S8_StopOff();
		subject.StopSequenceNumber = 5;
		subject.StopReasonCode = "ys";
		subject.StopOffWeight = 625;
		subject.WeightQualifier = weightQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
