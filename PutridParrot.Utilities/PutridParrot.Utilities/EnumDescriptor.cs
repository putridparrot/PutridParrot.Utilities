using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace PutridParrot.Utilities
{
    /// <summary>
    /// An extended Enum static class, includes methods as per Enum
    /// but with the capability of using attributes on the enumerated
    /// values to act as names. 
    /// </summary>
    /// <example>
    /// The developer may have:
    /// 
    /// public enum Options
    /// {
    ///    SelectDoor,
    ///    OpenDoor,
    ///    CloseDoor
    /// }
    /// 
    /// This is fine but what if you wanted to display a more human
    /// friendly name along with the values - this would be useful if 
    /// using Enum.GetNames to populate a combobox for example. But using
    /// SelectDoor is not particularily nice when a user might at least 
    /// like to see a space between Select and Door thus "Select Door".
    /// 
    /// Using EnumDescriptor and the Description attribute we can achieve this by 
    /// assigning a Description attribute to each value within the enumerated type.
    /// 
    /// i.e.
    /// public enum Options
    /// {
    ///    [Description("The select the door")]
    ///    SelectDoor,
    ///    [Description("Open your selected door")]
    ///    OpenDoor,
    ///    [Description("Close the door behind you")]
    ///    CloseDoor
    /// }
    /// </example>
    /// EnumDescriptor is broken into three main types of method, Description methods
    /// will return only the description info. stored against a enumerated value. Name
    /// methods delegate to the Enum static methods and thus return the enumerated value 
    /// as a string and DisplayName methods will return Descriptions where they exist otherwise
    /// Names. The distinction between these three types means you can use the EnumDescriptor in 
    /// place of the Enum static methods and the developer explicitly states what they want to 
    /// see.
    /// 
    /// Also the methods come in two flavours, the "standard" Enum style whereby use pass a 
    /// Type numType to the method and generic versions where the type is passed using 
    /// &lt;T&gt; style, i.e. EnumDescriptor.GetName&lt;MyEnum&gt;("None");
    public static class EnumDescriptor
    {
        /// <summary>
        /// Gets the description assigned to the enumerated type itself
        /// </summary>
        /// <example>
        /// [Description("Payment Options")]
        /// public enum PaymentOptions
        /// {
        /// }
        /// </example>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static string GetDescription(Type enumType)
        {
            object[] attrs = enumType.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return (attrs != null && attrs.Length > 0) ? ((DescriptionAttribute)attrs[0]).Description : null;

        }
        /// <summary>
        /// <see cref="GetDescription(Type)"/>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string GetDescription<T>()
        {
            return GetDescription(typeof(T));
        }
        /// <summary>
        /// Gets the description assigned to an ennumerated value via the Description
        /// attribute. Note: This will return a null if no description is found.
        /// </summary>
        /// <param name="enumType">The type to find the description</param>
        /// <param name="value">The value of the type.</param>
        /// <returns>The description if one is assigned otherwise null.</returns>
        public static string GetDescription(Type enumType, object value)
        {
            MemberInfo[] memInfo = enumType.GetMember(value.ToString());

            if (memInfo != null && memInfo.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs != null && attrs.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return null;
        }
        /// <summary>
        /// Generic version of the <see cref="GetDescription(Type, object)"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetDescription<T>(object value)
        {
            return GetDescription(typeof(T), value);
        }
        /// <summary>
        /// Gets the name of the value of the enumerated type. This will 
        /// try to return the description of the value if one exists otherwise
        /// the string representing the value is returned.
        /// </summary>
        /// <param name="enumType">The enumerated type</param>
        /// <param name="value">The value to get the description or name for.</param>
        /// <returns>The description or name for the value</returns>
        public static string GetDisplayName(Type enumType, object value)
        {
            return GetDescription(enumType, value) ?? value.ToString();
        }
        /// <summary>
        /// Generic implementation of <see cref="GetDisplayName(Type, object)"/>.
        /// </summary>
        /// <typeparam name="T">The enumerated type</typeparam>
        /// <param name="value">The value to get the display name for.</param>
        /// <returns>The displayname will be either the description of the value 
        /// or the name of the value if no description exists.</returns>
        public static string GetDisplayName<T>(object value)
        {
            return GetDisplayName(typeof(T), value);
        }
        /// <summary>
        /// <see cref="T:Enum.GetName"/>
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetName(Type enumType, object value)
        {
            return Enum.GetName(enumType, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetName<T>(object value)
        {
            return GetName(typeof(T), value);
        }
        /// <summary>
        /// Gets the array of names of the numerated values. If a value has a Description
        /// attribute assigned to it then the description is used otherwise the enumerated 
        /// value as a string is used.
        /// </summary>
        /// <param name="enumType">The enumerated type</param>
        /// <returns>A string array of the names or descriptions of the enumerated values.</returns>
        public static string[] GetDisplayNames(Type enumType)
        {
            string[] values = Enum.GetNames(enumType);
            string[] descriptions = new string[values.Length];
            for (int i = 0; i < descriptions.Length; i++)
            {
                descriptions[i] = GetDisplayName(enumType, values[i]);
            }

            return descriptions;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string[] GetDisplayNames<T>()
        {
            return GetDisplayNames(typeof(T));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static string[] GetDescriptions(Type enumType)
        {
            string[] values = Enum.GetNames(enumType);
            string[] descriptions = new string[values.Length];
            for (int i = 0; i < descriptions.Length; i++)
            {
                descriptions[i] = GetDescription(enumType, values[i]);
            }

            return descriptions;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string[] GetDescriptions<T>()
        {
            return GetDescriptions(typeof(T));
        }
        /// <summary>
        /// Parses the value against an enumerated type.
        /// </summary>
        /// <param name="enumType">The enumerated type</param>
        /// <param name="value">The value to parse</param>
        /// <returns>The value of the enumerated type</returns>
        public static object ParseDisplayName(Type enumType, string value)
        {
            return ParseDisplayName(enumType, value, false);
        }

        /// <summary>
        /// Parses the value against an enumerated type.
        /// </summary>
        /// <param name="value">The value to parse</param>
        /// <returns>The value of the enumerated type</returns>
        public static T ParseDisplayName<T>(string value)
        {
            return (T)ParseDisplayName(typeof(T), value, false);
        }
        /// <summary>
        /// Parses the value against an enumerated type using or ignoring the case sensitivity
        /// of the value. The will try to parse the value looking at the description of the
        /// enumerated value or against the value string itself. Thus if the description isn't 
        /// the same as the value but the value's string is, then a match will be found.
        /// </summary>
        /// <param name="enumType">The enumerated type</param>
        /// <param name="value">The value to parse</param>
        /// <param name="ignoreCase">Sets whether to ignore case or not</param>
        /// <returns>The value of the enumerated type</returns>
        public static object ParseDisplayName(Type enumType, string value, bool ignoreCase)
        {
            StringComparison comparison = (ignoreCase) ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture;
            Array array = Enum.GetValues(enumType);
            foreach (object o in array)
            {
                if (o.ToString().Equals(value, comparison) || GetDisplayName(enumType, o).Equals(value, comparison))
                {
                    return o;
                }
            }
            throw new ArgumentException(String.Format("Requested value '{0}' was not found.", value));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T ParseDisplayName<T>(string value, bool ignoreCase)
        {
            return (T)ParseDisplayName(typeof(T), value, ignoreCase);
        }
        /// <summary>
        /// Parses the value against an enumerated type.
        /// </summary>
        /// <param name="enumType">The enumerated type</param>
        /// <param name="value">The value representing the description</param>
        /// <returns>The value within the enumerated type</returns>
        public static object ParseDescription(Type enumType, string value)
        {
            return ParseDescription(enumType, value, false);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T ParseDescription<T>(string value)
        {
            return (T)ParseDescription(typeof(T), value);
        }
        /// <summary>
        /// Parses the value against the description only
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static object ParseDescription(Type enumType, string value, bool ignoreCase)
        {
            StringComparison comparison = (ignoreCase) ? StringComparison.CurrentCultureIgnoreCase : StringComparison.CurrentCulture;
            Array array = Enum.GetValues(enumType);
            foreach (object o in array)
            {
                string description = GetDescription(enumType, o);
                if (!String.IsNullOrEmpty(description))
                {
                    if (description.Equals(value, comparison))
                    {
                        return o;
                    }
                }
            }
            throw new ArgumentException(String.Format("Requested value '{0}' was not found.", value));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T ParseDescription<T>(string value, bool ignoreCase)
        {
            return (T)ParseDescription(typeof(T), value, ignoreCase);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static object Parse(Type enumType, string value)
        {
            return Enum.Parse(enumType, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T Parse<T>(string value)
        {
            return (T)Parse(typeof(T), value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static object Parse(Type enumType, string value, bool ignoreCase)
        {
            return Enum.Parse(enumType, value, ignoreCase);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static T Parse<T>(string value, bool ignoreCase)
        {
            return (T)Parse(typeof(T), value, ignoreCase);
        }

        /// <summary>
        /// Tests whether the value is defined on the value of the enumerated type
        /// or on it's description
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDisplayNameDefined(Type enumType, object value)
        {
            try
            {
                ParseDisplayName(enumType, value.ToString());
                return true;
            }
            catch (ArgumentException)
            {
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDisplayNameDefined<T>(object value)
        {
            return IsDisplayNameDefined(typeof(T), value);
        }
        /// <summary>
        /// Tests whether the value is defined on the description of the enumerated
        /// type.
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDescriptionDefined(Type enumType, object value)
        {
            try
            {
                ParseDescription(enumType, value.ToString());
                return true;
            }
            catch (ArgumentException)
            {
            }
            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDescriptionDefined<T>(object value)
        {
            return IsDescriptionDefined(typeof(T), value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDefined(Type enumType, object value)
        {
            return Enum.IsDefined(enumType, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDefined<T>(object value)
        {
            return IsDefined(typeof(T), value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Type GetUnderlyingType(Type enumType)
        {
            return Enum.GetUnderlyingType(enumType);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Type GetUnderlyingType<T>()
        {
            return GetUnderlyingType(typeof(T));
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string Format(Type enumType, object value, string format)
        {
            return Enum.Format(enumType, value, format);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static string Format<T>(object value, string format)
        {
            return Format(typeof(T), value, format);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static Array GetValues(Type enumType)
        {
            return Enum.GetValues(enumType);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Array GetValues<T>()
        {
            return GetValues(typeof(T));
        }
    }

}
