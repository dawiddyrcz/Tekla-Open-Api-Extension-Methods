using Tekla.Structures.Model;

namespace TeklaOpenAPIExtension
{
    public static class ModelObjectExtensions
    {
        public static int GetIntReportProperty(this ModelObject modelObject, string name)
        {
            int value = int.MinValue;
            modelObject.GetReportProperty(name, ref value);
            return value;
        }

        public static double GetDoobleReportProperty(this ModelObject modelObject, string name)
        {
            double value = int.MinValue;
            modelObject.GetReportProperty(name, ref value);
            return value;
        }

        public static string GetStringReportProperty(this ModelObject modelObject, string name)
        {
            string value = string.Empty;
            modelObject.GetReportProperty(name, ref value);
            return value;
        }
    }
}
