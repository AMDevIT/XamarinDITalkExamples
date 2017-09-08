using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xamarin_DIF
{
    public interface IApplicationStateManager
    {
        #region Properties

        String Description
        {
            get;            
        }

        int StateID
        {
            get;
        }

        #endregion
    }
}
