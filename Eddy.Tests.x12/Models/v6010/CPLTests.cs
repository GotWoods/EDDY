using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class CPLTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CPL*Ar*N*K*u*ki*w*fo*qy*Qd*X*b*1";

		var expected = new CPL_ProgramInformation()
		{
			ProgramTypeCode = "Ar",
			Description = "N",
			ActionCode = "K",
			ContractDateBasisCode = "u",
			EntityIdentifierCode = "ki",
			Description2 = "w",
			ConditionIndicator = "fo",
			ProgramBasisTypeCode = "qy",
			ConditionIndicator2 = "Qd",
			YesNoConditionOrResponseCode = "X",
			YesNoConditionOrResponseCode2 = "b",
			YesNoConditionOrResponseCode3 = "1",
		};

		var actual = Map.MapObject<CPL_ProgramInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ar", true)]
	public void Validation_RequiredProgramTypeCode(string programTypeCode, bool isValidExpected)
	{
		var subject = new CPL_ProgramInformation();
		//Required fields
		subject.Description = "N";
		subject.ActionCode = "K";
		//Test Parameters
		subject.ProgramTypeCode = programTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode))
		{
			subject.ContractDateBasisCode = "u";
			subject.EntityIdentifierCode = "ki";
		}
		if(!string.IsNullOrEmpty(subject.ConditionIndicator) || !string.IsNullOrEmpty(subject.ConditionIndicator) || !string.IsNullOrEmpty(subject.ProgramBasisTypeCode))
		{
			subject.ConditionIndicator = "fo";
			subject.ProgramBasisTypeCode = "qy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new CPL_ProgramInformation();
		//Required fields
		subject.ProgramTypeCode = "Ar";
		subject.ActionCode = "K";
		//Test Parameters
		subject.Description = description;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode))
		{
			subject.ContractDateBasisCode = "u";
			subject.EntityIdentifierCode = "ki";
		}
		if(!string.IsNullOrEmpty(subject.ConditionIndicator) || !string.IsNullOrEmpty(subject.ConditionIndicator) || !string.IsNullOrEmpty(subject.ProgramBasisTypeCode))
		{
			subject.ConditionIndicator = "fo";
			subject.ProgramBasisTypeCode = "qy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new CPL_ProgramInformation();
		//Required fields
		subject.ProgramTypeCode = "Ar";
		subject.Description = "N";
		//Test Parameters
		subject.ActionCode = actionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode))
		{
			subject.ContractDateBasisCode = "u";
			subject.EntityIdentifierCode = "ki";
		}
		if(!string.IsNullOrEmpty(subject.ConditionIndicator) || !string.IsNullOrEmpty(subject.ConditionIndicator) || !string.IsNullOrEmpty(subject.ProgramBasisTypeCode))
		{
			subject.ConditionIndicator = "fo";
			subject.ProgramBasisTypeCode = "qy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u", "ki", true)]
	[InlineData("u", "", false)]
	[InlineData("", "ki", false)]
	public void Validation_AllAreRequiredContractDateBasisCode(string contractDateBasisCode, string entityIdentifierCode, bool isValidExpected)
	{
		var subject = new CPL_ProgramInformation();
		//Required fields
		subject.ProgramTypeCode = "Ar";
		subject.Description = "N";
		subject.ActionCode = "K";
		//Test Parameters
		subject.ContractDateBasisCode = contractDateBasisCode;
		subject.EntityIdentifierCode = entityIdentifierCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ConditionIndicator) || !string.IsNullOrEmpty(subject.ConditionIndicator) || !string.IsNullOrEmpty(subject.ProgramBasisTypeCode))
		{
			subject.ConditionIndicator = "fo";
			subject.ProgramBasisTypeCode = "qy";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fo", "qy", true)]
	[InlineData("fo", "", false)]
	[InlineData("", "qy", false)]
	public void Validation_AllAreRequiredConditionIndicator(string conditionIndicator, string programBasisTypeCode, bool isValidExpected)
	{
		var subject = new CPL_ProgramInformation();
		//Required fields
		subject.ProgramTypeCode = "Ar";
		subject.Description = "N";
		subject.ActionCode = "K";
		//Test Parameters
		subject.ConditionIndicator = conditionIndicator;
		subject.ProgramBasisTypeCode = programBasisTypeCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.ContractDateBasisCode) || !string.IsNullOrEmpty(subject.EntityIdentifierCode))
		{
			subject.ContractDateBasisCode = "u";
			subject.EntityIdentifierCode = "ki";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
