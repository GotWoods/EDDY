using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class E03Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E03*d*L*R7*G*R*6*4";

		var expected = new E03_InterchangeOrderOfSegments()
		{
			MaintenanceOperationCode = "d",
			LevelNumberCode = "L",
			SegmentIDCode = "R7",
			EnvelopeIndicatorCode = "G",
			RequirementDesignatorCode = "R",
			MaximumUse = 6,
			NoteIdentificationNumber = 4,
		};

		var actual = Map.MapObject<E03_InterchangeOrderOfSegments>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.LevelNumberCode = "L";
		subject.SegmentIDCode = "R7";
		subject.EnvelopeIndicatorCode = "G";
		subject.RequirementDesignatorCode = "R";
		subject.MaximumUse = 6;
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredLevelNumberCode(string levelNumberCode, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.MaintenanceOperationCode = "d";
		subject.SegmentIDCode = "R7";
		subject.EnvelopeIndicatorCode = "G";
		subject.RequirementDesignatorCode = "R";
		subject.MaximumUse = 6;
		subject.LevelNumberCode = levelNumberCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R7", true)]
	public void Validation_RequiredSegmentIDCode(string segmentIDCode, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.MaintenanceOperationCode = "d";
		subject.LevelNumberCode = "L";
		subject.EnvelopeIndicatorCode = "G";
		subject.RequirementDesignatorCode = "R";
		subject.MaximumUse = 6;
		subject.SegmentIDCode = segmentIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredEnvelopeIndicatorCode(string envelopeIndicatorCode, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.MaintenanceOperationCode = "d";
		subject.LevelNumberCode = "L";
		subject.SegmentIDCode = "R7";
		subject.RequirementDesignatorCode = "R";
		subject.MaximumUse = 6;
		subject.EnvelopeIndicatorCode = envelopeIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredRequirementDesignatorCode(string requirementDesignatorCode, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.MaintenanceOperationCode = "d";
		subject.LevelNumberCode = "L";
		subject.SegmentIDCode = "R7";
		subject.EnvelopeIndicatorCode = "G";
		subject.MaximumUse = 6;
		subject.RequirementDesignatorCode = requirementDesignatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMaximumUse(int maximumUse, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.MaintenanceOperationCode = "d";
		subject.LevelNumberCode = "L";
		subject.SegmentIDCode = "R7";
		subject.EnvelopeIndicatorCode = "G";
		subject.RequirementDesignatorCode = "R";
		if (maximumUse > 0)
			subject.MaximumUse = maximumUse;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
