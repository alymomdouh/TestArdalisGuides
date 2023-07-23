using System.ComponentModel.DataAnnotations;

namespace ListingStronglyTypedEnumOptions
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Console.WriteLine("Roles:");
            foreach (var role in Role.List())
            {
                Console.WriteLine($"Role: {role.Name} ({role.Value})");
                /*
                 * Roles:
                    Role: Author (0)
                    Role: Editor (1)
                    Role: Administrator (2)
                    Role: Sales Representative (3)
                 */
            }


            Console.WriteLine("Roles 2:");

            foreach (var role in Role.AllRoles)
            {
                Console.WriteLine($"Role: {role.Name} ({role.Value})");
                /*
                 * Roles 2:
                    Role: Administrator (2)
                    Role: Author (0)
                    Role: Editor (1)
                    Role: Sales Representative (3)
                 */
            }

            Console.WriteLine("Job Titles:");

            foreach (var title in JobTitle.AllTitles)
            {
                Console.WriteLine($"Title: {title.Name} ({title.Value})");
                /*
                 * Job Titles:
                    Title: Author (0)
                    Title: Editor (1)
                    Title: Administrator (2)
                    Title: Sales Representative (3)
                 */
            }

            Console.WriteLine("--Smart Enums--");
            Console.WriteLine("Smart Foo:");
            foreach (var smartFoo in SmartFoo.List)
            {
                Console.WriteLine($"Foo: {smartFoo}");
                /*
                 * Smart Foo:
                    Foo: Foo A (1)
                    Foo: Foo B (2)
                 */
            }
            Console.WriteLine("Smart Bar:");
            foreach (var smartBar in SmartBar.List)
            {
                Console.WriteLine($"Bar: {smartBar}");
                /*
                 * Smart Bar:
                    Bar: Bar A (1)
                    Bar: Bar B (2)
                    Bar: Bar C (3)
                 */
            }
            Console.WriteLine("Smart Baz:");
            foreach (var smartBaz in SmartBaz.List)
            {
                Console.WriteLine($"Baz: {smartBaz}");
                /*
                 Smart Baz:
                    Baz: Baz A (Baz Val 1)
                    Baz: Baz B (Baz Val 2)
                 */
            }

            Console.WriteLine($"One: {Utility.GetEnumName(Types.One)}");
            //One: One
            Console.WriteLine($"MultipleEnumsName: {Utility.GetMultipleEnumsName<Types>("1,2,3")}");
            //MultipleEnumsName: One,Two,Three
            Console.WriteLine($"Display Name: {Utility.GetEnumDisplayName(Types2.One_Two)}");
            // Display Name: One Two
            Console.WriteLine($"Multiple Display Name: " +
                $"{Utility.GetMultipleEnumsDisplayName<Types2>("12,23,45")}");
            //Multiple Display Name: One Two, Two Three, Four Five
            Console.ReadLine();
        }
    }
    public enum Types
    {
        One = 1,
        Two,
        Three,
        Four,
        Five,
        Six
    }
    public enum Types2
    {
        [Display(Name = "One Two")]
        One_Two = 12,
        [Display(Name = "Two Three")]
        Two_Three = 23,
        [Display(Name = "Four Five")]
        Four_Five = 45,
        [Display(Name = "Five Six ")]
        Five_Six = 56,
        [Display(Name = "One Six")]
        One_Six = 16
    }
}