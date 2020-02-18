using System;
namespace BurgerMonkeys.Tools
{
    public static partial class Generator
    {
        /// <summary>
        /// Method to return name initials characters
        /// </summary>
        /// <param name="name">Name to get initials characters</param>
        /// <returns>Return name initials characters</returns>
        public static string GetNameInitials(this string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null");

            var names = name.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (names.Length == 1)
                return names[0][0].ToString();
            if (names.Length > 1)
                return names[0][0].ToString() + names[names.Length - 1][0].ToString();

            return null;
        }
    }
}
