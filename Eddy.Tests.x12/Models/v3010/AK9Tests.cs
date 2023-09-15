using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class AK9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AK9*6*9*4*2*W*J*c*5*s";

		var expected = new AK9_FunctionalGroupResponseTrailer()
		{
			FunctionalGroupAcknowledgeCode = "6",
			NumberOfTransactionSetsIncluded = 9,
			NumberOfReceivedTransactionSets = 4,
			NumberOfAcceptedTransactionSets = 2,
			FunctionalGroupSyntaxErrorCode = "W",
			FunctionalGroupSyntaxErrorCode2 = "J",
			FunctionalGroupSyntaxErrorCode3 = "c",
			FunctionalGroupSyntaxErrorCode4 = "5",
			FunctionalGroupSyntaxErrorCode5 = "s",
		};

		var actual = Map.MapObject<AK9_FunctionalGroupResponseTrailer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredFunctionalGroupAcknowledgeCode(string functionalGroupAcknowledgeCode, bool isValidExpected)
	{
		var subject = new AK9_FunctionalGroupResponseTrailer();
		subject.NumberOfTransactionSetsIncluded = 9;
		subject.NumberOfReceivedTransactionSets = 4;
		subject.NumberOfAcceptedTransactionSets = 2;
		subject.FunctionalGroupAcknowledgeCode = functionalGroupAcknowledgeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredNumberOfTransactionSetsIncluded(int numberOfTransactionSetsIncluded, bool isValidExpected)
	{
		var subject = new AK9_FunctionalGroupResponseTrailer();
		subject.FunctionalGroupAcknowledgeCode = "6";
		subject.NumberOfReceivedTransactionSets = 4;
		subject.NumberOfAcceptedTransactionSets = 2;
		if (numberOfTransactionSetsIncluded > 0)
			subject.NumberOfTransactionSetsIncluded = numberOfTransactionSetsIncluded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredNumberOfReceivedTransactionSets(int numberOfReceivedTransactionSets, bool isValidExpected)
	{
		var subject = new AK9_FunctionalGroupResponseTrailer();
		subject.FunctionalGroupAcknowledgeCode = "6";
		subject.NumberOfTransactionSetsIncluded = 9;
		subject.NumberOfAcceptedTransactionSets = 2;
		if (numberOfReceivedTransactionSets > 0)
			subject.NumberOfReceivedTransactionSets = numberOfReceivedTransactionSets;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredNumberOfAcceptedTransactionSets(int numberOfAcceptedTransactionSets, bool isValidExpected)
	{
		var subject = new AK9_FunctionalGroupResponseTrailer();
		subject.FunctionalGroupAcknowledgeCode = "6";
		subject.NumberOfTransactionSetsIncluded = 9;
		subject.NumberOfReceivedTransactionSets = 4;
		if (numberOfAcceptedTransactionSets > 0)
			subject.NumberOfAcceptedTransactionSets = numberOfAcceptedTransactionSets;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
