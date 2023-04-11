using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class GFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GF*fq*y*B*2*x9*1*N*gC*K";

		var expected = new GF_FurnishedGoodsAndServices()
		{
			ReferenceIdentificationQualifier = "fq",
			ReferenceIdentification = "y",
			ContractNumber = "B",
			MonetaryAmount = 2,
			ReferenceIdentificationQualifier2 = "x9",
			ReferenceIdentification2 = "1",
			ReleaseNumber = "N",
			ReferenceIdentificationQualifier3 = "gC",
			ReferenceIdentification3 = "K",
		};

		var actual = Map.MapObject<GF_FurnishedGoodsAndServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("fq", "y", true)]
	[InlineData("", "y", false)]
	[InlineData("fq", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new GF_FurnishedGoodsAndServices();
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("x9", "1", true)]
	[InlineData("", "1", false)]
	[InlineData("x9", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new GF_FurnishedGoodsAndServices();
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("gC", "K", true)]
	[InlineData("", "K", false)]
	[InlineData("gC", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier3(string referenceIdentificationQualifier3, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new GF_FurnishedGoodsAndServices();
		subject.ReferenceIdentificationQualifier3 = referenceIdentificationQualifier3;
		subject.ReferenceIdentification3 = referenceIdentification3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
