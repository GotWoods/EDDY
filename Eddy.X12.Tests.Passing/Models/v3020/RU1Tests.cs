using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class RU1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RU1*A*Z*f*9*lmywmS*U*2*IF58MK*NKHFLHT1AhHPCJ";

		var expected = new RU1_RetirementBoardDetail()
		{
			RailRetirementActivityCode = "A",
			ReferenceNumber = "Z",
			Name = "f",
			ReferenceNumber2 = "9",
			Date = "lmywmS",
			EmploymentCode = "U",
			UnemployedReasonCode = "2",
			Date2 = "IF58MK",
			ClaimProfile = "NKHFLHT1AhHPCJ",
		};

		var actual = Map.MapObject<RU1_RetirementBoardDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredRailRetirementActivityCode(string railRetirementActivityCode, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		//Required fields
		subject.ReferenceNumber = "Z";
		subject.Name = "f";
		//Test Parameters
		subject.RailRetirementActivityCode = railRetirementActivityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		//Required fields
		subject.RailRetirementActivityCode = "A";
		subject.Name = "f";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		//Required fields
		subject.RailRetirementActivityCode = "A";
		subject.ReferenceNumber = "Z";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
