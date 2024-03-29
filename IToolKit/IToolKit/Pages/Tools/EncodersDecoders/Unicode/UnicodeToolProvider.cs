﻿using IToolKit.API.Interfaces;
using IToolKit.API.Attributes;

namespace IToolKit.Pages.Tools.EncodersDecoders.Unicode
{
    [Order(3)]
    [Parent(EncodersDecodersGroupToolProvider.InternalName)]
    internal sealed class UnicodeToolProvider : IToolProvider
    {
        public string Header => "Unicode Encode / Decode";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => "Unicode";

        public string Route => "Unicode";

        public Type Component => typeof(Unicode);
    }
}
