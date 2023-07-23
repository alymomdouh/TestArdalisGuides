namespace ListingStronglyTypedEnumOptions
{
    public class SmartFoo : SmartEnum<SmartFoo, int>
    {
        public static SmartFoo A { get; } = new SmartFoo("Foo A", 1);
        public static SmartFoo B { get; } = new SmartFoo("Foo B", 2);

        private SmartFoo(string name, int value)
            : base(name, value)
        { }
    }

    public class SmartBar : SmartEnum<SmartBar, int>
    {
        public static SmartBar A { get; } = new SmartBar("Bar A", 1);
        public static SmartBar B { get; } = new SmartBar("Bar B", 2);
        public static SmartBar C { get; } = new SmartBar("Bar C", 3);

        private SmartBar(string name, int value)
            : base(name, value)
        { }
    }

    public class SmartBaz : SmartEnum<SmartBaz, string>
    {
        public static SmartBaz A { get; } = new SmartBaz("Baz A", "Baz Val 1");
        public static SmartBaz B { get; } = new SmartBaz("Baz B", "Baz Val 2");

        private SmartBaz(string name, string value)
            : base(name, value)
        { }
    }
}
