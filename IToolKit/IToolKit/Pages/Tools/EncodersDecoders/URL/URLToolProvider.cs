﻿using IToolKit.API.Interfaces;
using IToolKit.API.Attributes;

namespace IToolKit.Pages.Tools.EncodersDecoders.URL
{
    [Order(4)]
    [Parent(EncodersDecodersGroupToolProvider.InternalName)]
    internal sealed class URLToolProvider : IToolProvider
    {
        public string Header => "URL Encoder / Decoder";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => "URL";

        public string Route => "URL";

        public Type Component => typeof(URL);
    }
}
