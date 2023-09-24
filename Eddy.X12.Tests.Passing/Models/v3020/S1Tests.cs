using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class S1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S1*1*ho*4*tH*Yh*r";

		var expected = new S1_StopOffName()
		{
			StopSequenceNumber = 1,
			Name30CharacterFormat = "ho",
			IdentificationCodeQualifier = "4",
			IdentificationCode = "tH",
			StandardCarrierAlphaCode = "Yh",
			AccomplishCode = "r",
		};

		var actual = Map.MapObject<S1_StopOffName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredStopSequenceNumber(int stopSequenceNumber, bool isValidExpected)
	{
		var subject = new S1_StopOffName();
		subject.Name30CharacterFormat = "ho";
		subject.AccomplishCode = "r";
		if (stopSequenceNumber > 0)
			subject.StopSequenceNumber = stopSequenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "4";
			subject.IdentificationCode = "tH";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ho", true)]
	public void Validation_RequiredName30CharacterFormat(string name30CharacterFormat, bool isValidExpected)
	{
		var subject = new S1_StopOffName();
		subject.StopSequenceNumber = 1;
		subject.AccomplishCode = "r";
		subject.Name30CharacterFormat = name30CharacterFormat;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "4";
			subject.IdentificationCode = "tH";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "tH", true)]
	[InlineData("4", "", false)]
	[InlineData("", "tH", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new S1_StopOffName();
		subject.StopSequenceNumber = 1;
		subject.Name30CharacterFormat = "ho";
		subject.AccomplishCode = "r";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredAccomplishCode(string accomplishCode, bool isValidExpected)
	{
		var subject = new S1_StopOffName();
		subject.StopSequenceNumber = 1;
		subject.Name30CharacterFormat = "ho";
		subject.AccomplishCode = accomplishCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "4";
			subject.IdentificationCode = "tH";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
