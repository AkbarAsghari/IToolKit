﻿using IToolKit.API.Attributes;

namespace IToolKit.Pages.Tools.EncodersDecoders
{
    [Name(InternalName)]
    [Order(0)]
    internal sealed class EncodersDecodersGroupToolProvider : GroupToolProviderBase
    {
        internal const string InternalName = "EncodersDecoders";

        public override string Header => "Encoders / Decoders";

        public override string MenuDisplayName => "Encode / Decode";

        public override string Description => throw new NotImplementedException();

        public override string Route => "EncodersDecoders";

        public override Type Component => throw new NotImplementedException();
    }
}
