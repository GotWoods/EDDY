using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class B5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "B5*mK1*4*1*1";

		var expected = new B5_BeginningSegmentForAcceptanceRejection()
		{
			TransactionSetIdentifierCode = "mK1",
			NumberOfAcceptedTransactionSets = 4,
			NumberOfReceivedTransactionSets = 1,
			GroupControlNumber = 1,
		};

		var actual = Map.MapObject<B5_BeginningSegmentForAcceptanceRejection>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredNumberOfAcceptedTransactionSets(int numberOfAcceptedTransactionSets, bool isValidExpected)
	{
		var subject = new B5_BeginningSegmentForAcceptanceRejection();
		subject.NumberOfReceivedTransactionSets = 1;
		subject.GroupControlNumber = 1;
		if (numberOfAcceptedTransactionSets > 0)
			subject.NumberOfAcceptedTransactionSets = numberOfAcceptedTransactionSets;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredNumberOfReceivedTransactionSets(int numberOfReceivedTransactionSets, bool isValidExpected)
	{
		var subject = new B5_BeginningSegmentForAcceptanceRejection();
		subject.NumberOfAcceptedTransactionSets = 4;
		subject.GroupControlNumber = 1;
		if (numberOfReceivedTransactionSets > 0)
			subject.NumberOfReceivedTransactionSets = numberOfReceivedTransactionSets;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredGroupControlNumber(int groupControlNumber, bool isValidExpected)
	{
		var subject = new B5_BeginningSegmentForAcceptanceRejection();
		subject.NumberOfAcceptedTransactionSets = 4;
		subject.NumberOfReceivedTransactionSets = 1;
		if (groupControlNumber > 0)
			subject.GroupControlNumber = groupControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
