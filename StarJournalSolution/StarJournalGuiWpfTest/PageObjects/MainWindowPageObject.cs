namespace StarJournalGuiWpfTest.PageObjects
{
    using StarJournalGuiWpfTest.ApplicationAccess;
    using StarJournalGuiWpfTest.Maps;
    using FlaUI.Core;
    using System;
    using StarJournalGuiWpfTest.Helpers;

    internal class MainWindowPageObject
    {
        private readonly MainWindowUiMap MainWindowMap;

        internal MainWindowPageObject(IApp application)
        {
            this.MainWindowMap = new MainWindowUiMap(application.App.App);
        }

        public int CountNumberOfStarItems()
        {
            FlaUI.Core.AutomationElements.ListBox listView = this.MainWindowMap.StarItemsListView();
            return listView.Items.Length;
        }

        public bool AddButtonEnabled()
        {
            FlaUI.Core.AutomationElements.Button addButton = this.MainWindowMap.AddButton();
            return addButton.IsEnabled;
        }

        public void ClickAddButton()
        {
            FlaUI.Core.AutomationElements.Button addButton = this.MainWindowMap.AddButton();
            addButton.Focus();
            addButton.Click();
        }

        public bool SaveButtonEnabled()
        {
            FlaUI.Core.AutomationElements.Button saveButton = this.MainWindowMap.SaveButton();
            return saveButton.IsEnabled;
        }

        public void ClickSaveButton()
        {
            FlaUI.Core.AutomationElements.Button saveButton = this.MainWindowMap.SaveButton();
            saveButton.Focus();
            saveButton.Click();
            //this.LocalApplication.WaitWhileBusy(TimeSpan.FromSeconds(5));
        }

        public string NewLabelText()
        {
            FlaUI.Core.AutomationElements.Label newLabel = this.MainWindowMap.NewLabel();
            return newLabel.Text;
        }

        public string NameText()
        {
            FlaUI.Core.AutomationElements.TextBox nameTextBox = this.MainWindowMap.StarNameText();
            return nameTextBox.Text;
        }

        public void NameText(string name)
        {
            FlaUI.Core.AutomationElements.TextBox nameTextBox = this.MainWindowMap.StarNameText();
            nameTextBox.Focus();
            nameTextBox.Text = name;
            //this.LocalApplication.WaitWhileBusy(TimeSpan.FromSeconds(5));
        }
    }
}
