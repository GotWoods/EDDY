using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class IMPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IMP*dF*1";

		var expected = new IMP_ImpairmentDetail()
		{
			PartOfBodyCode = "dF",
			PercentageAsDecimal = 1,
		};

		var actual = Map.MapObject<IMP_ImpairmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dF", true)]
	public void Validation_RequiredPartOfBodyCode(string partOfBodyCode, bool isValidExpected)
	{
		var subject = new IMP_ImpairmentDetail();
		subject.PartOfBodyCode = partOfBodyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
