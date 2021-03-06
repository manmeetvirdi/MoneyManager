﻿using System;
using Windows.UI.StartScreen;
using MoneyManager.Foundation;
using MoneyManager.Foundation.OperationContracts;

namespace MoneyManager.Business.Logic.Tile {
    public class TransferTile : Tile, ISecondTile {
        public const string Id = "AddTransferTile";

        public new bool Exists {
            get { return Exists(Id); }
        }

        public async void Create() {
            await Create(new SecondaryTile(
                Id,
                Translation.GetTranslation("AddTransferTileText"),
                "intake",
                new Uri("ms-appx:///Images/transferTileIcon.png", UriKind.Absolute),
                TileSize.Default));
        }

        public async void Remove() {
            await Remove(new SecondaryTile(Id));
        }
    }
}