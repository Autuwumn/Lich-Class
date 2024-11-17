﻿using ClassesManagerReborn;
using Lich.Cards;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lich.Cards
{
    class LichClassClass : ClassHandler
    {
        internal static string name = "Lich";

        public override IEnumerator Init()
        {
            while (!(LichClassCard.card && TankyerPhy.card)) yield return null;
            ClassesRegistry.Register(LichClassCard.card, CardType.Entry, 1);
            ClassesRegistry.Register(TankyerPhy.card, CardType.Card, 1);
        }
    }
}