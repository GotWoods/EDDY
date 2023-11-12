using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class S8Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S8*5*Kl*268*o*6*pwE8O*UE*d*p*hN";

		var expected = new S8_StopOff()
		{
			StopSequenceNumber = 5,
			StopReasonCode = "Kl",
			StopOffWeight = 268,
			WeightQualifier = "o",
			LadingQuantity = 6,
			PackagingCode = "pwE8O",
			StopReasonDescription = "UE",
			Name = "d",
			IdentificationCodeQualifier = "p",
			IdentificationCode = "hN",
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
		subject.StopReasonCode = "Kl";
		subject.StopOffWeight = 268;
		subject.WeightQualifier = "o";
		if (stopSequenceNumber > 0)
			subject.StopSequenceNumber = stopSequenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "p";
			subject.IdentificationCode = "hN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Kl", true)]
	public void Validation_RequiredStopReasonCode(string stopReasonCode, bool isValidExpected)
	{
		var subject = new S8_StopOff();
		subject.StopSequenceNumber = 5;
		subject.StopOffWeight = 268;
		subject.WeightQualifier = "o";
		subject.StopReasonCode = stopReasonCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "p";
			subject.IdentificationCode = "hN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(268, true)]
	public void Validation_RequiredStopOffWeight(int stopOffWeight, bool isValidExpected)
	{
		var subject = new S8_StopOff();
		subject.StopSequenceNumber = 5;
		subject.StopReasonCode = "Kl";
		subject.WeightQualifier = "o";
		if (stopOffWeight > 0)
			subject.StopOffWeight = stopOffWeight;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "p";
			subject.IdentificationCode = "hN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredWeightQualifier(string weightQualifier, bool isValidExpected)
	{
		var subject = new S8_StopOff();
		subject.StopSequenceNumber = 5;
		subject.StopReasonCode = "Kl";
		subject.StopOffWeight = 268;
		subject.WeightQualifier = weightQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "p";
			subject.IdentificationCode = "hN";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "hN", true)]
	[InlineData("p", "", false)]
	[InlineData("", "hN", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new S8_StopOff();
		subject.StopSequenceNumber = 5;
		subject.StopReasonCode = "Kl";
		subject.StopOffWeight = 268;
		subject.WeightQualifier = "o";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
