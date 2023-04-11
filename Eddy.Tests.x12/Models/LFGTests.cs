using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LFGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LFG*5*b*Cg9ZVm*JIoZpzIdtTl83M*0*d";

		var expected = new LFG_HazardousInformationFinishedGoods()
		{
			Description = "5",
			HazardousClassificationCode = "b",
			UNNAIdentificationCode = "Cg9ZVm",
			HazardousPlacardNotationCode = "JIoZpzIdtTl83M",
			PackingGroupCode = "0",
			HazardousMaterialRegulationsExceptionCode = "d",
		};

		var actual = Map.MapObject<LFG_HazardousInformationFinishedGoods>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new LFG_HazardousInformationFinishedGoods();
		subject.HazardousClassificationCode = "b";
		subject.UNNAIdentificationCode = "Cg9ZVm";
		subject.HazardousPlacardNotationCode = "JIoZpzIdtTl83M";
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredHazardousClassificationCode(string hazardousClassificationCode, bool isValidExpected)
	{
		var subject = new LFG_HazardousInformationFinishedGoods();
		subject.Description = "5";
		subject.UNNAIdentificationCode = "Cg9ZVm";
		subject.HazardousPlacardNotationCode = "JIoZpzIdtTl83M";
		subject.HazardousClassificationCode = hazardousClassificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Cg9ZVm", true)]
	public void Validation_RequiredUNNAIdentificationCode(string uNNAIdentificationCode, bool isValidExpected)
	{
		var subject = new LFG_HazardousInformationFinishedGoods();
		subject.Description = "5";
		subject.HazardousClassificationCode = "b";
		subject.HazardousPlacardNotationCode = "JIoZpzIdtTl83M";
		subject.UNNAIdentificationCode = uNNAIdentificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JIoZpzIdtTl83M", true)]
	public void Validation_RequiredHazardousPlacardNotationCode(string hazardousPlacardNotationCode, bool isValidExpected)
	{
		var subject = new LFG_HazardousInformationFinishedGoods();
		subject.Description = "5";
		subject.HazardousClassificationCode = "b";
		subject.UNNAIdentificationCode = "Cg9ZVm";
		subject.HazardousPlacardNotationCode = hazardousPlacardNotationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
