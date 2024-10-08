﻿using IToolKit.API.Interfaces;
using IToolKit.API.Attributes;
using IToolKit.Pages.Tools.EncodersDecoders.HTML;

namespace IToolKit.Pages.Tools.Generators.Hash
{
    [Parent(GeneratorsGroupToolProvider.InternalName)]
    [Order(1)]
    internal sealed class HashToolProvider : IToolProvider
    {
        public string Header => "Hash";

        public string Description => throw new NotImplementedException();

        public string MenuDisplayName => Header;
        
        public string Route => "Hash";

        public Type Component => typeof(Hash);
    }
}
