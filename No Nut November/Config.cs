using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNN
{
    public class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;

        [Description("Is Debug enabled")]
        public bool Debug { get; set; } = false;

        [Description("Allow RA to spawn 173")]
        public bool AllowForce173 = true;

    }
}
