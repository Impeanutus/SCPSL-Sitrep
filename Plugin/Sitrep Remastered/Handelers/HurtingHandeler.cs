using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sitrep_Remastered.Handelers
{
    internal class HurtingHandeler
    {
        public async void OnHurt(HurtingEventArgs ev)
        {
            try
            {
            if (ev.DamageHandler.IsFriendlyFire)
                {
                if (ev.Attacker.Role.Team != PlayerRoles.Team.ClassD || ev.Player.Role.Team != PlayerRoles.Team.ClassD)
                    {


                var values = new Dictionary<string, string>
                {
                    {"Attacker", ev.Attacker.Nickname },
                    {"AttackerId", ev.Attacker.UserId },
                    {"AttackerRole", ev.Attacker.Role.Name },
                    {"Player", ev.Player.Nickname },
                    {"PlayerId", ev.Player.UserId },
                    {"PlayerRole", ev.Player.Role.Name },
                    {"Item", ev.DamageHandler.DeathTranslation.LogLabel }
                };

                var content = new FormUrlEncodedContent(values);


                await PluginMain.client.PostAsync("http://127.0.0.1:6868/OnHurt", content);

                    }
                }
            }
            catch (Exception ex) 
            {
                Log.Error(ex);
            }
        }

    }
}
