using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class E40Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E40*n*5*Ewm*O";

		var expected = new E40_EDIStandardsNoteReference()
		{
			MaintenanceOperationCode = "n",
			NoteIdentificationNumber = 5,
			ElectronicFormNoteReferenceCode = "Ewm",
			AssignedIdentification = "O",
		};

		var actual = Map.MapObject<E40_EDIStandardsNoteReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E40_EDIStandardsNoteReference();
		subject.NoteIdentificationNumber = 5;
		subject.ElectronicFormNoteReferenceCode = "Ewm";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredNoteIdentificationNumber(int noteIdentificationNumber, bool isValidExpected)
	{
		var subject = new E40_EDIStandardsNoteReference();
		subject.MaintenanceOperationCode = "n";
		subject.ElectronicFormNoteReferenceCode = "Ewm";
		if (noteIdentificationNumber > 0)
			subject.NoteIdentificationNumber = noteIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ewm", true)]
	public void Validation_RequiredElectronicFormNoteReferenceCode(string electronicFormNoteReferenceCode, bool isValidExpected)
	{
		var subject = new E40_EDIStandardsNoteReference();
		subject.MaintenanceOperationCode = "n";
		subject.NoteIdentificationNumber = 5;
		subject.ElectronicFormNoteReferenceCode = electronicFormNoteReferenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
