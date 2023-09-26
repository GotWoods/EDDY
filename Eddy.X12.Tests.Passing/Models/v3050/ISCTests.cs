using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class ISCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ISC*oj*XWXnj1*VjO*sN*f*VfOu*7*Zc*P*l";

		var expected = new ISC_InterlineServiceCommitmentDetail()
		{
			StandardCarrierAlphaCode = "oj",
			StandardPointLocationCode = "XWXnj1",
			EventCode = "VjO",
			DateTimePeriodFormatQualifier = "sN",
			DateTimePeriod = "f",
			Time = "VfOu",
			NumberOfDays = 7,
			StandardCarrierAlphaCode2 = "Zc",
			InterchangeTrainIdentification = "P",
			BlockIdentification = "l",
		};

		var actual = Map.MapObject<ISC_InterlineServiceCommitmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oj", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardPointLocationCode = "XWXnj1";
		subject.EventCode = "VjO";
		subject.DateTimePeriodFormatQualifier = "sN";
		subject.DateTimePeriod = "f";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XWXnj1", true)]
	public void Validation_RequiredStandardPointLocationCode(string standardPointLocationCode, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "oj";
		subject.EventCode = "VjO";
		subject.DateTimePeriodFormatQualifier = "sN";
		subject.DateTimePeriod = "f";
		//Test Parameters
		subject.StandardPointLocationCode = standardPointLocationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VjO", true)]
	public void Validation_RequiredEventCode(string eventCode, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "oj";
		subject.StandardPointLocationCode = "XWXnj1";
		subject.DateTimePeriodFormatQualifier = "sN";
		subject.DateTimePeriod = "f";
		//Test Parameters
		subject.EventCode = eventCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("sN", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "oj";
		subject.StandardPointLocationCode = "XWXnj1";
		subject.EventCode = "VjO";
		subject.DateTimePeriod = "f";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new ISC_InterlineServiceCommitmentDetail();
		//Required fields
		subject.StandardCarrierAlphaCode = "oj";
		subject.StandardPointLocationCode = "XWXnj1";
		subject.EventCode = "VjO";
		subject.DateTimePeriodFormatQualifier = "sN";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
