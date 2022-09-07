using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Utils;

namespace eShopOnWeb.Test.Support
{
    [Binding]
    class Hooks
    {
        static AventStack.ExtentReports.ExtentReports extent;
        static AventStack.ExtentReports.ExtentTest feature;
        AventStack.ExtentReports.ExtentTest scenario, step;
        static string reportpath = System.IO.Directory.GetParent(@"../../../").FullName
            + Path.DirectorySeparatorChar + "Result"
            + Path.DirectorySeparatorChar + "Result" + DateTime.Now.ToString("ddmmyyyy HHmmss");

        [BeforeTestRun]
        public static void BeforeTestRun() {
            ExtentHtmlReporter htmlReport = new ExtentHtmlReporter(reportpath);
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReport);
        
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext context) {
            feature = extent.CreateTest(context.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext context)
        {
            scenario = feature.CreateNode(context.ScenarioInfo.Title);

        }

        [BeforeStep]
        public void BeforeStep() {
            step = scenario;

        }

        [AfterStep]
        public void AfterStep(ScenarioContext context)
        {
            if (context.TestError == null) {
                step.Log(AventStack.ExtentReports.Status.Pass, context.StepContext.StepInfo.Text);
            } else if (context.TestError != null) {
                //Log any exception encountered during execution
                String errorMessage = context.TestError.Message;
                String errorType = context.TestError.GetType().Name;
                step.Log(AventStack.ExtentReports.Status.Fail, context.StepContext.StepInfo.Text + " : "+Environment.NewLine + errorType + " : " + Environment.NewLine + errorMessage);

            }

        }

        [AfterFeature]
        public static void AfterFeatureAttribute()
        {
            extent.Flush();
        }

    }
}
