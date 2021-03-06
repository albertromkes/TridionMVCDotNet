﻿using System;
namespace Tridion.Extensions.DynamicDelivery.ContentModel.Factories
{
    public interface ITaxonomyFactory
    {
        bool TryGetKeyword(string categoryUriToLookIn, string keywordName, out IKeyword keyword);
        IKeyword GetKeyword(string categoryUriToLookIn, string keywordName);
    }
}
