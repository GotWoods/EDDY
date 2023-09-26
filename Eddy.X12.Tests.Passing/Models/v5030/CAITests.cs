using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class CAITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAI*3U*0*i*e*2*LQ*h";

		var expected = new CAI_CivilActionIncome()
		{
			PublicRecordOrObligationCode = "3U",
			Name = "0",
			Name2 = "i",
			AmountQualifierCode = "e",
			MonetaryAmount = 2,
			RateValueQualifier = "LQ",
			ReferenceIdentification = "h",
		};

		var actual = Map.MapObject<CAI_CivilActionIncome>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3U", true)]
	public void Validation_RequiredPublicRecordOrObligationCode(string publicRecordOrObligationCode, bool isValidExpected)
	{
		var subject = new CAI_CivilActionIncome();
		//Required fields
		subject.Name = "0";
		//Test Parameters
		subject.PublicRecordOrObligationCode = publicRecordOrObligationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new CAI_CivilActionIncome();
		//Required fields
		subject.PublicRecordOrObligationCode = "3U";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
