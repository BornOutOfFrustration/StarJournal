namespace StarJournalGuiWpf
{
    using System;
    using System.ComponentModel;
    using System.Windows.Input;
    using Utilities.Commands;

    public class StarOverviewViewModel : INotifyPropertyChanged
    {
        private readonly IStarOverviewController Controller;
        private string LocalNewLabel = String.Empty;
        private string LocalStarName = String.Empty;
        private bool LocalIsItemSaveable;
        private readonly DelegateCommand LocalSaveItemCommand;

        public event PropertyChangedEventHandler PropertyChanged;

        public StarOverviewViewModel(IStarOverviewController controller)
        {
            this.Controller = controller;   
            this.AddItemCommand = new DelegateCommand(this.AddStaritem, this.CanAddItem);
            this.LocalSaveItemCommand = new DelegateCommand(this.SaveStarItem, this.CanSaveItem);            
        }

        public ICommand AddItemCommand { get; }
        public ICommand SaveItemCommand { get { return this.LocalSaveItemCommand; } }

        private void SaveStarItem()
        {
            this.Controller.SaveItem(this.LocalStarName);
        }

        private void AddStaritem()
        {
            this.Controller.AddStarItem();
        }

        private bool CanAddItem()
        {
            return true;
        }

        private bool CanSaveItem()
        {
            return this.IsItemSaveable;
        }

        public bool IsItemSaveable {
            get { return this.LocalIsItemSaveable; }
            set {
                if (this.LocalIsItemSaveable != value)
                {
                    this.LocalIsItemSaveable = value;
                    this.LocalSaveItemCommand.RaiseCanExecuteChanged();
                    this.OnPropertyChanged(nameof(this.IsItemSaveable));
                }
            }
        }

        public string NewLabel 
        {
            get { return this.LocalNewLabel; }
            set 
            {
                if(this.LocalNewLabel != value)
                {
                    this.LocalNewLabel = value;
                    this.OnPropertyChanged(nameof(this.NewLabel));
                }
            }
        }        

        public string StarName {
            get { return this.LocalStarName; }
            set {
                if (this.LocalStarName != value)
                {
                    this.LocalStarName = value;
                    this.OnPropertyChanged(nameof(this.StarName));
                }
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            var eventArgs = new PropertyChangedEventArgs(propertyName);
            this.PropertyChanged?.Invoke(this, eventArgs);
            // eventArgs = null;
        }
    }
}
