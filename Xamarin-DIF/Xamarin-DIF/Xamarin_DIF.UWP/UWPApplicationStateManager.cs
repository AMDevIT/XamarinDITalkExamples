using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.System.Profile;

[assembly: Xamarin.Forms.Dependency(typeof(Xamarin_DIF.UWP.UWPApplicationStateManager))]
namespace Xamarin_DIF.UWP
{
    public class UWPApplicationStateManager
       : IApplicationStateManager
    {
        #region Consts

        private const string HardwareIDTypeApi = "Windows.System.Profile.HardwareIdentification";

        #endregion

        #region Properties

        public string DeviceID
        {
            get;
            private set;
        }

        public String Description
        {
            get;
            private set;
        }

        public int StateID
        {
            get;
            private set;
        }

        #endregion

        #region .ctor

        public UWPApplicationStateManager()
        {
            this.DeviceID = this.GetDeviceID();
        }

        #endregion

        #region Methods

        private String GetDeviceID()
        {
            HardwareToken hardwareToken = null;
            IBuffer tokenBuffer = null;
            DataReader tokenReader = null;
            byte[] token = null;
            string result = "Cannot retrieve hardware ID";

            if (Windows.Foundation.Metadata.ApiInformation.IsTypePresent(HardwareIDTypeApi))
            {
                hardwareToken = HardwareIdentification.GetPackageSpecificToken(null);
                tokenBuffer = hardwareToken.Id;
                tokenReader = DataReader.FromBuffer(tokenBuffer);
                token = new byte[tokenBuffer.Length];
                tokenReader.ReadBytes(token);
                tokenReader.Dispose();

                result = BitConverter.ToString(token).Replace("-", "");
            }
            return result;
        }

        #endregion
    }
}
