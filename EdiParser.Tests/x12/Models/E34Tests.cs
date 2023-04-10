using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class E34Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E34*I*X*u*f";

		var expected = new E34_CodeListValuesForADataElement()
		{
			MaintenanceOperationCode = "I",
			CodeValue = "X",
			PartitionIndicator = "u",
			Description = "f",
		};

		var actual = Map.MapObject<E34_CodeListValuesForADataElement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validatation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E34_CodeListValuesForADataElement();
		subject.CodeValue = "X";
		subject.Description = "f";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validatation_RequiredCodeValue(string codeValue, bool isValidExpected)
	{
		var subject = new E34_CodeListValuesForADataElement();
		subject.MaintenanceOperationCode = "I";
		subject.Description = "f";
		subject.CodeValue = codeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validatation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new E34_CodeListValuesForADataElement();
		subject.MaintenanceOperationCode = "I";
		subject.CodeValue = "X";
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
