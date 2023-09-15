using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class M15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "M15*V*Y*Dqcx3Q*W*rb";

		var expected = new M15_MasterInBondArrivalDetails()
		{
			StatusCode = "V",
			ReferenceNumber = "Y",
			EventDate = "Dqcx3Q",
			LocationIdentifier = "W",
			StandardCarrierAlphaCode = "rb",
		};

		var actual = Map.MapObject<M15_MasterInBondArrivalDetails>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredStatusCode(string statusCode, bool isValidExpected)
	{
		var subject = new M15_MasterInBondArrivalDetails();
		subject.ReferenceNumber = "Y";
		subject.StatusCode = statusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new M15_MasterInBondArrivalDetails();
		subject.StatusCode = "V";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
