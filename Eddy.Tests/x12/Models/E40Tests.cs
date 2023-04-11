using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class E40Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E40*E*8*9Vy*W";

		var expected = new E40_EDIStandardsNoteReference()
		{
			MaintenanceOperationCode = "E",
			NoteIdentificationNumber = 8,
			ElectronicFormNoteReferenceCode = "9Vy",
			AssignedIdentification = "W",
		};

		var actual = Map.MapObject<E40_EDIStandardsNoteReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validatation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E40_EDIStandardsNoteReference();
		subject.NoteIdentificationNumber = 8;
		subject.ElectronicFormNoteReferenceCode = "9Vy";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validatation_RequiredNoteIdentificationNumber(int noteIdentificationNumber, bool isValidExpected)
	{
		var subject = new E40_EDIStandardsNoteReference();
		subject.MaintenanceOperationCode = "E";
		subject.ElectronicFormNoteReferenceCode = "9Vy";
		if (noteIdentificationNumber > 0)
		subject.NoteIdentificationNumber = noteIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9Vy", true)]
	public void Validatation_RequiredElectronicFormNoteReferenceCode(string electronicFormNoteReferenceCode, bool isValidExpected)
	{
		var subject = new E40_EDIStandardsNoteReference();
		subject.MaintenanceOperationCode = "E";
		subject.NoteIdentificationNumber = 8;
		subject.ElectronicFormNoteReferenceCode = electronicFormNoteReferenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
