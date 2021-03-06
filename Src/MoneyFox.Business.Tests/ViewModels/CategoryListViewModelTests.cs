﻿using System.Collections.Generic;
using MoneyFox.Business.ViewModels;
using MoneyFox.Foundation.Interfaces;
using MoneyFox.Foundation.Tests;
using MoneyFox.Service.DataServices;
using MoneyFox.Service.Pocos;
using Moq;
using MvvmCross.Test.Core;
using Xunit;

namespace MoneyFox.Business.Tests.ViewModels
{
    [Collection("MvxIocCollection")]
    public class CategoryListViewModelTests : MvxIoCSupportingTest
    {

        [Fact]
        public void Loaded_PropertiesSet()
        {
            var categoryRepoSetup = new Mock<ICategoryService>();
            categoryRepoSetup.Setup(x => x.GetAllCategories()).ReturnsAsync(() => new List<Category>
            {
                new Category {Data = {Name = string.Empty}}
            });

            var vm = new CategoryListViewModel(categoryRepoSetup.Object, new Mock<IModifyDialogService>().Object, new Mock<IDialogService>().Object);
            vm.LoadedCommand.Execute();

            vm.Source.ShouldNotBeNull();
        }
    }
}