namespace ListingStronglyTypedEnumOptions
{
    public class JobTitle
    {
        // this must appear before other static instance types.
        public static List<JobTitle> AllTitles { get; } = new List<JobTitle>();
        public static JobTitle Author { get; } = new JobTitle(0, "Author");
        public static JobTitle Editor { get; } = new JobTitle(1, "Editor");
        public static JobTitle Administrator { get; } = new JobTitle(2, "Administrator");
        public static JobTitle SalesRep { get; } = new JobTitle(3, "Sales Representative");
        public string Name { get; private set; }
        public int Value { get; private set; }
        private JobTitle(int val, string name)
        {
            Value = val;
            Name = name;
            AllTitles.Add(this);
        } 
        public static JobTitle FromString(string roleString)
        {
            return AllTitles.Single(r => String.Equals(r.Name, roleString, StringComparison.OrdinalIgnoreCase));
        }

        public static JobTitle FromValue(int value)
        {
            return AllTitles.Single(r => r.Value == value);
        }
    }
}
