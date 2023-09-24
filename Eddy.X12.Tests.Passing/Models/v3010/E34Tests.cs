using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class E34Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E34*K*F*H*U";

		var expected = new E34_CodeListValuesForADataElement()
		{
			MaintenanceOperationCode = "K",
			CodeValue = "F",
			PartitionIndicator = "H",
			Description = "U",
		};

		var actual = Map.MapObject<E34_CodeListValuesForADataElement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E34_CodeListValuesForADataElement();
		subject.CodeValue = "F";
		subject.Description = "U";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredCodeValue(string codeValue, bool isValidExpected)
	{
		var subject = new E34_CodeListValuesForADataElement();
		subject.MaintenanceOperationCode = "K";
		subject.Description = "U";
		subject.CodeValue = codeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new E34_CodeListValuesForADataElement();
		subject.MaintenanceOperationCode = "K";
		subject.CodeValue = "F";
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
