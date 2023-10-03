using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6020;
using Eddy.x12.Models.v6020.Composites;

namespace Eddy.x12.Tests.Models.v6020.Composites;

public class C062Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "D*I";

		var expected = new C062_TaxAdvantageAccountInformation()
		{
			AccountRelationshipCode = "D",
			AccountNumber = "I",
		};

		var actual = Map.MapObject<C062_TaxAdvantageAccountInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredAccountRelationshipCode(string accountRelationshipCode, bool isValidExpected)
	{
		var subject = new C062_TaxAdvantageAccountInformation();
		//Required fields
		//Test Parameters
		subject.AccountRelationshipCode = accountRelationshipCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
