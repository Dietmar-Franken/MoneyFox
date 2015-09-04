﻿using System.Collections.ObjectModel;
using System.Linq;
using MoneyManager.Core.DataAccess;
using MoneyManager.Foundation.Model;
using MoneyManager.Foundation.OperationContracts;

namespace MoneyManager.Core.Manager
{
    public class DefaultManager
    {
        private readonly IRepository<Account> accountRepository;
        private readonly SettingDataAccess settings;

        public DefaultManager(IRepository<Account> accountRepository, SettingDataAccess settings)
        {
            this.accountRepository = accountRepository;
            this.settings = settings;
        }

        public Account GetDefaultAccount()
        {
            if (accountRepository.Data == null)
            {
                accountRepository.Data = new ObservableCollection<Account>();
            }

            if (accountRepository.Data.Any() && settings.DefaultAccount != -1)
            {
                return accountRepository.Data.FirstOrDefault(x => x.Id == settings.DefaultAccount);
            }

            if (accountRepository.Data.Any())
            {
                return accountRepository.Data.First();
            }

            return accountRepository.Selected ?? new Account();
        }
    }
}