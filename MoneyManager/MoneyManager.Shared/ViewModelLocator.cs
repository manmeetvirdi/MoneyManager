using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using MoneyManager.Business;
using MoneyManager.Business.Helper;
using MoneyManager.Business.Manager;
using MoneyManager.Business.Repositories;
using MoneyManager.Business.Services;
using MoneyManager.Business.ViewModels;
using MoneyManager.DataAccess.DataAccess;
using MoneyManager.Foundation.Model;
using MoneyManager.Foundation.OperationContracts;
using MoneyManager.Views;

namespace MoneyManager {
    public class ViewModelLocator {
        static ViewModelLocator() {
            DatabaseLogic.CreateDatabase();

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            //DataAccess
            SimpleIoc.Default.Register<IDataAccess<Account>, AccountDataAccess>();
            SimpleIoc.Default.Register<IDataAccess<Category>, CategoryDataAccess>();
            SimpleIoc.Default.Register<IDataAccess<FinancialTransaction>, TransactionDataAccess>();
            SimpleIoc.Default.Register<IDataAccess<RecurringTransaction>, RecurringTransactionDataAccess>();
            SimpleIoc.Default.Register<SettingDataAccess>();

            //Logic
            SimpleIoc.Default.Register<IUserNotification, UserNotification>();
            SimpleIoc.Default.Register<IJsonService, JsonService>();
            SimpleIoc.Default.Register<IBackupService, OneDriveBackupService>();
            SimpleIoc.Default.Register(CreateNavigationService);
            SimpleIoc.Default.Register<Utilities>();
            SimpleIoc.Default.Register<Backup>();

            //Manager
            SimpleIoc.Default.Register<LicenseManager>();
            SimpleIoc.Default.Register<CurrencyManager>();

            //Repositories
            SimpleIoc.Default.Register<ITransactionRepository, TransactionRepository>();
            SimpleIoc.Default.Register<IRecurringTransactionRepository, RecurringTransactionRepository>();
            SimpleIoc.Default.Register<IAccountRepository, AccountRepository>();
            SimpleIoc.Default.Register<IRepository<Category>, CategoryRepository>();

            //ViewModels
            SimpleIoc.Default.Register<AddAccountViewModel>();
            SimpleIoc.Default.Register<AccountListUserControlViewModel>();
            SimpleIoc.Default.Register<AddTransactionViewModel>();
            SimpleIoc.Default.Register<BalanceViewModel>();
            SimpleIoc.Default.Register<CategoryListViewModel>();
            SimpleIoc.Default.Register<TransactionListViewModel>();
            SimpleIoc.Default.Register<TileSettingsViewModel>();
            SimpleIoc.Default.Register<GeneralSettingViewModel>();
            SimpleIoc.Default.Register<SettingDefaultsViewModel>();
            SimpleIoc.Default.Register<SelectCurrencyViewModel>();
            SimpleIoc.Default.Register<StatisticViewModel>();
            SimpleIoc.Default.Register<BackupViewModel>();
        }

        #region Logic

        private static INavigationService CreateNavigationService() {
            var navigationService = new NavigationService();
            navigationService.Configure("LicenseView", typeof (LicenseView));

            return navigationService;
        }

        #endregion

        #region DataAccess

        public IAccountRepository AccountRepository{
            get { return ServiceLocator.Current.GetInstance<IAccountRepository>(); }
        }

        public IRepository<Category> CategoryRepository {
            get { return ServiceLocator.Current.GetInstance<IRepository<Category>>(); }
        }

        public ITransactionRepository TransactionRepository {
            get { return ServiceLocator.Current.GetInstance<ITransactionRepository>(); }
        }

        public IRecurringTransactionRepository RecurringTransactionRepository {
            get { return ServiceLocator.Current.GetInstance<IRecurringTransactionRepository>(); }
        }

        public SettingDataAccess SettingDataAccess {
            get { return ServiceLocator.Current.GetInstance<SettingDataAccess>(); }
        }

        #endregion DataAccess

        #region Views

        public AddAccountViewModel AddAccountView {
            get { return ServiceLocator.Current.GetInstance<AddAccountViewModel>(); }
        }

        public AccountListUserControlViewModel AccountListUserControlView {
            get { return ServiceLocator.Current.GetInstance<AccountListUserControlViewModel>(); }
        }

        public AddTransactionViewModel AddTransactionView {
            get { return ServiceLocator.Current.GetInstance<AddTransactionViewModel>(); }
        }

        public BalanceViewModel BalanceView {
            get { return ServiceLocator.Current.GetInstance<BalanceViewModel>(); }
        }

        public CategoryListViewModel CategoryListView {
            get { return ServiceLocator.Current.GetInstance<CategoryListViewModel>(); }
        }

        public TransactionListViewModel TransactionListView {
            get { return ServiceLocator.Current.GetInstance<TransactionListViewModel>(); }
        }

        public TileSettingsViewModel TileSettingsView {
            get { return ServiceLocator.Current.GetInstance<TileSettingsViewModel>(); }
        }

        public GeneralSettingViewModel GeneralSettingView {
            get { return ServiceLocator.Current.GetInstance<GeneralSettingViewModel>(); }
        }

        public SettingDefaultsViewModel SettingDefaultsView {
            get { return ServiceLocator.Current.GetInstance<SettingDefaultsViewModel>(); }
        }

        public SelectCurrencyViewModel SelectCurrencyView {
            get { return ServiceLocator.Current.GetInstance<SelectCurrencyViewModel>(); }
        }

        public StatisticViewModel StatisticView {
            get { return ServiceLocator.Current.GetInstance<StatisticViewModel>(); }
        }

        public BackupViewModel BackupView {
            get { return ServiceLocator.Current.GetInstance<BackupViewModel>(); }
        }

        #endregion Views
    }
}