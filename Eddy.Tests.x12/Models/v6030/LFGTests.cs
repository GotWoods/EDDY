using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class LFGTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LFG*M*l*rkBBzP*VaRi7KJTxv04Ja*O*W";

		var expected = new LFG_HazardousInformationFinishedGoods()
		{
			Description = "M",
			HazardousClassificationCode = "l",
			UNNAIdentificationCode = "rkBBzP",
			HazardousPlacardNotationCode = "VaRi7KJTxv04Ja",
			PackingGroupCode = "O",
			HazardousMaterialRegulationsExceptionCode = "W",
		};

		var actual = Map.MapObject<LFG_HazardousInformationFinishedGoods>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredDescription(string description, bool isValidExpected)
	{
		var subject = new LFG_HazardousInformationFinishedGoods();
		//Required fields
		subject.HazardousClassificationCode = "l";
		subject.UNNAIdentificationCode = "rkBBzP";
		subject.HazardousPlacardNotationCode = "VaRi7KJTxv04Ja";
		//Test Parameters
		subject.Description = description;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredHazardousClassificationCode(string hazardousClassificationCode, bool isValidExpected)
	{
		var subject = new LFG_HazardousInformationFinishedGoods();
		//Required fields
		subject.Description = "M";
		subject.UNNAIdentificationCode = "rkBBzP";
		subject.HazardousPlacardNotationCode = "VaRi7KJTxv04Ja";
		//Test Parameters
		subject.HazardousClassificationCode = hazardousClassificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rkBBzP", true)]
	public void Validation_RequiredUNNAIdentificationCode(string uNNAIdentificationCode, bool isValidExpected)
	{
		var subject = new LFG_HazardousInformationFinishedGoods();
		//Required fields
		subject.Description = "M";
		subject.HazardousClassificationCode = "l";
		subject.HazardousPlacardNotationCode = "VaRi7KJTxv04Ja";
		//Test Parameters
		subject.UNNAIdentificationCode = uNNAIdentificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VaRi7KJTxv04Ja", true)]
	public void Validation_RequiredHazardousPlacardNotationCode(string hazardousPlacardNotationCode, bool isValidExpected)
	{
		var subject = new LFG_HazardousInformationFinishedGoods();
		//Required fields
		subject.Description = "M";
		subject.HazardousClassificationCode = "l";
		subject.UNNAIdentificationCode = "rkBBzP";
		//Test Parameters
		subject.HazardousPlacardNotationCode = hazardousPlacardNotationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
