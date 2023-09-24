using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class E24Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E24*p*1*3*w*J*8*9";

		var expected = new E24_DataElementSequenceInASegmentOrComposite()
		{
			MaintenanceOperationCode = "p",
			PositionInSegmentOrComposite = 1,
			DataElementReferenceNumber = 3,
			RequirementDesignatorCode = "w",
			DataElementUsageTypeCode = "J",
			NoteIdentificationNumber = 8,
			Count = 9,
		};

		var actual = Map.MapObject<E24_DataElementSequenceInASegmentOrComposite>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.PositionInSegmentOrComposite = 1;
		subject.DataElementReferenceNumber = 3;
		subject.RequirementDesignatorCode = "w";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredPositionInSegmentOrComposite(int positionInSegmentOrComposite, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.MaintenanceOperationCode = "p";
		subject.DataElementReferenceNumber = 3;
		subject.RequirementDesignatorCode = "w";
		if (positionInSegmentOrComposite > 0)
			subject.PositionInSegmentOrComposite = positionInSegmentOrComposite;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredDataElementReferenceNumber(int dataElementReferenceNumber, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.MaintenanceOperationCode = "p";
		subject.PositionInSegmentOrComposite = 1;
		subject.RequirementDesignatorCode = "w";
		if (dataElementReferenceNumber > 0)
			subject.DataElementReferenceNumber = dataElementReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredRequirementDesignatorCode(string requirementDesignatorCode, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.MaintenanceOperationCode = "p";
		subject.PositionInSegmentOrComposite = 1;
		subject.DataElementReferenceNumber = 3;
		subject.RequirementDesignatorCode = requirementDesignatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
