namespace StarJournalGuiWpfTest.StepDefinitions
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StarJournalGuiWpfTest.Helpers;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class SaveItemSteps
    {
        private MainWindowHelper MainWindowHelper { get; set; }

        [Given(@"I have a minimal new item")]
        public void GivenIHaveAMinimalNewItem()
        {
            this.MainWindowHelper = new MainWindowHelper(ScenarioSteps.StartAppHelper);
            Assert.IsTrue(this.MainWindowHelper.CreateMinimalNewStarItem());
        }

        [When(@"I press save")]
        public void WhenIPressSave()
        {
            Assert.IsTrue(this.MainWindowHelper.SaveStarItem());
        }

        [Then(@"the item is saved")]
        [Then(@"the item cannot be saved")]
        public void ThenTheItemIsSaved()
        {
            Assert.IsFalse(this.MainWindowHelper.CanSaveStarItem());
        }

        [When(@"I add a new star item without putting entering data")]
        public void WhenIAddANewStarItemWithoutPuttingEnteringData()
        {
            this.MainWindowHelper = new MainWindowHelper(ScenarioSteps.StartAppHelper);
        }
    }
}
