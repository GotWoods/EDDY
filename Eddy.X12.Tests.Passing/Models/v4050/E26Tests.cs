using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class E26Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E26*l*7*5*9*m*3";

		var expected = new E26_ElementSequenceInComposite()
		{
			MaintenanceOperationCode = "l",
			PositionInComposite = 7,
			DataElementReferenceNumber = 5,
			RequirementDesignator = "9",
			DataElementUsageType = "m",
			NoteIdentificationNumber = 3,
		};

		var actual = Map.MapObject<E26_ElementSequenceInComposite>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E26_ElementSequenceInComposite();
		subject.PositionInComposite = 7;
		subject.DataElementReferenceNumber = 5;
		subject.RequirementDesignator = "9";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredPositionInComposite(int positionInComposite, bool isValidExpected)
	{
		var subject = new E26_ElementSequenceInComposite();
		subject.MaintenanceOperationCode = "l";
		subject.DataElementReferenceNumber = 5;
		subject.RequirementDesignator = "9";
		if (positionInComposite > 0)
			subject.PositionInComposite = positionInComposite;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredDataElementReferenceNumber(int dataElementReferenceNumber, bool isValidExpected)
	{
		var subject = new E26_ElementSequenceInComposite();
		subject.MaintenanceOperationCode = "l";
		subject.PositionInComposite = 7;
		subject.RequirementDesignator = "9";
		if (dataElementReferenceNumber > 0)
			subject.DataElementReferenceNumber = dataElementReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredRequirementDesignator(string requirementDesignator, bool isValidExpected)
	{
		var subject = new E26_ElementSequenceInComposite();
		subject.MaintenanceOperationCode = "l";
		subject.PositionInComposite = 7;
		subject.DataElementReferenceNumber = 5;
		subject.RequirementDesignator = requirementDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
