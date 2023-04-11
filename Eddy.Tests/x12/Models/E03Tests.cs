using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class E03Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E03*n*I*Xo*P*j*1*5";

		var expected = new E03_InterchangeOrderOfSegments()
		{
			MaintenanceOperationCode = "n",
			LevelNumberCode = "I",
			SegmentIDCode = "Xo",
			EnvelopeIndicatorCode = "P",
			RequirementDesignatorCode = "j",
			MaximumUse = 1,
			NoteIdentificationNumber = 5,
		};

		var actual = Map.MapObject<E03_InterchangeOrderOfSegments>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validatation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.LevelNumberCode = "I";
		subject.SegmentIDCode = "Xo";
		subject.EnvelopeIndicatorCode = "P";
		subject.RequirementDesignatorCode = "j";
		subject.MaximumUse = 1;
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validatation_RequiredLevelNumberCode(string levelNumberCode, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.MaintenanceOperationCode = "n";
		subject.SegmentIDCode = "Xo";
		subject.EnvelopeIndicatorCode = "P";
		subject.RequirementDesignatorCode = "j";
		subject.MaximumUse = 1;
		subject.LevelNumberCode = levelNumberCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xo", true)]
	public void Validatation_RequiredSegmentIDCode(string segmentIDCode, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.MaintenanceOperationCode = "n";
		subject.LevelNumberCode = "I";
		subject.EnvelopeIndicatorCode = "P";
		subject.RequirementDesignatorCode = "j";
		subject.MaximumUse = 1;
		subject.SegmentIDCode = segmentIDCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validatation_RequiredEnvelopeIndicatorCode(string envelopeIndicatorCode, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.MaintenanceOperationCode = "n";
		subject.LevelNumberCode = "I";
		subject.SegmentIDCode = "Xo";
		subject.RequirementDesignatorCode = "j";
		subject.MaximumUse = 1;
		subject.EnvelopeIndicatorCode = envelopeIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validatation_RequiredRequirementDesignatorCode(string requirementDesignatorCode, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.MaintenanceOperationCode = "n";
		subject.LevelNumberCode = "I";
		subject.SegmentIDCode = "Xo";
		subject.EnvelopeIndicatorCode = "P";
		subject.MaximumUse = 1;
		subject.RequirementDesignatorCode = requirementDesignatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validatation_RequiredMaximumUse(int maximumUse, bool isValidExpected)
	{
		var subject = new E03_InterchangeOrderOfSegments();
		subject.MaintenanceOperationCode = "n";
		subject.LevelNumberCode = "I";
		subject.SegmentIDCode = "Xo";
		subject.EnvelopeIndicatorCode = "P";
		subject.RequirementDesignatorCode = "j";
		if (maximumUse > 0)
		subject.MaximumUse = maximumUse;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
