using Exiled.API.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sitrep_Remastered.Handelers
{
    internal class WaitingForPlayers
    {
        public async void OnWaiting()
        {
            try
            {
                var values = new Dictionary<string, string>
                {

                };

                var content = new FormUrlEncodedContent(values);


                await PluginMain.client.PostAsync("http://127.0.0.1:6868/OnWaiting", content);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

    }
}
