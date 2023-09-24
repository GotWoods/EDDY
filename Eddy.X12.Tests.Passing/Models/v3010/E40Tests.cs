using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class E40Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E40*5*2*Dme*P";

		var expected = new E40_EDIStandardsNoteReference()
		{
			MaintenanceOperationCode = "5",
			NoteIdentificationNumber = 2,
			ElectronicFormNoteReferenceCode = "Dme",
			AssignedIdentification = "P",
		};

		var actual = Map.MapObject<E40_EDIStandardsNoteReference>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E40_EDIStandardsNoteReference();
		subject.NoteIdentificationNumber = 2;
		subject.ElectronicFormNoteReferenceCode = "Dme";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredNoteIdentificationNumber(int noteIdentificationNumber, bool isValidExpected)
	{
		var subject = new E40_EDIStandardsNoteReference();
		subject.MaintenanceOperationCode = "5";
		subject.ElectronicFormNoteReferenceCode = "Dme";
		if (noteIdentificationNumber > 0)
			subject.NoteIdentificationNumber = noteIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dme", true)]
	public void Validation_RequiredElectronicFormNoteReferenceCode(string electronicFormNoteReferenceCode, bool isValidExpected)
	{
		var subject = new E40_EDIStandardsNoteReference();
		subject.MaintenanceOperationCode = "5";
		subject.NoteIdentificationNumber = 2;
		subject.ElectronicFormNoteReferenceCode = electronicFormNoteReferenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
