using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class GETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GE*5*6";

		var expected = new GE_FunctionalGroupTrailer()
		{
			NumberOfTransactionSetsIncluded = 5,
			GroupControlNumber = 6,
		};

		var actual = Map.MapObject<GE_FunctionalGroupTrailer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredNumberOfTransactionSetsIncluded(int numberOfTransactionSetsIncluded, bool isValidExpected)
	{
		var subject = new GE_FunctionalGroupTrailer();
		subject.GroupControlNumber = 6;
		if (numberOfTransactionSetsIncluded > 0)
			subject.NumberOfTransactionSetsIncluded = numberOfTransactionSetsIncluded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredGroupControlNumber(int groupControlNumber, bool isValidExpected)
	{
		var subject = new GE_FunctionalGroupTrailer();
		subject.NumberOfTransactionSetsIncluded = 5;
		if (groupControlNumber > 0)
			subject.GroupControlNumber = groupControlNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
