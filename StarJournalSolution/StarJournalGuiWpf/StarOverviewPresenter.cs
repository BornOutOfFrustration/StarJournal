namespace StarJournalGuiWpf
{
    using System.Collections.Generic;
    using StarJournalUseCases.AddItem;
    using StarJournalUseCases.Dto;
    using StarJournalUseCases.SaveItem;

    public sealed class StarOverviewPresenter : IStarItemOutputPort, IStarItemSavedOutputPort
    {
        private readonly StarOverviewViewModel ViewModel;

        public StarOverviewPresenter(StarOverviewViewModel viewModel)
        {
            ViewModel = viewModel;
        }

        void IStarItemOutputPort.Created(StarItemDto data) {
            this.ViewModel.NewLabel = data.IsNew ? @"New Item" : "";
            this.ViewModel.StarName = data.ItemName;
            this.ViewModel.IsItemSaveable = true;
        }

        void IStarItemSavedOutputPort.Notify(StarItemDto data)
        {
            this.ViewModel.NewLabel = @"Saved";
            this.ViewModel.StarName = data.ItemName;
            this.ViewModel.IsItemSaveable = false;
        }

        public List<int> StarObjects { get; } = new List<int>();

        public int NumberOfStarObjects { get; }
    }
}
