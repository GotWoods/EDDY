using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class RU1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RU1*1*Q*b*p*3gOfxt0O*h*3*7CnNqzqb*tcfFAwf8hoPsz8";

		var expected = new RU1_RetirementBoardDetail()
		{
			RailRetirementActivityCode = "1",
			ReferenceIdentification = "Q",
			Name = "b",
			ReferenceIdentification2 = "p",
			Date = "3gOfxt0O",
			EmploymentCode = "h",
			UnemployedReasonCode = "3",
			Date2 = "7CnNqzqb",
			ClaimProfile = "tcfFAwf8hoPsz8",
		};

		var actual = Map.MapObject<RU1_RetirementBoardDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredRailRetirementActivityCode(string railRetirementActivityCode, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		//Required fields
		subject.ReferenceIdentification = "Q";
		subject.Name = "b";
		//Test Parameters
		subject.RailRetirementActivityCode = railRetirementActivityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		//Required fields
		subject.RailRetirementActivityCode = "1";
		subject.Name = "b";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		//Required fields
		subject.RailRetirementActivityCode = "1";
		subject.ReferenceIdentification = "Q";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
