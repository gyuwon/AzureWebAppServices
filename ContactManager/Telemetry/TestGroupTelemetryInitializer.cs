using Microsoft.ApplicationInsights.Channel;
using Microsoft.ApplicationInsights.Extensibility;
using static System.Configuration.ConfigurationManager;

namespace ContactManager.Telemetry
{
    public class TestGroupTelemetryInitializer : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            string testGroup = AppSettings["TestGroup"] ?? "A";
            telemetry.Context.Properties["Test Group"] = testGroup;
        }
    }
}
