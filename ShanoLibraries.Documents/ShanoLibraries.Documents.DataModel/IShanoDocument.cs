using System;

namespace ShanoLibraries.Documents.DataModel
{
    public interface IShanoDocument
    {
        bool HasSelection(out ShanoDocumentPointer firstSelected, out ShanoDocumentPointer lastSelected);
        bool HasCaret(out ShanoDocumentPointer itemAfterCaret);
        bool PointersEqual(ShanoDocumentPointer x, ShanoDocumentPointer y);

        ShanoDocumentPointer PointerToNext(ShanoDocumentPointer pointer);
        ShanoDocumentPointer PointerToPrevious(ShanoDocumentPointer pointer);

        Tag DocumentStart { get; }
        Tag DocumentEnd { get; }

        void InsertBeforeTag(Tag tag, object state, out Tag inserted);
        void InsertAfterTag(Tag tag, object state, out Tag inserted);

        void EncloseRangeIn(
            Tag rangeStart, Tag rangeEnd, 
            object leftState, object rightState, 
            out Tag leftInserted, out Tag rightInserted
        );

        void RegisterMatchingTagTypePair(Type openingType, Type closingType);
    }
}
