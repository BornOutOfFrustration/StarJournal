namespace StarJournalGuiWpfTest.Helpers
{
    using System;
    using StarJournalGuiWpfTest.PageObjects;

    internal class MainWindowHelper
    {
        private readonly MainWindowPageObject MainWindowPageObject;

        public MainWindowHelper(IApp app)
        {
            this.MainWindowPageObject = new MainWindowPageObject(app);
        }

        public bool HasEmptyMainWindow()
        {
            // Empty window is when no items are available.
            return this.MainWindowPageObject.CountNumberOfStarItems() == 0;
        }

        public bool HasNewStarItem()
        {
            bool newLabel = this.MainWindowPageObject.NewLabelText() == @"New Item";
            newLabel = newLabel && this.MainWindowPageObject.NameText() == String.Empty;
            
            return newLabel;
        }

        public bool CanAddStarItems()
        {
            // The star items can be added when the button is enabled.
            return this.MainWindowPageObject.AddButtonEnabled();
        }

        public void AddStarItem()
        {
            this.MainWindowPageObject.ClickAddButton();
        }

        public bool SaveStarItem()
        {
            if (!this.CanSaveStarItem())
            {
                return false;
            }

            this.MainWindowPageObject.ClickSaveButton();
            return true;
        }

        public bool CanSaveStarItem()
        {
            return this.MainWindowPageObject.SaveButtonEnabled();
        }

        public bool CreateMinimalNewStarItem()
        {
            this.MainWindowPageObject.ClickAddButton();
            if (!this.HasNewStarItem())
            {
                return false;
            }

            this.MainWindowPageObject.NameText("My Name");
            return true;
        }
    }
}
