using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CAITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAI*MJ*u*p*T*8*JX*j";

		var expected = new CAI_CivilActionIncome()
		{
			PublicRecordOrObligationCode = "MJ",
			Name = "u",
			Name2 = "p",
			AmountQualifierCode = "T",
			MonetaryAmount = 8,
			RateValueQualifier = "JX",
			ReferenceIdentification = "j",
		};

		var actual = Map.MapObject<CAI_CivilActionIncome>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MJ", true)]
	public void Validation_RequiredPublicRecordOrObligationCode(string publicRecordOrObligationCode, bool isValidExpected)
	{
		var subject = new CAI_CivilActionIncome();
		//Required fields
		subject.Name = "u";
		//Test Parameters
		subject.PublicRecordOrObligationCode = publicRecordOrObligationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new CAI_CivilActionIncome();
		//Required fields
		subject.PublicRecordOrObligationCode = "MJ";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
