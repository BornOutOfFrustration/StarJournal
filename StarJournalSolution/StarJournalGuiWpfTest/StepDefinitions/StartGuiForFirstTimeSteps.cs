namespace StarJournalGuiWpfTest.StepDefinitions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StarJournalGuiWpfTest.Helpers;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class StartGuiForFirstTimeSteps
    {
        private MainWindowHelper MainWindowHelper { get; set; }

        // For additional details on SpecFlow step definitions see http://go.specflow.org/doc-stepdef
        [When(@"I start the program for the first time")]
        public void WhenIStartTheProgramForTheFirstTime()
        {
            this.MainWindowHelper = new MainWindowHelper(ScenarioSteps.StartAppHelper);
        }

        [Then(@"the program starts and shows a virgin screen")]
        public void ThenTheProgramStartsAndShowsAVirginScreen()
        {
            Assert.IsTrue(this.MainWindowHelper.HasEmptyMainWindow());
            Assert.IsTrue(this.MainWindowHelper.CanAddStarItems());
        }
    }
}
