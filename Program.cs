using System;
using System.ComponentModel;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Months.January);
            Console.WriteLine((int) Months.Febrary + 1);
            Console.WriteLine(Months.March.ToString());
            Console.WriteLine(GetDescription(Months.April));
            Console.WriteLine(Months.May.ExtEnumGetDescription());
            Console.ReadLine();
        }

        /// <summary>
        /// Russian version captions
        /// </summary>
        /// <remarks>
        /// For correct operation it is necessary to use the [Description ("Name")] attribute for each element of the enumeration.
        /// </remarks>
        /// <param name="enumElement">element</param>
        /// <returns>caption element</returns>
        private static string GetDescription(Enum enumElement)
        {
            var type = enumElement.GetType();

            var memInfo = type.GetMember(enumElement.ToString());
            if (memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                    return ((DescriptionAttribute) attrs[0]).Description;
            }

            return enumElement.ToString();
        }

        /// <summary>
        /// Months
        /// </summary>
        public enum Months
        {
            /// <summary>
            /// January
            /// </summary>
            [Description("январь")] January,

            /// <summary>
            /// Febrary
            /// </summary>
            [Description("февраль")] Febrary,

            /// <summary>
            /// March
            /// </summary>
            [Description("март")] March,

            /// <summary>
            /// April
            /// </summary>
            [Description("апрель")] April,

            /// <summary>
            /// May
            /// </summary>
            [Description("май")] May,

            /// <summary>
            /// June
            /// </summary>
            [Description("июнь")] June,

            /// <summary>
            /// July
            /// </summary>
            [Description("июль")] July,

            /// <summary>
            /// August
            /// </summary>
            [Description("август")] August,

            /// <summary>
            /// September
            /// </summary>
            [Description("сентябрь")] September,

            /// <summary>
            /// October
            /// </summary>
            [Description("октябрь")] October,

            /// <summary>
            /// November
            /// </summary>
            [Description("ноябрь")] November,

            /// <summary>
            /// December
            /// </summary>
            [Description("декабрь")] December
        }
    }

    internal static class ExtEnum
    {
        public static string ExtEnumGetDescription(this Enum enumElement)
        {
            var type = enumElement.GetType();

            var memInfo = type.GetMember(enumElement.ToString());
            if (memInfo.Length > 0)
            {
                var attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs.Length > 0)
                    return ((DescriptionAttribute) attrs[0]).Description;
            }

            return enumElement.ToString();

        }
    }
}

