using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W28Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W28*F*1*Q*0*7*l*x*N";

		var expected = new W28_ConsolidationInformation()
		{
			ConsolidationCode = "F",
			Weight = 1,
			WeightQualifier = "Q",
			WeightUnitQualifier = "0",
			TotalStopoffs = 7,
			LocationIdentifier = "l",
			LocationQualifier = "x",
			MasterBillOfLadingNumber = "N",
		};

		var actual = Map.MapObject<W28_ConsolidationInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredConsolidationCode(string consolidationCode, bool isValidExpected)
	{
		var subject = new W28_ConsolidationInformation();
		//Required fields
		//Test Parameters
		subject.ConsolidationCode = consolidationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
