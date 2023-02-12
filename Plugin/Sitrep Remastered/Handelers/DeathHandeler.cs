using Exiled.Events.EventArgs.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Enums;
using System.Net.Http;
using Exiled.API.Features;
using System.IO;

namespace Sitrep_Remastered.Handelers
{
    public class DeathHandeler
    {
        public async void OnDeath(DyingEventArgs ev)
        {
            try
            {
                string Killer = "Server";
                string KillerId = "Server";
                string KillerRole = "Server";
                string TK = "kill";
    
                if (ev.Attacker != null)
                {
                    Killer = ev.Attacker.Nickname.ToString();
                    KillerId = ev.Attacker.UserId.ToString();
                    KillerRole = ev.Attacker.Role.Name.ToString();
                }

                if (ev.DamageHandler.IsFriendlyFire)
                {
                    if (ev.Attacker.Role.Team != PlayerRoles.Team.ClassD || ev.Player.Role.Team != PlayerRoles.Team.ClassD)
                    {
                        TK = "TK";
                    }
                }

                var values = new Dictionary<string, string>
                {
                    {"Killer", Killer },
                    {"KillerId", KillerId },
                    {"KillerRole", KillerRole },
                    {"Target", ev.Player.Nickname.ToString()},
                    {"TargetId", ev.Player.UserId.ToString()},
                    {"TargetRole", ev.Player.Role.Name.ToString() },
                    {"TK", TK },
                    {"Weapon", ev.DamageHandler.DeathTranslation.LogLabel}
                };

                var content = new FormUrlEncodedContent(values);

                await PluginMain.client.PostAsync("http://127.0.0.1:6868/OnDeath", content);
            }
            catch (Exception err) {
                Log.Error(err);
            }

        }
    }
}
