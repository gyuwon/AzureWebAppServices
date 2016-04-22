using System.Web.Mvc;
using Microsoft.ApplicationInsights;

namespace ContactManager.Filters
{
    public class ApplicationInsightsHandleErrorAttribute : HandleErrorAttribute
    {
        private static TelemetryClient _telemetryClient;

        public static TelemetryClient TelemetryClient
        {
            get
            {
                if (_telemetryClient == null)
                    _telemetryClient = new TelemetryClient();

                return _telemetryClient;
            }
        }

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext?.Exception != null)
                TelemetryClient.TrackException(filterContext.Exception);

            base.OnException(filterContext);
        }
    }
}
