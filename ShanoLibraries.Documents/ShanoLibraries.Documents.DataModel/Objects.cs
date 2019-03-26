namespace ShanoLibraries.Documents.DataModel
{
    public static class Objects
    {
        public static bool Equal(object x, object y)
        {
            return x?.Equals(y) ?? (y == null);
        }
    }
}
