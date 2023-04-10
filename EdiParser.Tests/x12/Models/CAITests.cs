using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class CAITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAI*V4*N*3*G*6*02*h";

		var expected = new CAI_CivilActionIncome()
		{
			PublicRecordOrObligationCode = "V4",
			Name = "N",
			Name2 = "3",
			AmountQualifierCode = "G",
			MonetaryAmount = 6,
			RateValueQualifier = "02",
			ReferenceIdentification = "h",
		};

		var actual = Map.MapObject<CAI_CivilActionIncome>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V4", true)]
	public void Validatation_RequiredPublicRecordOrObligationCode(string publicRecordOrObligationCode, bool isValidExpected)
	{
		var subject = new CAI_CivilActionIncome();
		subject.Name = "N";
		subject.PublicRecordOrObligationCode = publicRecordOrObligationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validatation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new CAI_CivilActionIncome();
		subject.PublicRecordOrObligationCode = "V4";
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
