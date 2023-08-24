using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B5*t5s*2*9*5";

		var expected = new B5_BeginningSegmentForAcceptanceRejection()
		{
			TransactionSetIdentifierCode = "t5s",
			NumberOfAcceptedTransactionSets = 2,
			NumberOfReceivedTransactionSets = 9,
			GroupControlNumber = 5,
		};

		var actual = Map.MapObject<B5_BeginningSegmentForAcceptanceRejection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredNumberOfAcceptedTransactionSets(int numberOfAcceptedTransactionSets, bool isValidExpected)
	{
		var subject = new B5_BeginningSegmentForAcceptanceRejection();
		subject.NumberOfReceivedTransactionSets = 9;
		subject.GroupControlNumber = 5;
		if (numberOfAcceptedTransactionSets > 0)
		subject.NumberOfAcceptedTransactionSets = numberOfAcceptedTransactionSets;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredNumberOfReceivedTransactionSets(int numberOfReceivedTransactionSets, bool isValidExpected)
	{
		var subject = new B5_BeginningSegmentForAcceptanceRejection();
		subject.NumberOfAcceptedTransactionSets = 2;
		subject.GroupControlNumber = 5;
		if (numberOfReceivedTransactionSets > 0)
		subject.NumberOfReceivedTransactionSets = numberOfReceivedTransactionSets;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredGroupControlNumber(int groupControlNumber, bool isValidExpected)
	{
		var subject = new B5_BeginningSegmentForAcceptanceRejection();
		subject.NumberOfAcceptedTransactionSets = 2;
		subject.NumberOfReceivedTransactionSets = 9;
		if (groupControlNumber > 0)
		subject.GroupControlNumber = groupControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
