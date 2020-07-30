using TSM = Tekla.Structures.Model;

namespace TeklaOpenAPIExtension
{
    public static class ModelObjectExtensions
    {
        /// <summary>Get int report property from this model object</summary>
        /// <param name="name">Name of the report property</param>
        /// <returns>Return value of report property or int.MinValue if not fided report property</returns>
        public static int GetIntegerReportProperty(this TSM.ModelObject modelObject, string name)
        {
            int value = int.MinValue;
            modelObject.GetReportProperty(name, ref value);
            return value;
        }

        /// <summary>Get double report property from this model object</summary>
        /// <param name="name">Name of the report property</param>
        /// <returns>Return value of report property or int.MinValue if not fided report property</returns>
        public static double GetDoubleReportProperty(this TSM.ModelObject modelObject, string name)
        {
            double value = int.MinValue;
            modelObject.GetReportProperty(name, ref value);
            return value;
        }

        /// <summary>Get string report property from this model object</summary>
        /// <param name="name">Name of the report property</param>
        /// <returns>Return value of report property or string.Empty if not fided report property</returns>
        public static string GetStringReportProperty(this TSM.ModelObject modelObject, string name)
        {
            string value = string.Empty;
            modelObject.GetReportProperty(name, ref value);
            return value;
        }
    }
}
