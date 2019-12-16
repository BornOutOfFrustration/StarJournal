namespace StarJournalGuiWpfTest.Maps
{
    using FlaUI.Core;
    using FlaUI.Core.AutomationElements;
    using FlaUI.Core.AutomationElements.Infrastructure;
    using FlaUI.UIA3;
    using System;

    public class MainWindowUiMap
    {
        private readonly Window MainWindow;

        public MainWindowUiMap(Application app)
        {
            var uiAutomation = new UIA3Automation();

            this.MainWindow = app.GetMainWindow(uiAutomation, TimeSpan.FromSeconds(1));
            Window[] x = app.GetAllTopLevelWindows(uiAutomation);

            
            if(this.MainWindow == null && x.Length > 0)
            {
                this.MainWindow = x[0];
            }
            if(this.MainWindow == null)
            {
                throw new NullReferenceException("GetmainWindow returned null");
            }
        }

        public ListBox StarItemsListView()
        {
            AutomationElement starItemList = this.MainWindow.FindFirstChild("StarItemsList");
            return starItemList.AsListBox();
        }

        public Button AddButton()
        {
            AutomationElement addButton = this.MainWindow.FindFirstChild("AddButton");            
            return addButton.AsButton();
        }

        public Button SaveButton()
        {
            AutomationElement saveButton = this.MainWindow.FindFirstChild("SaveButton");
            return saveButton.AsButton();
        }

        public Label NewLabel()
        {
            this.MainWindow.Focus();
            AutomationElement newLabel = this.MainWindow.FindFirstChild("NewLabel");
            return newLabel.AsLabel();
        }

        public TextBox StarNameText()
        {
            AutomationElement starItemName = this.MainWindow.FindFirstChild("StarItemName");
            return starItemName.AsTextBox();
        }
    }
}
