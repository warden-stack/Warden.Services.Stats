﻿using Warden.Common.Nancy;

namespace Warden.Services.Stats.Modules
{
    public abstract class ModuleBase : ApiModuleBase
    {
        protected ModuleBase(string modulePath = "") : base(modulePath)
        {
        }
    }
}