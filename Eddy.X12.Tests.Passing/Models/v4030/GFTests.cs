using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class GFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GF*GL*c*I*5*uj*l*V*Fd*H";

		var expected = new GF_FurnishedGoodsAndServices()
		{
			ReferenceIdentificationQualifier = "GL",
			ReferenceIdentification = "c",
			ContractNumber = "I",
			MonetaryAmount = 5,
			ReferenceIdentificationQualifier2 = "uj",
			ReferenceIdentification2 = "l",
			ReleaseNumber = "V",
			ReferenceIdentificationQualifier3 = "Fd",
			ReferenceIdentification3 = "H",
		};

		var actual = Map.MapObject<GF_FurnishedGoodsAndServices>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("GL", "c", true)]
	[InlineData("GL", "", false)]
	[InlineData("", "c", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new GF_FurnishedGoodsAndServices();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "uj";
			subject.ReferenceIdentification2 = "l";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier3 = "Fd";
			subject.ReferenceIdentification3 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uj", "l", true)]
	[InlineData("uj", "", false)]
	[InlineData("", "l", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new GF_FurnishedGoodsAndServices();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "GL";
			subject.ReferenceIdentification = "c";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier3) || !string.IsNullOrEmpty(subject.ReferenceIdentification3))
		{
			subject.ReferenceIdentificationQualifier3 = "Fd";
			subject.ReferenceIdentification3 = "H";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Fd", "H", true)]
	[InlineData("Fd", "", false)]
	[InlineData("", "H", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier3(string referenceIdentificationQualifier3, string referenceIdentification3, bool isValidExpected)
	{
		var subject = new GF_FurnishedGoodsAndServices();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentificationQualifier3 = referenceIdentificationQualifier3;
		subject.ReferenceIdentification3 = referenceIdentification3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier) || !string.IsNullOrEmpty(subject.ReferenceIdentification))
		{
			subject.ReferenceIdentificationQualifier = "GL";
			subject.ReferenceIdentification = "c";
		}
		if(!string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentificationQualifier2) || !string.IsNullOrEmpty(subject.ReferenceIdentification2))
		{
			subject.ReferenceIdentificationQualifier2 = "uj";
			subject.ReferenceIdentification2 = "l";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
