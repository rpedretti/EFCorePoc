using EFCore.POC.ChildComplexType.Infrastructure;
using EFCore.POC.ChildComplexType.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Template10.Common;
using Template10.Services.NavigationService;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static Template10.Common.BootStrapper;

namespace EFCore.POC.ChildComplexType
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : BootStrapper
    {
        public App()
        {
            InitializeComponent();

            using (var db = new DataAccess.Local.POCContext())
            {
                db.Database.Migrate();
                var serviceProvider = db.GetInfrastructure<IServiceProvider>();
                var loggerFactory = serviceProvider.GetService<ILoggerFactory>();
                loggerFactory.AddProvider(new EFLoggerProvider());
            }

        }

        public override async Task OnStartAsync(StartKind startKind, IActivatedEventArgs args)
        {
            var service = new RefundTypeService();

            await service.UpdateRefundTypes();

            if (startKind == StartKind.Launch)
            {
                NavigationService.Navigate(typeof(MainPage));
            }
        }
    }
}
