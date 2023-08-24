using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class AK9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AK9*T*9*1*1*h*k*A*M*n";

		var expected = new AK9_FunctionalGroupResponseTrailer()
		{
			FunctionalGroupAcknowledgeCode = "T",
			NumberOfTransactionSetsIncluded = 9,
			NumberOfReceivedTransactionSets = 1,
			NumberOfAcceptedTransactionSets = 1,
			FunctionalGroupSyntaxErrorCode = "h",
			FunctionalGroupSyntaxErrorCode2 = "k",
			FunctionalGroupSyntaxErrorCode3 = "A",
			FunctionalGroupSyntaxErrorCode4 = "M",
			FunctionalGroupSyntaxErrorCode5 = "n",
		};

		var actual = Map.MapObject<AK9_FunctionalGroupResponseTrailer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredFunctionalGroupAcknowledgeCode(string functionalGroupAcknowledgeCode, bool isValidExpected)
	{
		var subject = new AK9_FunctionalGroupResponseTrailer();
		subject.NumberOfTransactionSetsIncluded = 9;
		subject.NumberOfReceivedTransactionSets = 1;
		subject.NumberOfAcceptedTransactionSets = 1;
		subject.FunctionalGroupAcknowledgeCode = functionalGroupAcknowledgeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredNumberOfTransactionSetsIncluded(int numberOfTransactionSetsIncluded, bool isValidExpected)
	{
		var subject = new AK9_FunctionalGroupResponseTrailer();
		subject.FunctionalGroupAcknowledgeCode = "T";
		subject.NumberOfReceivedTransactionSets = 1;
		subject.NumberOfAcceptedTransactionSets = 1;
		if (numberOfTransactionSetsIncluded > 0)
		subject.NumberOfTransactionSetsIncluded = numberOfTransactionSetsIncluded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredNumberOfReceivedTransactionSets(int numberOfReceivedTransactionSets, bool isValidExpected)
	{
		var subject = new AK9_FunctionalGroupResponseTrailer();
		subject.FunctionalGroupAcknowledgeCode = "T";
		subject.NumberOfTransactionSetsIncluded = 9;
		subject.NumberOfAcceptedTransactionSets = 1;
		if (numberOfReceivedTransactionSets > 0)
		subject.NumberOfReceivedTransactionSets = numberOfReceivedTransactionSets;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredNumberOfAcceptedTransactionSets(int numberOfAcceptedTransactionSets, bool isValidExpected)
	{
		var subject = new AK9_FunctionalGroupResponseTrailer();
		subject.FunctionalGroupAcknowledgeCode = "T";
		subject.NumberOfTransactionSetsIncluded = 9;
		subject.NumberOfReceivedTransactionSets = 1;
		if (numberOfAcceptedTransactionSets > 0)
		subject.NumberOfAcceptedTransactionSets = numberOfAcceptedTransactionSets;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
