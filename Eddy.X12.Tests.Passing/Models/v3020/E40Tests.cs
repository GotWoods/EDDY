using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class E40Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E40*7*9*3ll*f";

		var expected = new E40_EDIStandardsNoteReference()
		{
			MaintenanceOperationCode = "7",
			NoteIdentificationNumber = 9,
			ElectronicFormNoteReferenceCode = "3ll",
			AssignedIdentification = "f",
		};

		var actual = Map.MapObject<E40_EDIStandardsNoteReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E40_EDIStandardsNoteReference();
		subject.NoteIdentificationNumber = 9;
		subject.ElectronicFormNoteReferenceCode = "3ll";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredNoteIdentificationNumber(int noteIdentificationNumber, bool isValidExpected)
	{
		var subject = new E40_EDIStandardsNoteReference();
		subject.MaintenanceOperationCode = "7";
		subject.ElectronicFormNoteReferenceCode = "3ll";
		if (noteIdentificationNumber > 0)
			subject.NoteIdentificationNumber = noteIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3ll", true)]
	public void Validation_RequiredElectronicFormNoteReferenceCode(string electronicFormNoteReferenceCode, bool isValidExpected)
	{
		var subject = new E40_EDIStandardsNoteReference();
		subject.MaintenanceOperationCode = "7";
		subject.NoteIdentificationNumber = 9;
		subject.ElectronicFormNoteReferenceCode = electronicFormNoteReferenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
