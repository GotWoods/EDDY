using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4020;
using Eddy.x12.Models.v4020.Composites;

namespace Eddy.x12.Tests.Models.v4020.Composites;

public class C048Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "dA*np*gh*X";

		var expected = new C048_CompositeUseOfProceeds()
		{
			UseOfProceedsCode = "dA",
			RefinanceTypeCode = "np",
			UseOfProceedsCode2 = "gh",
			YesNoConditionOrResponseCode = "X",
		};

		var actual = Map.MapObject<C048_CompositeUseOfProceeds>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dA", true)]
	public void Validation_RequiredUseOfProceedsCode(string useOfProceedsCode, bool isValidExpected)
	{
		var subject = new C048_CompositeUseOfProceeds();
		//Required fields
		//Test Parameters
		subject.UseOfProceedsCode = useOfProceedsCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
