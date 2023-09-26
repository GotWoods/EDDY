using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CAITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CAI*IO*N*x*A*8*ql*7";

		var expected = new CAI_CivilActionIncome()
		{
			PublicRecordOrObligationCode = "IO",
			Name = "N",
			Name2 = "x",
			AmountQualifierCode = "A",
			MonetaryAmount = 8,
			RateValueQualifier = "ql",
			ReferenceIdentification = "7",
		};

		var actual = Map.MapObject<CAI_CivilActionIncome>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("IO", true)]
	public void Validation_RequiredPublicRecordOrObligationCode(string publicRecordOrObligationCode, bool isValidExpected)
	{
		var subject = new CAI_CivilActionIncome();
		//Required fields
		subject.Name = "N";
		//Test Parameters
		subject.PublicRecordOrObligationCode = publicRecordOrObligationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new CAI_CivilActionIncome();
		//Required fields
		subject.PublicRecordOrObligationCode = "IO";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
