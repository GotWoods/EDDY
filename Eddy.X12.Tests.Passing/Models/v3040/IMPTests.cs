using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class IMPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "IMP*Y7*5";

		var expected = new IMP_ImpairmentDetail()
		{
			PartOfBodyCode = "Y7",
			Percent = 5,
		};

		var actual = Map.MapObject<IMP_ImpairmentDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y7", true)]
	public void Validation_RequiredPartOfBodyCode(string partOfBodyCode, bool isValidExpected)
	{
		var subject = new IMP_ImpairmentDetail();
		//Required fields
		//Test Parameters
		subject.PartOfBodyCode = partOfBodyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
