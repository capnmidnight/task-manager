using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TaskManager.BusinessLogic
{
    /// <summary>
    /// A smattering of methods that are useful in a variety of areas
    /// in multiple projects.
    /// </summary>
    public static class Utility
    {
        private static readonly double METERS_PER_INCH = 0.0254;
        private static readonly double INCHES_PER_FOOT = 12.0;

        /// <summary>
        /// Returns true if the DataSet has been filled
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static bool HasData(DataSet data)
        {
            return data != null && data.Tables.Count > 0 && data.Tables[0].Rows.Count > 0;
        }

        /// <summary>
        /// Generates a semi-unique integer number for use as an ID number
        /// </summary>
        /// <returns></returns>
        public static int NextID()
        {
            return (int)DateTime.Now.Subtract(new DateTime(2008, 1, 1)).Ticks;
        }

        /// <summary>
        /// Loop through an exception stack trace and build a simplified error message that
        /// may give a better clue as to what is going on.
        /// </summary>
        /// <param name="exp">The exception that occured</param>
        /// <returns>the summary</returns>
        public static string PrepareErrorMessage(Exception exp)
        {
            StringBuilder sb = new StringBuilder();
            while (exp != null)
            {
                string site = (exp.TargetSite == null) ? "unknown" : exp.TargetSite.Name;
                string msg = (exp.Message == null) ? "no message" : exp.Message;
                sb.AppendFormat("{0}:{1} >> {2}\r\n", site, exp.GetType().Name, msg);
                exp = exp.InnerException;
            }
            return sb.ToString().Trim();
        }

        private static double Truncate(double value, int sigFigs)
        {
            double k = Math.Pow(10, sigFigs);
            return Math.Round(k * value) / k;
        }

        public static double InchesToFeet(double inches)
        {
            return inches / INCHES_PER_FOOT;
        }

        public static double FeetToInches(double feet)
        {
            return feet * INCHES_PER_FOOT;
        }

        public static double InchesToFeet(double inches, int sigFigs)
        {
            return Truncate(InchesToFeet(inches), sigFigs);
        }

        public static double InchesToMeters(double inches)
        {
            return inches * METERS_PER_INCH;
        }

        public static double InchesToMeters(double inches, int sigFigs)
        {
            return Truncate(InchesToMeters(inches), sigFigs);
        }

        public static double MetersToInches(double meters)
        {
            return meters / METERS_PER_INCH;
        }
    }
}
