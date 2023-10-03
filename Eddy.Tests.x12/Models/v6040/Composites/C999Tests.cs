using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6040;
using Eddy.x12.Models.v6040.Composites;

namespace Eddy.x12.Tests.Models.v6040.Composites;

public class C999Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "C*O";

		var expected = new C999_ReferenceInSegment()
		{
			DataElementReferenceCode = "C",
			DataElementReferenceCode2 = "O",
		};

		var actual = Map.MapObject<C999_ReferenceInSegment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredDataElementReferenceCode(string dataElementReferenceCode, bool isValidExpected)
	{
		var subject = new C999_ReferenceInSegment();
		//Required fields
		//Test Parameters
		subject.DataElementReferenceCode = dataElementReferenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
