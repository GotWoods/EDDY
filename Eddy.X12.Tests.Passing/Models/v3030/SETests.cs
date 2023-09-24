using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SE*5*UQTj";

		var expected = new SE_TransactionSetTrailer()
		{
			NumberOfIncludedSegments = 5,
			TransactionSetControlNumber = "UQTj",
		};

		var actual = Map.MapObject<SE_TransactionSetTrailer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredNumberOfIncludedSegments(int numberOfIncludedSegments, bool isValidExpected)
	{
		var subject = new SE_TransactionSetTrailer();
		subject.TransactionSetControlNumber = "UQTj";
		if (numberOfIncludedSegments > 0)
			subject.NumberOfIncludedSegments = numberOfIncludedSegments;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UQTj", true)]
	public void Validation_RequiredTransactionSetControlNumber(string transactionSetControlNumber, bool isValidExpected)
	{
		var subject = new SE_TransactionSetTrailer();
		subject.NumberOfIncludedSegments = 5;
		subject.TransactionSetControlNumber = transactionSetControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
