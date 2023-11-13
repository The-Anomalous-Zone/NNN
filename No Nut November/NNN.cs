using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Exiled.API.Enums;
using Exiled.Events.EventArgs.Player;
using PlayerRoles;

namespace NNN
{
    public class EventHandlers
    {
        private List<RoleTypeId> ScpRoles = new List<RoleTypeId> 
        {
            RoleTypeId.Scp049,
            RoleTypeId.Scp096,
            RoleTypeId.Scp106,
            RoleTypeId.Scp939,
            RoleTypeId.Scp3114,
        };
        private RoleTypeId GetAvailableScp()
        {
            RoleTypeId chosen = RoleTypeId.None;
            ScpRoles.ShuffleList();
            foreach (RoleTypeId r in ScpRoles)
            {
                if (Player.Get(r).Count() < 1)
                {
                    chosen = r;
                    break;
                }
            }
            if (chosen == RoleTypeId.None)
                chosen = ScpRoles.First();
            return chosen;
        }
        public void OnChangingRole(ChangingRoleEventArgs ev)
        {
            if (ev.NewRole == RoleTypeId.Scp173 && DateTime.Now.Month == 11)
            {
                if (ev.Reason == SpawnReason.ForceClass && NNN.Singleton.Config.AllowForce173)
                {
                    return;
                }
                ev.NewRole = GetAvailableScp();
            }
        }
    }
}
