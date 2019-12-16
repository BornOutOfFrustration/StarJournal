namespace StarJournalGuiWpfTest.StepDefinitions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StarJournalGuiWpfTest.Helpers;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class ScenarioSteps
    {
        internal static IApp StartAppHelper { get; set; }

        [BeforeScenario]
        public void StartApplication()
        {
            StartAppHelper = new AppHelper();
            _ = StartAppHelper.Initialize();
        }

        [AfterScenario]
        public void StopApplication()
        {
            _ = StartAppHelper.Stop(out _);

        }
    }
}
