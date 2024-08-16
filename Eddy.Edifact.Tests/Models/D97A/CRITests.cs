using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class CRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CRI+";

		var expected = new CRI_ConsumerReferenceInformation()
		{
			ConsumerReferenceIdentification = null,
		};

		var actual = Map.MapObject<CRI_ConsumerReferenceInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredConsumerReferenceIdentification(string consumerReferenceIdentification, bool isValidExpected)
	{
		var subject = new CRI_ConsumerReferenceInformation();
		//Required fields
		//Test Parameters
		if (consumerReferenceIdentification != "") 
			subject.ConsumerReferenceIdentification = new E967_ConsumerReferenceIdentification();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
