using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class E26Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E26*p*2*2*N*C*3";

		var expected = new E26_ElementSequenceInComposite()
		{
			MaintenanceOperationCode = "p",
			PositionInComposite = 2,
			DataElementReferenceNumber = 2,
			RequirementDesignator = "N",
			DataElementType = "C",
			NoteIdentificationNumber = 3,
		};

		var actual = Map.MapObject<E26_ElementSequenceInComposite>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E26_ElementSequenceInComposite();
		subject.PositionInComposite = 2;
		subject.DataElementReferenceNumber = 2;
		subject.RequirementDesignator = "N";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredPositionInComposite(int positionInComposite, bool isValidExpected)
	{
		var subject = new E26_ElementSequenceInComposite();
		subject.MaintenanceOperationCode = "p";
		subject.DataElementReferenceNumber = 2;
		subject.RequirementDesignator = "N";
		if (positionInComposite > 0)
			subject.PositionInComposite = positionInComposite;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredDataElementReferenceNumber(int dataElementReferenceNumber, bool isValidExpected)
	{
		var subject = new E26_ElementSequenceInComposite();
		subject.MaintenanceOperationCode = "p";
		subject.PositionInComposite = 2;
		subject.RequirementDesignator = "N";
		if (dataElementReferenceNumber > 0)
			subject.DataElementReferenceNumber = dataElementReferenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredRequirementDesignator(string requirementDesignator, bool isValidExpected)
	{
		var subject = new E26_ElementSequenceInComposite();
		subject.MaintenanceOperationCode = "p";
		subject.PositionInComposite = 2;
		subject.DataElementReferenceNumber = 2;
		subject.RequirementDesignator = requirementDesignator;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
