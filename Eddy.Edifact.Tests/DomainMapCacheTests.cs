using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eddy.Core.Attributes;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D08B;

namespace Eddy.Edifact.Tests
{
    public class SampleClass
    {
        [SectionPosition(1)] public BGM_BeginningOfMessage BeginningOfMessage { get; set; } = new();
        [SectionPosition(6)] public List<SegmentGroup1> Group1 { get; set; } = new();
        [SectionPosition(7)] public List<SegmentGroup2> Group2 { get; set; } = new();
    }

    public class SegmentGroup1
    {
        [SectionPosition(1)] public DOC_DocumentMessageDetails DocumentMessageDetails { get; set; } = new();
        [SectionPosition(2)] public List<DTM_DateTimePeriod> DAteTimePeriod { get; set; } = new();
    }

    public class SegmentGroup2
    {
        [SectionPosition(1)] public RFF_Reference Reference { get; set; } = new();
        [SectionPosition(2)] public List<DTM_DateTimePeriod> DAteTimePeriod { get; set; } = new();
    }

    public class DomainMapCacheTests
    {
        [Fact]
        public void GetMapTest()
        {
            // Arrange
            var type = typeof(SampleClass);
            // Act
            var result = DomainMapCache.CreatePropertyMap(typeof(SampleClass));
            // Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
            Assert.Equal(typeof(BGM_BeginningOfMessage), result[0].MatchingSegmentType);
            Assert.False(result[0].IsListType);
            Assert.Equal(typeof(DOC_DocumentMessageDetails), result[1].MatchingSegmentType);
            Assert.True(result[1].IsListType);
            Assert.Equal(typeof(RFF_Reference), result[2].MatchingSegmentType);
            Assert.True(result[2].IsListType);
        }
    }
}
