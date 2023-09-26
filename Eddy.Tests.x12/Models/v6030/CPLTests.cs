using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class CPLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CPL*3I*u*P*F*QH*8*ZW*hF*Hp*l*H*h";

		var expected = new CPL_ProgramInformation()
		{
			ProgramTypeCode = "3I",
			Description = "u",
			ActionCode = "P",
			ContractDateBasisCode = "F",
			EntityIdentifierCode = "QH",
			Description2 = "8",
			ConditionIndicatorCode = "ZW",
			ProgramBasisTypeCode = "hF",
			ConditionIndicatorCode2 = "Hp",
			YesNoConditionOrResponseCode = "l",
			YesNoConditionOrResponseCode2 = "H",
			YesNoConditionOrResponseCode3 = "h",
		};

		var actual = Map.MapObject<CPL_ProgramInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3I", true)]
	public void Validation_RequiredProgramTypeCode(string programTypeCode, bool isValidExpected)
	{
		var subject = new CPL_ProgramInformation();
		//Required fields
		subject.Description = "u";
		subject.ActionCode = "P";
		//Test Parameters
		subject.ProgramTypeCode = programTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode))
		{
			subject.ContractDateBasisCode = "F";
			subject.EntityIdentifierCode = "QH";
		}
		if(!string.IsNullOrEmpty(subject.ConditionIndicatorCode) || !string.IsNullOrEmpty(subject.ConditionIndicatorCode) || !string.IsNullOrEmpty(subject.ProgramBasisTypeCode))
		{
			subject.ConditionIndicatorCode = "ZW";
			subject.ProgramBasisTypeCode = "hF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new CPL_ProgramInformation();
		//Required fields
		subject.ProgramTypeCode = "3I";
		subject.ActionCode = "P";
		//Test Parameters
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode))
		{
			subject.ContractDateBasisCode = "F";
			subject.EntityIdentifierCode = "QH";
		}
		if(!string.IsNullOrEmpty(subject.ConditionIndicatorCode) || !string.IsNullOrEmpty(subject.ConditionIndicatorCode) || !string.IsNullOrEmpty(subject.ProgramBasisTypeCode))
		{
			subject.ConditionIndicatorCode = "ZW";
			subject.ProgramBasisTypeCode = "hF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new CPL_ProgramInformation();
		//Required fields
		subject.ProgramTypeCode = "3I";
		subject.Description = "u";
		//Test Parameters
		subject.ActionCode = actionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode))
		{
			subject.ContractDateBasisCode = "F";
			subject.EntityIdentifierCode = "QH";
		}
		if(!string.IsNullOrEmpty(subject.ConditionIndicatorCode) || !string.IsNullOrEmpty(subject.ConditionIndicatorCode) || !string.IsNullOrEmpty(subject.ProgramBasisTypeCode))
		{
			subject.ConditionIndicatorCode = "ZW";
			subject.ProgramBasisTypeCode = "hF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("F", "QH", true)]
	[InlineData("F", "", false)]
	[InlineData("", "QH", false)]
	public void Validation_AllAreRequiredContractDateBasisCode(string contractDateBasisCode, string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new CPL_ProgramInformation();
		//Required fields
		subject.ProgramTypeCode = "3I";
		subject.Description = "u";
		subject.ActionCode = "P";
		//Test Parameters
		subject.ContractDateBasisCode = contractDateBasisCode;
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ConditionIndicatorCode) || !string.IsNullOrEmpty(subject.ConditionIndicatorCode) || !string.IsNullOrEmpty(subject.ProgramBasisTypeCode))
		{
			subject.ConditionIndicatorCode = "ZW";
			subject.ProgramBasisTypeCode = "hF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ZW", "hF", true)]
	[InlineData("ZW", "", false)]
	[InlineData("", "hF", false)]
	public void Validation_AllAreRequiredConditionIndicatorCode(string conditionIndicatorCode, string programBasisTypeCode, bool isValidExpected)
	{
		var subject = new CPL_ProgramInformation();
		//Required fields
		subject.ProgramTypeCode = "3I";
		subject.Description = "u";
		subject.ActionCode = "P";
		//Test Parameters
		subject.ConditionIndicatorCode = conditionIndicatorCode;
		subject.ProgramBasisTypeCode = programBasisTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode))
		{
			subject.ContractDateBasisCode = "F";
			subject.EntityIdentifierCode = "QH";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
