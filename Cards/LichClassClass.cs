using ClassesManagerReborn;
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
            while (!(LichClassCard.card && TankyerPhy.card && SelfSafety.card && LifestealConnection.card && UndeadBody.card && EmergencyEvac.card && EmpBlasts.card)) yield return null;
            ClassesRegistry.Register(LichClassCard.card, CardType.Entry, 1);
            ClassesRegistry.Register(TankyerPhy.card, CardType.Card, LichClassCard.card);
            ClassesRegistry.Register(SelfSafety.card, CardType.Card, LichClassCard.card, 1);
            ClassesRegistry.Register(LifestealConnection.card, CardType.Card, LichClassCard.card);
            ClassesRegistry.Register(UndeadBody.card, CardType.Card, LichClassCard.card, 1);
            ClassesRegistry.Register(EmergencyEvac.card, CardType.Card, LichClassCard.card, 1);
            ClassesRegistry.Register(EmpBlasts.card, CardType.Card, LichClassCard.card);
        }
    }
}
