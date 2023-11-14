using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Exiled.API.Features;
using Events = Exiled.Events;

namespace NNN
{
    public class NNN : Plugin<Config>
    {
        public override string Name => "No Nut November";
        public override string Author => "coollogan876";
        public override Version Version => new Version(1, 0, 0);
        public override Version RequiredExiledVersion => new Version(8, 3, 11);

        public static NNN Singleton;
        private EventHandlers Handler;

        public override void OnEnabled()
        {
            Singleton = this;
            Handler = new EventHandlers();
            Events.Handlers.Player.ChangingRole += Handler.OnChangingRole;
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            Events.Handlers.Player.ChangingRole -= Handler.OnChangingRole;
            Singleton = null;
            Handler = null;
            base.OnDisabled();
        }
    }
}
