using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class NM1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "NM1*gX*H*K*P*P*z*g*S3";

		var expected = new NM1_IndividualName()
		{
			NameTypeCode = "gX",
			NameLast = "H",
			NameFirst = "K",
			NameMiddle = "P",
			NamePrefix = "P",
			NameSuffix = "z",
			IdentificationCodeQualifier = "g",
			IdentificationCode = "S3",
		};

		var actual = Map.MapObject<NM1_IndividualName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gX", true)]
	public void Validation_RequiredNameTypeCode(string nameTypeCode, bool isValidExpected)
	{
		var subject = new NM1_IndividualName();
		//Required fields
		subject.NameLast = "H";
		subject.NameFirst = "K";
		//Test Parameters
		subject.NameTypeCode = nameTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredNameLast(string nameLast, bool isValidExpected)
	{
		var subject = new NM1_IndividualName();
		//Required fields
		subject.NameTypeCode = "gX";
		subject.NameFirst = "K";
		//Test Parameters
		subject.NameLast = nameLast;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredNameFirst(string nameFirst, bool isValidExpected)
	{
		var subject = new NM1_IndividualName();
		//Required fields
		subject.NameTypeCode = "gX";
		subject.NameLast = "H";
		//Test Parameters
		subject.NameFirst = nameFirst;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
