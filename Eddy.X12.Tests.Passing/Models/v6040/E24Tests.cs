using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.Tests.Models.v6040;

public class E24Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E24*i*1*0*H*1*5*6";

		var expected = new E24_DataElementSequenceInASegmentOrComposite()
		{
			MaintenanceOperationCode = "i",
			PositionInSegmentOrComposite = 1,
			DataElementReferenceCode = "0",
			RequirementDesignatorCode = "H",
			DataElementUsageTypeCode = "1",
			NoteIdentificationNumber = 5,
			Count = 6,
		};

		var actual = Map.MapObject<E24_DataElementSequenceInASegmentOrComposite>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.PositionInSegmentOrComposite = 1;
		subject.DataElementReferenceCode = "0";
		subject.RequirementDesignatorCode = "H";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredPositionInSegmentOrComposite(int positionInSegmentOrComposite, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.MaintenanceOperationCode = "i";
		subject.DataElementReferenceCode = "0";
		subject.RequirementDesignatorCode = "H";
		if (positionInSegmentOrComposite > 0)
			subject.PositionInSegmentOrComposite = positionInSegmentOrComposite;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredDataElementReferenceCode(string dataElementReferenceCode, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.MaintenanceOperationCode = "i";
		subject.PositionInSegmentOrComposite = 1;
		subject.RequirementDesignatorCode = "H";
		subject.DataElementReferenceCode = dataElementReferenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("H", true)]
	public void Validation_RequiredRequirementDesignatorCode(string requirementDesignatorCode, bool isValidExpected)
	{
		var subject = new E24_DataElementSequenceInASegmentOrComposite();
		subject.MaintenanceOperationCode = "i";
		subject.PositionInSegmentOrComposite = 1;
		subject.DataElementReferenceCode = "0";
		subject.RequirementDesignatorCode = requirementDesignatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
