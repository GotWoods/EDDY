using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class CAITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAI*jj*G*9*r*7*oa*P";

		var expected = new CAI_CivilActionIncome()
		{
			PublicRecordOrObligationCode = "jj",
			Name = "G",
			Name2 = "9",
			AmountQualifierCode = "r",
			MonetaryAmount = 7,
			RateValueQualifier = "oa",
			ReferenceIdentification = "P",
		};

		var actual = Map.MapObject<CAI_CivilActionIncome>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jj", true)]
	public void Validation_RequiredPublicRecordOrObligationCode(string publicRecordOrObligationCode, bool isValidExpected)
	{
		var subject = new CAI_CivilActionIncome();
		//Required fields
		subject.Name = "G";
		//Test Parameters
		subject.PublicRecordOrObligationCode = publicRecordOrObligationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new CAI_CivilActionIncome();
		//Required fields
		subject.PublicRecordOrObligationCode = "jj";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
