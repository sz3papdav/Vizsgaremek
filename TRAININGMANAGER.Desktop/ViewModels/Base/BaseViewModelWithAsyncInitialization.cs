using TRAININGMANAGER.Desktop.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRAININGMANAGER.desktop.ViewModels.Base
{
    public class BaseViewModelWithAsyncInitialization : BaseViewModel, IAsyncInitialization
    {
        public virtual Task InitializeAsync()
        {
            return Task.CompletedTask;
        }
    }
}
