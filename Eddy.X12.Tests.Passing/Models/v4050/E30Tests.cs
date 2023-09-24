using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class E30Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E30*7*5*R*4*6*e*2*3*5";

		var expected = new E30_DataElementAttributes()
		{
			MaintenanceOperationCode = "7",
			DataElementReferenceNumber = 5,
			DataElementDataType = "R",
			MinimumLength = 4,
			MaximumLength = 6,
			Description = "e",
			NoteIdentificationNumber = 2,
			DataElementReferenceNumber2 = 3,
			CodeListReference = "5",
		};

		var actual = Map.MapObject<E30_DataElementAttributes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.DataElementReferenceNumber = 5;
		subject.DataElementDataType = "R";
		subject.MinimumLength = 4;
		subject.MaximumLength = 6;
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		//If one is filled, all are required
		if(subject.DataElementReferenceNumber2 > 0 || subject.DataElementReferenceNumber2 > 0 || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceNumber2 = 3;
			subject.CodeListReference = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredDataElementReferenceNumber(int dataElementReferenceNumber, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "7";
		subject.DataElementDataType = "R";
		subject.MinimumLength = 4;
		subject.MaximumLength = 6;
		if (dataElementReferenceNumber > 0)
			subject.DataElementReferenceNumber = dataElementReferenceNumber;
		//If one is filled, all are required
		if(subject.DataElementReferenceNumber2 > 0 || subject.DataElementReferenceNumber2 > 0 || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceNumber2 = 3;
			subject.CodeListReference = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredDataElementDataType(string dataElementDataType, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "7";
		subject.DataElementReferenceNumber = 5;
		subject.MinimumLength = 4;
		subject.MaximumLength = 6;
		subject.DataElementDataType = dataElementDataType;
		//If one is filled, all are required
		if(subject.DataElementReferenceNumber2 > 0 || subject.DataElementReferenceNumber2 > 0 || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceNumber2 = 3;
			subject.CodeListReference = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMinimumLength(int minimumLength, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "7";
		subject.DataElementReferenceNumber = 5;
		subject.DataElementDataType = "R";
		subject.MaximumLength = 6;
		if (minimumLength > 0)
			subject.MinimumLength = minimumLength;
		//If one is filled, all are required
		if(subject.DataElementReferenceNumber2 > 0 || subject.DataElementReferenceNumber2 > 0 || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceNumber2 = 3;
			subject.CodeListReference = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMaximumLength(int maximumLength, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "7";
		subject.DataElementReferenceNumber = 5;
		subject.DataElementDataType = "R";
		subject.MinimumLength = 4;
		if (maximumLength > 0)
			subject.MaximumLength = maximumLength;
		//If one is filled, all are required
		if(subject.DataElementReferenceNumber2 > 0 || subject.DataElementReferenceNumber2 > 0 || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceNumber2 = 3;
			subject.CodeListReference = "5";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "5", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "5", false)]
	public void Validation_AllAreRequiredDataElementReferenceNumber2(int dataElementReferenceNumber2, string codeListReference, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "7";
		subject.DataElementReferenceNumber = 5;
		subject.DataElementDataType = "R";
		subject.MinimumLength = 4;
		subject.MaximumLength = 6;
		if (dataElementReferenceNumber2 > 0)
			subject.DataElementReferenceNumber2 = dataElementReferenceNumber2;
		subject.CodeListReference = codeListReference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
