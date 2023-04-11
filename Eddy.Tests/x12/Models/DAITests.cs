using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class DAITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DAI*p*5*7";

		var expected = new DAI_AppendixInformation()
		{
			MaintenanceOperationCode = "p",
			CodeListReference = "5",
			NoteIdentificationNumber = 7,
		};

		var actual = Map.MapObject<DAI_AppendixInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validatation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new DAI_AppendixInformation();
		subject.CodeListReference = "5";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validatation_RequiredCodeListReference(string codeListReference, bool isValidExpected)
	{
		var subject = new DAI_AppendixInformation();
		subject.MaintenanceOperationCode = "p";
		subject.CodeListReference = codeListReference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
