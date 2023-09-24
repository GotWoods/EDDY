using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class E10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "E10*9*ZqO*zK*u*1";

		var expected = new E10_TransactionSetGrouping()
		{
			MaintenanceOperationCode = "9",
			TransactionSetIdentifierCode = "ZqO",
			FunctionalIdentifierCode = "zK",
			Description = "u",
			NoteIdentificationNumber = 1,
		};

		var actual = Map.MapObject<E10_TransactionSetGrouping>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredMaintenanceOperationCode(string maintenanceOperationCode, bool isValidExpected)
	{
		var subject = new E10_TransactionSetGrouping();
		subject.TransactionSetIdentifierCode = "ZqO";
		subject.FunctionalIdentifierCode = "zK";
		subject.Description = "u";
		subject.MaintenanceOperationCode = maintenanceOperationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZqO", true)]
	public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
	{
		var subject = new E10_TransactionSetGrouping();
		subject.MaintenanceOperationCode = "9";
		subject.FunctionalIdentifierCode = "zK";
		subject.Description = "u";
		subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zK", true)]
	public void Validation_RequiredFunctionalIdentifierCode(string functionalIdentifierCode, bool isValidExpected)
	{
		var subject = new E10_TransactionSetGrouping();
		subject.MaintenanceOperationCode = "9";
		subject.TransactionSetIdentifierCode = "ZqO";
		subject.Description = "u";
		subject.FunctionalIdentifierCode = functionalIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new E10_TransactionSetGrouping();
		subject.MaintenanceOperationCode = "9";
		subject.TransactionSetIdentifierCode = "ZqO";
		subject.FunctionalIdentifierCode = "zK";
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
