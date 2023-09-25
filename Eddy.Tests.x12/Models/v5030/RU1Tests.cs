using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class RU1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RU1*Q*q*p*K*TPhZOjul*m*C*XO8GDFrv*PkDxkAXsx6JaUu";

		var expected = new RU1_RetirementBoardDetail()
		{
			RailRetirementActivityCode = "Q",
			ReferenceIdentification = "q",
			Name = "p",
			ReferenceIdentification2 = "K",
			Date = "TPhZOjul",
			EmploymentCode = "m",
			UnemployedReasonCode = "C",
			Date2 = "XO8GDFrv",
			ClaimProfile = "PkDxkAXsx6JaUu",
		};

		var actual = Map.MapObject<RU1_RetirementBoardDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredRailRetirementActivityCode(string railRetirementActivityCode, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		//Required fields
		subject.ReferenceIdentification = "q";
		subject.Name = "p";
		//Test Parameters
		subject.RailRetirementActivityCode = railRetirementActivityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		//Required fields
		subject.RailRetirementActivityCode = "Q";
		subject.Name = "p";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		//Required fields
		subject.RailRetirementActivityCode = "Q";
		subject.ReferenceIdentification = "q";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
