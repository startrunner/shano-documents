namespace ShanoLibraries.Documents.DataModel
{
    class RegistryBase
    {
        long idCounter = 1;
        protected long GetNextID() => idCounter++;
    }
}
