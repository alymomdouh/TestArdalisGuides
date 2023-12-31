﻿using System.Reflection;

namespace ListingStronglyTypedEnumOptions
{
    public class Role
    {
        public static Role Author { get; } = new Role(0, "Author");
        public static Role Editor { get; } = new Role(1, "Editor");
        public static Role Administrator { get; } = new Role(2, "Administrator");
        public static Role SalesRep { get; } = new Role(3, "Sales Representative");

        public string Name { get; private set; }
        public int Value { get; private set; }

        private Role(int val, string name)
        {
            Value = val;
            Name = name;
        }

        public static IEnumerable<Role> List()
        {
            // alternately, use a dictionary keyed by value
            return new[] { Author, Editor, Administrator, SalesRep };
        }

        public static Role FromString(string roleString)
        {
            return List().Single(r => String.Equals(r.Name, roleString, StringComparison.OrdinalIgnoreCase));
        }

        public static Role FromValue(int value)
        {
            return List().Single(r => r.Value == value);
        }
        public static List<Role> AllRoles
        {
            get
            {
                return _allRoles;
            }
        }
        // if you move this above the static properties, it fails
        private static List<Role> _allRoles = ListRoles();
        private static List<Role> ListRoles()
        {
            return typeof(Role).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Where(p => p.PropertyType == typeof(Role))
                .Select(pi => (Role)pi.GetValue(null, null))
                .OrderBy(p => p.Name)
                .ToList();
        }
    }

}
