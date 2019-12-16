namespace StarJournalGuiWpfTest.StepDefinitions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StarJournalGuiWpfTest.Helpers;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class AddItemSteps
    {        
        private MainWindowHelper MainWindowHelper { get; set; }

        [Given(@"I am ready to add a new star item")]
        public void GivenIAmReadyToAddANewStarItem()
        {
            this.MainWindowHelper = new MainWindowHelper(ScenarioSteps.StartAppHelper);
        }

        [When(@"I add a new star item")]
        public void WhenIAddANewStarItem()
        {
            this.MainWindowHelper.AddStarItem();
        }

        [Then(@"the new star item is shown on the screen")]
        public void ThenTheNewStarItemIsShownOnTheScreen()
        {            
            Assert.IsTrue(this.MainWindowHelper.HasNewStarItem());
        }
    }
}