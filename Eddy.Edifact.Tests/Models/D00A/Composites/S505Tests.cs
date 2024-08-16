using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S505Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "X:S";

		var expected = new S505_ServiceCharacterForSignature()
		{
			ServiceCharacterForSignatureQualifier = "X",
			ServiceCharacterForSignature = "S",
		};

		var actual = Map.MapComposite<S505_ServiceCharacterForSignature>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredServiceCharacterForSignatureQualifier(string serviceCharacterForSignatureQualifier, bool isValidExpected)
	{
		var subject = new S505_ServiceCharacterForSignature();
		//Required fields
		subject.ServiceCharacterForSignature = "S";
		//Test Parameters
		subject.ServiceCharacterForSignatureQualifier = serviceCharacterForSignatureQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredServiceCharacterForSignature(string serviceCharacterForSignature, bool isValidExpected)
	{
		var subject = new S505_ServiceCharacterForSignature();
		//Required fields
		subject.ServiceCharacterForSignatureQualifier = "X";
		//Test Parameters
		subject.ServiceCharacterForSignature = serviceCharacterForSignature;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
