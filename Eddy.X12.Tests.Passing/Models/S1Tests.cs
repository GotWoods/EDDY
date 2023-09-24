using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class S1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S1*9*B*D*P8*V6*9";

		var expected = new S1_StopOffName()
		{
			StopSequenceNumber = 9,
			Name = "B",
			IdentificationCodeQualifier = "D",
			IdentificationCode = "P8",
			StandardCarrierAlphaCode = "V6",
			AccomplishCode = "9",
		};

		var actual = Map.MapObject<S1_StopOffName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredStopSequenceNumber(int stopSequenceNumber, bool isValidExpected)
	{
		var subject = new S1_StopOffName();
		subject.Name = "B";
		subject.AccomplishCode = "9";
		if (stopSequenceNumber > 0)
		subject.StopSequenceNumber = stopSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new S1_StopOffName();
		subject.StopSequenceNumber = 9;
		subject.AccomplishCode = "9";
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("D", "P8", true)]
	[InlineData("", "P8", false)]
	[InlineData("D", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new S1_StopOffName();
		subject.StopSequenceNumber = 9;
		subject.Name = "B";
		subject.AccomplishCode = "9";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredAccomplishCode(string accomplishCode, bool isValidExpected)
	{
		var subject = new S1_StopOffName();
		subject.StopSequenceNumber = 9;
		subject.Name = "B";
		subject.AccomplishCode = accomplishCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
