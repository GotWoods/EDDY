using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class E41Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E41*J*7*A*1";

		var expected = new E41_CompositeHeaderInformation()
		{
			MaintenanceOperationCode = "J",
			DataElementReferenceNumber = 7,
			Description = "A",
			NoteIdentificationNumber = 1,
		};

		var actual = Map.MapObject<E41_CompositeHeaderInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E41_CompositeHeaderInformation();
		//Required fields
		subject.DataElementReferenceNumber = 7;
		//Test Parameters
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredDataElementReferenceNumber(int dataElementReferenceNumber, bool isValidExpected)
	{
		var subject = new E41_CompositeHeaderInformation();
		//Required fields
		subject.MaintenanceOperationCode = "J";
		//Test Parameters
		if (dataElementReferenceNumber > 0) 
			subject.DataElementReferenceNumber = dataElementReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
