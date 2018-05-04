using System;
using System.ComponentModel;
using System.Reflection;

namespace StarWarsChallenge
{
    public class ErrorHandler
    {
        /// <summary>
        /// An incomplete list of error messages. 
        /// </summary>
        public enum ErrorCodes : uint
        {
            [Description("All OK.")]
            OK = 200,

            [Description("You are not authorized to be in this area!")]
            Unauthorized = 401,

            [Description("These are not the droids you are looking for.")]
            NotFound = 404,

            [Description("You must enter a valid distance. The distance may be too large and may take you out of the Galaxey.")]
            InvalidDistance = 9998,

            [Description("Darth Vader has been dispatched")]
            Default = 9999,
        }

        /// <summary>
        /// Get the custom description for the error
        /// </summary>
        /// <param name="value"></param>
        /// <returns>
        /// Description
        /// </returns>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static string ReturnErrorDescription(int errorCode)
        {
            return GetEnumDescription((ErrorCodes)errorCode);
        }
    }
}
