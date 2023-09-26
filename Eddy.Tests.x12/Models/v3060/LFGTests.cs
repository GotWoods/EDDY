using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class LFGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LFG*z*2*vrRSs8*JOdxSoTfh74fTW*T*x";

		var expected = new LFG_HazardousInformationFinishedGoods()
		{
			Description = "z",
			HazardousClassification = "2",
			UNNAIdentificationCode = "vrRSs8",
			HazardousPlacardNotation = "JOdxSoTfh74fTW",
			PackingGroupCode = "T",
			HazardousMaterialRegulationsExceptionCode = "x",
		};

		var actual = Map.MapObject<LFG_HazardousInformationFinishedGoods>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new LFG_HazardousInformationFinishedGoods();
		//Required fields
		subject.HazardousClassification = "2";
		subject.UNNAIdentificationCode = "vrRSs8";
		subject.HazardousPlacardNotation = "JOdxSoTfh74fTW";
		//Test Parameters
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredHazardousClassification(string hazardousClassification, bool isValidExpected)
	{
		var subject = new LFG_HazardousInformationFinishedGoods();
		//Required fields
		subject.Description = "z";
		subject.UNNAIdentificationCode = "vrRSs8";
		subject.HazardousPlacardNotation = "JOdxSoTfh74fTW";
		//Test Parameters
		subject.HazardousClassification = hazardousClassification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vrRSs8", true)]
	public void Validation_RequiredUNNAIdentificationCode(string uNNAIdentificationCode, bool isValidExpected)
	{
		var subject = new LFG_HazardousInformationFinishedGoods();
		//Required fields
		subject.Description = "z";
		subject.HazardousClassification = "2";
		subject.HazardousPlacardNotation = "JOdxSoTfh74fTW";
		//Test Parameters
		subject.UNNAIdentificationCode = uNNAIdentificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JOdxSoTfh74fTW", true)]
	public void Validation_RequiredHazardousPlacardNotation(string hazardousPlacardNotation, bool isValidExpected)
	{
		var subject = new LFG_HazardousInformationFinishedGoods();
		//Required fields
		subject.Description = "z";
		subject.HazardousClassification = "2";
		subject.UNNAIdentificationCode = "vrRSs8";
		//Test Parameters
		subject.HazardousPlacardNotation = hazardousPlacardNotation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
