using System;
using System.Collections.Generic;

namespace ShanoLibraries.Documents.DataModel
{
    class ShanoDocument : IShanoDocument
    {
        readonly Dictionary<Type, Type> closingTypesByOpening = new Dictionary<Type, Type>();
        readonly Dictionary<Type, Type> openingTypesByClosing = new Dictionary<Type, Type>();

        public Tag DocumentStart { get; } = new Tag(state: DocumentBoundary.DocumentStart);
        public Tag DocumentEnd { get; } = new Tag(state: DocumentBoundary.DocumentEnd);

        public ShanoDocument()
        {
            DocumentStart.Next = DocumentEnd;
            DocumentEnd.Previous = DocumentStart;
        }

        public void EncloseRangeIn(
            Tag left, Tag right,
            object leftState, object rightState,
            out Tag leftInserted, out Tag rightInserted
        )
        {
            if(left.IsDocumentStart || left.IsDocumentEnd || right.IsDocumentStart || right.IsDocumentEnd)
            {
                throw new InvalidOperationException("Enclosing DocumentStart and DocumentEnd is not allowed.");
            }

            throw new NotImplementedException();
        }

        public bool HasCaret(out ShanoDocumentPointer itemAfterCaret)
        { itemAfterCaret = default; return false; }

        public bool HasSelection(out ShanoDocumentPointer firstSelected, out ShanoDocumentPointer lastSelected)
        { firstSelected = lastSelected = default; return false; }

        public void InsertAfterTag(Tag tag, object state, out Tag inserted)
        {
            if (tag.IsDocumentEnd) throw new InvalidOperationException("Inserting after DocumentEnd is not allowed.");

            throw new NotImplementedException();
        }

        public void InsertBeforeTag(Tag tag, object state, out Tag inserted)
        {
            if (tag.IsDocumentStart) throw new InvalidOperationException("Inserting before DocumentStart is not allowed.");

            throw new NotImplementedException();
        }

        public bool PointersEqual(ShanoDocumentPointer x, ShanoDocumentPointer y) => ReferenceEquals(x.Tag, y.Tag);

        public ShanoDocumentPointer PointerToNext(ShanoDocumentPointer pointer)
        {
            if (pointer.Tag.IsDocumentEnd) throw new InvalidOperationException("Moving after DocumentEnd is not allowed.");
            return new ShanoDocumentPointer { Tag = pointer.Tag.Next };
        }
        public ShanoDocumentPointer PointerToPrevious(ShanoDocumentPointer pointer)
        {
            if (pointer.Tag.IsDocumentStart) throw new NotImplementedException("Moving before DocumentStart is not allowed.");
            return new ShanoDocumentPointer { Tag = pointer.Tag.Previous };
        }
        public void RegisterMatchingTagTypePair(Type openingType, Type closingType)
        {
            closingTypesByOpening[openingType] = closingType;
            openingTypesByClosing[closingType] = openingType;
        }

        void NormalizeTagRange(Tag start, Tag end)
        {

        }
    }

}

