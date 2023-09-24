using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class FGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FG*J*8*6";

		var expected = new FG_DocketGroupTerminator()
		{
			TerminatorTypeCode = "J",
			GroupControlNumber = 8,
			NumberOfTransactionSetsIncluded = 6,
		};

		var actual = Map.MapObject<FG_DocketGroupTerminator>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredTerminatorTypeCode(string terminatorTypeCode, bool isValidExpected)
	{
		var subject = new FG_DocketGroupTerminator();
		subject.GroupControlNumber = 8;
		subject.NumberOfTransactionSetsIncluded = 6;
		subject.TerminatorTypeCode = terminatorTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredGroupControlNumber(int groupControlNumber, bool isValidExpected)
	{
		var subject = new FG_DocketGroupTerminator();
		subject.TerminatorTypeCode = "J";
		subject.NumberOfTransactionSetsIncluded = 6;
		if (groupControlNumber > 0)
			subject.GroupControlNumber = groupControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredNumberOfTransactionSetsIncluded(int numberOfTransactionSetsIncluded, bool isValidExpected)
	{
		var subject = new FG_DocketGroupTerminator();
		subject.TerminatorTypeCode = "J";
		subject.GroupControlNumber = 8;
		if (numberOfTransactionSetsIncluded > 0)
			subject.NumberOfTransactionSetsIncluded = numberOfTransactionSetsIncluded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
