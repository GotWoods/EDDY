using System.Collections.Generic;
using System.Linq;
using Eddy.Core.Codes;
using Eddy.Core.Metadata;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;
using Xunit;

namespace Eddy.Tests.Codes;

/// <summary>Exercises <see cref="BasicValidator{T}.KnownCode"/> against the real
/// <see cref="N1_Name"/> model (EntityIdentifierCode, X12 data element 98, standard/version inferred
/// from its namespace) so the rule is proven against a generated segment, not just a synthetic one.</summary>
[Collection("CodeCatalog")]
public class KnownCodeTests
{
    private static MetadataCatalog BuildCatalogWithEntityIdentifierCodes()
    {
        var catalog = new MetadataCatalog();
        var pack = new MetadataPack { Standard = "X12", Version = "004010", Name = "test" };
        pack.Codes["98"] = new Dictionary<string, string> { ["BY"] = "Buyer" };
        catalog.AddPack(pack);
        return catalog;
    }

    [Fact]
    public void Silent_WhenNoCodeListIsLoadedForTheElement()
    {
        var previous = CodeList.Catalog;
        try
        {
            CodeList.Catalog = new MetadataCatalog(); // no packs at all
            var segment = new N1_Name { EntityIdentifierCode = "ZZ" };
            var validator = new BasicValidator<N1_Name>(segment);

            validator.KnownCode(x => x.EntityIdentifierCode, "98");

            Assert.Empty(validator.Results.Errors);
        }
        finally
        {
            CodeList.Catalog = previous;
        }
    }

    [Fact]
    public void Silent_WhenValueIsInTheLoadedList()
    {
        var previous = CodeList.Catalog;
        try
        {
            CodeList.Catalog = BuildCatalogWithEntityIdentifierCodes();
            var segment = new N1_Name { EntityIdentifierCode = "BY" };
            var validator = new BasicValidator<N1_Name>(segment);

            validator.KnownCode(x => x.EntityIdentifierCode, "98");

            Assert.Empty(validator.Results.Errors);
        }
        finally
        {
            CodeList.Catalog = previous;
        }
    }

    [Fact]
    public void Warning_WhenValueIsNotInTheLoadedList()
    {
        var previousCatalog = CodeList.Catalog;
        var previousSeverity = ValidationSettings.CodeListSeverity;
        try
        {
            CodeList.Catalog = BuildCatalogWithEntityIdentifierCodes();
            ValidationSettings.CodeListSeverity = ErrorSeverity.Warning;

            var segment = new N1_Name { EntityIdentifierCode = "ZZ" };
            var validator = new BasicValidator<N1_Name>(segment);

            validator.KnownCode(x => x.EntityIdentifierCode, "98");

            var error = Assert.Single(validator.Results.Errors);
            Assert.Equal(ErrorCodes.UnknownCodeValue, error.ErrorCode);
            Assert.Equal(ErrorSeverity.Warning, error.Severity);
            Assert.Equal("EntityIdentifierCode", error.PropertyName);
            Assert.Equal(1, error.ElementPosition);
            Assert.True(validator.Results.IsValid); // warnings alone don't invalidate the result
            Assert.True(validator.Results.HasWarnings);
        }
        finally
        {
            CodeList.Catalog = previousCatalog;
            ValidationSettings.CodeListSeverity = previousSeverity;
        }
    }

    [Fact]
    public void Error_WhenCodeListSeverityIsSetToError()
    {
        var previousCatalog = CodeList.Catalog;
        var previousSeverity = ValidationSettings.CodeListSeverity;
        try
        {
            CodeList.Catalog = BuildCatalogWithEntityIdentifierCodes();
            ValidationSettings.CodeListSeverity = ErrorSeverity.Error;

            var segment = new N1_Name { EntityIdentifierCode = "ZZ" };
            var validator = new BasicValidator<N1_Name>(segment);

            validator.KnownCode(x => x.EntityIdentifierCode, "98");

            var error = Assert.Single(validator.Results.Errors);
            Assert.Equal(ErrorSeverity.Error, error.Severity);
            Assert.False(validator.Results.IsValid);
        }
        finally
        {
            CodeList.Catalog = previousCatalog;
            ValidationSettings.CodeListSeverity = previousSeverity;
        }
    }

    [Fact]
    public void Silent_WhenValueIsEmpty()
    {
        var previous = CodeList.Catalog;
        try
        {
            CodeList.Catalog = BuildCatalogWithEntityIdentifierCodes();
            var segment = new N1_Name { EntityIdentifierCode = "" };
            var validator = new BasicValidator<N1_Name>(segment);

            validator.KnownCode(x => x.EntityIdentifierCode, "98");

            Assert.Empty(validator.Results.Errors);
        }
        finally
        {
            CodeList.Catalog = previous;
        }
    }

    [Fact]
    public void ExplicitStandardOverload_WorksWithoutNamespaceInference()
    {
        var previousCatalog = CodeList.Catalog;
        try
        {
            CodeList.Catalog = BuildCatalogWithEntityIdentifierCodes();
            var segment = new N1_Name { EntityIdentifierCode = "ZZ" };
            var validator = new BasicValidator<N1_Name>(segment);

            validator.KnownCode(x => x.EntityIdentifierCode, "X12", "98", "004010");

            Assert.Single(validator.Results.Errors);
        }
        finally
        {
            CodeList.Catalog = previousCatalog;
        }
    }
}
