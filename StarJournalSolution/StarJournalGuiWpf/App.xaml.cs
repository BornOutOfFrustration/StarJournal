using System.Windows;
using BusinessEntitiesRepository;
using StarJournalEntities.StarBusinessEntities;
using StarJournalUseCases.AddItem;
using StarJournalUseCases.SaveItem;
using Utilities.IdGenerator;

namespace StarJournalGuiWpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // ==============================
            // build the overview window.
            // ==============================
            // 1) create the factories and their created classes.
            var factory1 = new StarBusinessEntityFactory();
            var starBusinessEntity = factory1.Create();

            var factory2 = new AddItemUsecaseFactory(new IdGeneratorClass());
            var addItemInteractor = factory2.Create(starBusinessEntity);

            var gatewayFactory = new StarRepositoryGatewaySqlServerFactory();
            var gateway = gatewayFactory.CreateSqlServer();

            var saveItemUsecaseFactory = new SaveItemFactory();
            var saveItemInteractor = saveItemUsecaseFactory.Create(starBusinessEntity, gateway);


            // 2 create the controller
            IStarOverviewController controller = new StarOverviewController(addItemInteractor, saveItemInteractor);
            
            // 2 create the viewmodel
            var viewModel = new StarOverviewViewModel(controller);

            // 3) create the presenter
            var presenter = new StarOverviewPresenter(viewModel);

            addItemInteractor.BindOutputBoundary(presenter);
            saveItemInteractor.BindOutputBoundary(presenter);
            
            var view = new MainWindow
            {
                DataContext = viewModel
            };

            view.Show();
        }
    }
}
