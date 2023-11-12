using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class E30Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E30*X*9*i*8*1*Z*1*8*s";

		var expected = new E30_DataElementAttributes()
		{
			MaintenanceOperationCode = "X",
			DataElementReferenceNumber = 9,
			DataElementDataTypeCode = "i",
			MinimumLength = 8,
			MaximumLength = 1,
			Description = "Z",
			NoteIdentificationNumber = 1,
			DataElementReferenceNumber2 = 8,
			CodeListReference = "s",
		};

		var actual = Map.MapObject<E30_DataElementAttributes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.DataElementReferenceNumber = 9;
		subject.DataElementDataTypeCode = "i";
		subject.MinimumLength = 8;
		subject.MaximumLength = 1;
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		//If one is filled, all are required
		if(subject.DataElementReferenceNumber2 > 0 || subject.DataElementReferenceNumber2 > 0 || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceNumber2 = 8;
			subject.CodeListReference = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredDataElementReferenceNumber(int dataElementReferenceNumber, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "X";
		subject.DataElementDataTypeCode = "i";
		subject.MinimumLength = 8;
		subject.MaximumLength = 1;
		if (dataElementReferenceNumber > 0)
			subject.DataElementReferenceNumber = dataElementReferenceNumber;
		//If one is filled, all are required
		if(subject.DataElementReferenceNumber2 > 0 || subject.DataElementReferenceNumber2 > 0 || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceNumber2 = 8;
			subject.CodeListReference = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredDataElementDataTypeCode(string dataElementDataTypeCode, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "X";
		subject.DataElementReferenceNumber = 9;
		subject.MinimumLength = 8;
		subject.MaximumLength = 1;
		subject.DataElementDataTypeCode = dataElementDataTypeCode;
		//If one is filled, all are required
		if(subject.DataElementReferenceNumber2 > 0 || subject.DataElementReferenceNumber2 > 0 || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceNumber2 = 8;
			subject.CodeListReference = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMinimumLength(int minimumLength, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "X";
		subject.DataElementReferenceNumber = 9;
		subject.DataElementDataTypeCode = "i";
		subject.MaximumLength = 1;
		if (minimumLength > 0)
			subject.MinimumLength = minimumLength;
		//If one is filled, all are required
		if(subject.DataElementReferenceNumber2 > 0 || subject.DataElementReferenceNumber2 > 0 || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceNumber2 = 8;
			subject.CodeListReference = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMaximumLength(int maximumLength, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "X";
		subject.DataElementReferenceNumber = 9;
		subject.DataElementDataTypeCode = "i";
		subject.MinimumLength = 8;
		if (maximumLength > 0)
			subject.MaximumLength = maximumLength;
		//If one is filled, all are required
		if(subject.DataElementReferenceNumber2 > 0 || subject.DataElementReferenceNumber2 > 0 || !string.IsNullOrEmpty(subject.CodeListReference))
		{
			subject.DataElementReferenceNumber2 = 8;
			subject.CodeListReference = "s";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "s", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "s", false)]
	public void Validation_AllAreRequiredDataElementReferenceNumber2(int dataElementReferenceNumber2, string codeListReference, bool isValidExpected)
	{
		var subject = new E30_DataElementAttributes();
		subject.MaintenanceOperationCode = "X";
		subject.DataElementReferenceNumber = 9;
		subject.DataElementDataTypeCode = "i";
		subject.MinimumLength = 8;
		subject.MaximumLength = 1;
		if (dataElementReferenceNumber2 > 0)
			subject.DataElementReferenceNumber2 = dataElementReferenceNumber2;
		subject.CodeListReference = codeListReference;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
