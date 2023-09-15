using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class E03Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E03*s*b*6n*0*W*7*6";

		var expected = new E03_InterchangeOrderOfSegments()
		{
			MaintenanceOperationCode = "s",
			LevelNumber = "b",
			SegmentIDCode = "6n",
			EnvelopeIndicator = "0",
			RequirementDesignator = "W",
			MaximumUse = 7,
			NoteIdentificationNumber = 6,
		};

		var actual = Map.MapObject<E03_InterchangeOrderOfSegments>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.LevelNumber = "b";
		subject.SegmentIDCode = "6n";
		subject.EnvelopeIndicator = "0";
		subject.RequirementDesignator = "W";
		subject.MaximumUse = 7;
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredLevelNumber(string levelNumber, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.MaintenanceOperationCode = "s";
		subject.SegmentIDCode = "6n";
		subject.EnvelopeIndicator = "0";
		subject.RequirementDesignator = "W";
		subject.MaximumUse = 7;
		subject.LevelNumber = levelNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6n", true)]
	public void Validation_RequiredSegmentIDCode(string segmentIDCode, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.MaintenanceOperationCode = "s";
		subject.LevelNumber = "b";
		subject.EnvelopeIndicator = "0";
		subject.RequirementDesignator = "W";
		subject.MaximumUse = 7;
		subject.SegmentIDCode = segmentIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredEnvelopeIndicator(string envelopeIndicator, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.MaintenanceOperationCode = "s";
		subject.LevelNumber = "b";
		subject.SegmentIDCode = "6n";
		subject.RequirementDesignator = "W";
		subject.MaximumUse = 7;
		subject.EnvelopeIndicator = envelopeIndicator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredRequirementDesignator(string requirementDesignator, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.MaintenanceOperationCode = "s";
		subject.LevelNumber = "b";
		subject.SegmentIDCode = "6n";
		subject.EnvelopeIndicator = "0";
		subject.MaximumUse = 7;
		subject.RequirementDesignator = requirementDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMaximumUse(int maximumUse, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.MaintenanceOperationCode = "s";
		subject.LevelNumber = "b";
		subject.SegmentIDCode = "6n";
		subject.EnvelopeIndicator = "0";
		subject.RequirementDesignator = "W";
		if (maximumUse > 0)
			subject.MaximumUse = maximumUse;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
