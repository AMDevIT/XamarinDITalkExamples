using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin_DIF.Common
{
    [ContentProperty("Source")]
    public class ImageResourceExtension 
        : IMarkupExtension
    {
        #region Properties

        public string Source
        {
            get;
            set;
        }

        #endregion

        #region Methods

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)            
                return null;            
            
            var imageSource = ImageSource.FromResource(Source);
            return imageSource;
        }

        #endregion
    }
}
