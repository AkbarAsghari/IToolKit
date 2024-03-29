﻿using IToolKit.API.Interfaces;
using IToolKit.API.Attributes;

namespace IToolKit.Pages.Tools.EncodersDecoders.JWT
{
    [Order(6)]
    [Parent(EncodersDecodersGroupToolProvider.InternalName)]
    internal sealed class JWTToolProvider : IToolProvider
    {
        public string Header => "JWT Decoder";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => "JWT";

        public string Route => "JWT";

        public Type Component => typeof(JWT);
    }
}
