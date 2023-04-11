using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class E41Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E41*l*m*5*6";

		var expected = new E41_CompositeHeaderInformation()
		{
			MaintenanceOperationCode = "l",
			DataElementReferenceCode = "m",
			Description = "5",
			NoteIdentificationNumber = 6,
		};

		var actual = Map.MapObject<E41_CompositeHeaderInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E41_CompositeHeaderInformation();
		subject.DataElementReferenceCode = "m";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredDataElementReferenceCode(string dataElementReferenceCode, bool isValidExpected)
	{
		var subject = new E41_CompositeHeaderInformation();
		subject.MaintenanceOperationCode = "l";
		subject.DataElementReferenceCode = dataElementReferenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
