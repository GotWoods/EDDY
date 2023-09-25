using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class RU1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RU1*l*h*w*d*sAilPv*2*t*1prPC3*cOTCYreGV47sT5";

		var expected = new RU1_RetirementBoardDetail()
		{
			RailRetirementActivityCode = "l",
			ReferenceIdentification = "h",
			Name = "w",
			ReferenceIdentification2 = "d",
			Date = "sAilPv",
			EmploymentCode = "2",
			UnemployedReasonCode = "t",
			Date2 = "1prPC3",
			ClaimProfile = "cOTCYreGV47sT5",
		};

		var actual = Map.MapObject<RU1_RetirementBoardDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredRailRetirementActivityCode(string railRetirementActivityCode, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		//Required fields
		subject.ReferenceIdentification = "h";
		subject.Name = "w";
		//Test Parameters
		subject.RailRetirementActivityCode = railRetirementActivityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		//Required fields
		subject.RailRetirementActivityCode = "l";
		subject.Name = "w";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		//Required fields
		subject.RailRetirementActivityCode = "l";
		subject.ReferenceIdentification = "h";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
