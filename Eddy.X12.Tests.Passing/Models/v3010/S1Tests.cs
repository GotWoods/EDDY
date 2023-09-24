using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class S1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S1*1*El*R*E5*Ax*F";

		var expected = new S1_StopOffName()
		{
			StopSequenceNumber = 1,
			Name30CharacterFormat = "El",
			IdentificationCodeQualifier = "R",
			IdentificationCode = "E5",
			StandardCarrierAlphaCode = "Ax",
			AccomplishCode = "F",
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
		subject.Name30CharacterFormat = "El";
		subject.AccomplishCode = "F";
		if (stopSequenceNumber > 0)
			subject.StopSequenceNumber = stopSequenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("El", true)]
	public void Validation_RequiredName30CharacterFormat(string name30CharacterFormat, bool isValidExpected)
	{
		var subject = new S1_StopOffName();
		subject.StopSequenceNumber = 1;
		subject.AccomplishCode = "F";
		subject.Name30CharacterFormat = name30CharacterFormat;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredAccomplishCode(string accomplishCode, bool isValidExpected)
	{
		var subject = new S1_StopOffName();
		subject.StopSequenceNumber = 1;
		subject.Name30CharacterFormat = "El";
		subject.AccomplishCode = accomplishCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
