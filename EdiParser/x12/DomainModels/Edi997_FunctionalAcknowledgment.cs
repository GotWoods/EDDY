using EdiParser.x12.Models;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.DomainModels;

public class Edi997_FunctionalAcknowledgment
{
    public void LoadFrom(x12Document document)
    {
        var section = document.Sections[0]; //it is possible a document contains multiple instructions

        var ak2GroupRule = new GroupingRule("AK2", typeof(AK2_TransactionSetResponseHeader), typeof(AK5_TransactionSetResponseTrailer));
        ak2GroupRule.AddSubRule("AK3", typeof(AK3_DataSegmentNote), typeof(AK4_DataElementNote));

        var groupedReader = new GroupedSectionReader(section);
        var grouped = groupedReader.Read(ak2GroupRule);
        for (var rowIndex = 0; rowIndex < grouped.Segments.Count; rowIndex++)
        {
            var currentSegment = grouped.Segments[rowIndex];

            switch (currentSegment)
            {
                // case AK1 b1:
                //     break;
                // case AK9 ak9:
                //     break;
            }
        }
    }
}