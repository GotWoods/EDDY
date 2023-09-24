using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class E24Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E24*W*4*O*G*k*8*7";

		var expected = new E24_DataElementSequenceInASegmentOrComposite()
		{
			MaintenanceOperationCode = "W",
			PositionInSegmentOrComposite = 4,
			DataElementReferenceCode = "O",
			RequirementDesignatorCode = "G",
			DataElementUsageTypeCode = "k",
			NoteIdentificationNumber = 8,
			Count = 7,
		};

		var actual = Map.MapObject<E24_DataElementSequenceInASegmentOrComposite>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.PositionInSegmentOrComposite = 4;
		subject.DataElementReferenceCode = "O";
		subject.RequirementDesignatorCode = "G";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredPositionInSegmentOrComposite(int positionInSegmentOrComposite, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.MaintenanceOperationCode = "W";
		subject.DataElementReferenceCode = "O";
		subject.RequirementDesignatorCode = "G";
		if (positionInSegmentOrComposite > 0)
		subject.PositionInSegmentOrComposite = positionInSegmentOrComposite;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredDataElementReferenceCode(string dataElementReferenceCode, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.MaintenanceOperationCode = "W";
		subject.PositionInSegmentOrComposite = 4;
		subject.RequirementDesignatorCode = "G";
		subject.DataElementReferenceCode = dataElementReferenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredRequirementDesignatorCode(string requirementDesignatorCode, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.MaintenanceOperationCode = "W";
		subject.PositionInSegmentOrComposite = 4;
		subject.DataElementReferenceCode = "O";
		subject.RequirementDesignatorCode = requirementDesignatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
