using Exiled.Events.EventArgs.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sitrep_Remastered.Handelers
{
    internal class Decontamination
    { 
    public async void OnDecontamination(DecontaminatingEventArgs ev)
        {
            try 
            {
                var values = new Dictionary<string, string>
                {

                };

                var content = new FormUrlEncodedContent(values);


                await PluginMain.client.PostAsync("http://127.0.0.1:6868/OnDecontamination", content);
            }
            catch { 
            }
        }

}
}
