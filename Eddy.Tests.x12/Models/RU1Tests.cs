using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RU1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RU1*c*m*8*p*plnLwIIB*5*Y*woRUkEju*MOXwe183kbORfU";

		var expected = new RU1_RetirementBoardDetail()
		{
			RailRetirementActivityCode = "c",
			ReferenceIdentification = "m",
			Name = "8",
			ReferenceIdentification2 = "p",
			Date = "plnLwIIB",
			EmploymentCode = "5",
			UnemployedReasonCode = "Y",
			Date2 = "woRUkEju",
			ClaimProfile = "MOXwe183kbORfU",
		};

		var actual = Map.MapObject<RU1_RetirementBoardDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredRailRetirementActivityCode(string railRetirementActivityCode, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		subject.ReferenceIdentification = "m";
		subject.Name = "8";
		subject.RailRetirementActivityCode = railRetirementActivityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		subject.RailRetirementActivityCode = "c";
		subject.Name = "8";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		subject.RailRetirementActivityCode = "c";
		subject.ReferenceIdentification = "m";
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
