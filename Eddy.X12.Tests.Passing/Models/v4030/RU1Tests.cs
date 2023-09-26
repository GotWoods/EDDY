using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class RU1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RU1*T*Z*Z*u*O1vOdJY2*w*G*SCf3XefZ*qYsWO92ppGLGvn";

		var expected = new RU1_RetirementBoardDetail()
		{
			RailRetirementActivityCode = "T",
			ReferenceIdentification = "Z",
			Name = "Z",
			ReferenceIdentification2 = "u",
			Date = "O1vOdJY2",
			EmploymentCode = "w",
			UnemployedReasonCode = "G",
			Date2 = "SCf3XefZ",
			ClaimProfile = "qYsWO92ppGLGvn",
		};

		var actual = Map.MapObject<RU1_RetirementBoardDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredRailRetirementActivityCode(string railRetirementActivityCode, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		//Required fields
		subject.ReferenceIdentification = "Z";
		subject.Name = "Z";
		//Test Parameters
		subject.RailRetirementActivityCode = railRetirementActivityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		//Required fields
		subject.RailRetirementActivityCode = "T";
		subject.Name = "Z";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredName(string name, bool isValidExpected)
	{
		var subject = new RU1_RetirementBoardDetail();
		//Required fields
		subject.RailRetirementActivityCode = "T";
		subject.ReferenceIdentification = "Z";
		//Test Parameters
		subject.Name = name;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
