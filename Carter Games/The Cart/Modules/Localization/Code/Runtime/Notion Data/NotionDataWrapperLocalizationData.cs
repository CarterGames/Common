﻿#if CARTERGAMES_CART_MODULE_LOCALIZATION && CARTERGAMES_CART_MODULE_NOTIONDATA

/*
 * Copyright (c) 2024 Carter Games
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */

using System;
using CarterGames.Cart.Core.Logs;
using CarterGames.Cart.Modules.NotionData;

namespace CarterGames.Cart.Modules.Localization
{
    /// <summary>
    /// Use to convert a localization id into its data in a NotionDataAsset through standard database parsing.
    /// </summary>
    public class NotionDataWrapperLocalizationData : NotionDataWrapper<LocalizationData>
    {
        public NotionDataWrapperLocalizationData(string id) : base(id) { }

        protected override void Assign()
        {
            try
            {
                value = LocalizationManager.GetRawData(id);
            }
#pragma warning disable 0168
            catch (Exception e)
            {
                CartLogger.LogWarning<LogCategoryModules>($"Unable to wrap {id} as Localized text, make sure the id exists.");
                throw;
            }
#pragma warning restore
        }
    }
}

#endif