using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CPLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CPL*72*a*v*A*vj*l*up*Di*mh*S*v*I";

		var expected = new CPL_ProgramInformation()
		{
			ProgramTypeCode = "72",
			Description = "a",
			ActionCode = "v",
			ContractDateBasisCode = "A",
			EntityIdentifierCode = "vj",
			Description2 = "l",
			ConditionIndicatorCode = "up",
			ProgramBasisTypeCode = "Di",
			ConditionIndicatorCode2 = "mh",
			YesNoConditionOrResponseCode = "S",
			YesNoConditionOrResponseCode2 = "v",
			YesNoConditionOrResponseCode3 = "I",
		};

		var actual = Map.MapObject<CPL_ProgramInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("72", true)]
	public void Validation_RequiredProgramTypeCode(string programTypeCode, bool isValidExpected)
	{
		var subject = new CPL_ProgramInformation();
		subject.Description = "a";
		subject.ActionCode = "v";
		subject.ProgramTypeCode = programTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new CPL_ProgramInformation();
		subject.ProgramTypeCode = "72";
		subject.ActionCode = "v";
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new CPL_ProgramInformation();
		subject.ProgramTypeCode = "72";
		subject.Description = "a";
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("A", "vj", true)]
	[InlineData("", "vj", false)]
	[InlineData("A", "", false)]
	public void Validation_AllAreRequiredContractDateBasisCode(string contractDateBasisCode, string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new CPL_ProgramInformation();
		subject.ProgramTypeCode = "72";
		subject.Description = "a";
		subject.ActionCode = "v";
		subject.ContractDateBasisCode = contractDateBasisCode;
		subject.EntityIdentifierCode = entityIdentifierCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("up", "Di", true)]
	[InlineData("", "Di", false)]
	[InlineData("up", "", false)]
	public void Validation_AllAreRequiredConditionIndicatorCode(string conditionIndicatorCode, string programBasisTypeCode, bool isValidExpected)
	{
		var subject = new CPL_ProgramInformation();
		subject.ProgramTypeCode = "72";
		subject.Description = "a";
		subject.ActionCode = "v";
		subject.ConditionIndicatorCode = conditionIndicatorCode;
		subject.ProgramBasisTypeCode = programBasisTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
