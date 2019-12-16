////namespace StarJournalGuiWpfTest.UnitTests
////{
////    using Microsoft.VisualStudio.TestTools.UnitTesting;
////    using StarJournalEntities.StarBusinessEntities;
////    using StarJournalGuiWpf;
////    using StarJournalUseCases.AddItem;
////    using Utilities.IdGenerator;

////    [TestClass]
////    public class StarOverviewViewModelTests
////    {
////        [TestMethod]
////        public void TestAddItemCommand()
////        {

////            // ==============================
////            // build the overview window.
////            // ==============================
////            // 1) create the businessentity.
////            var factory1 = new StarBusinessEntityFactory();
////            IStarBusinessEntity businessEntity = factory1.Create();

           

////            // 4) create the interactor.
////            var factory2 = new AddItemUsecaseFactory(new IdGeneratorClass());

////            IAddStarItemInputPort addItemInteractor = factory2.Create(businessEntity);

////            // 5) create the controller
////            IStarOverviewController controller = new StarOverviewController(addItemInteractor, null);
////            // 2 create the viewmodel
////            var viewModel = new StarOverviewViewModel(controller);

////            // 3) create the presenter
////            var presenter = new StarOverviewPresenter(viewModel);

////            addItemInteractor.BindOutputBoundary(presenter);


////            viewModel.AddItemCommand.Execute(null);

////            //// 2) vm contains a flag that it is a new item.
////            Assert.IsTrue(viewModel.NewLabel == @"New Item");
////        }
////    }
////}
