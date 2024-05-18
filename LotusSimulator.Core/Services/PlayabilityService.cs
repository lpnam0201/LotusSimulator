using LotusSimulator.Core.Entities.Card;
using LotusSimulator.Core.Entities.Playability;
using LotusSimulator.Core.Entities.Players;
using LotusSimulator.Core.MessageOut;
using LotusSimulator.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LotusSimulator.Core.Services
{
    public class PlayabilityService
    {

        public async Task SetPlayabilityAllPlayers(Game game)
        {
            foreach (var player in game.Players)
            {
                var cards = player.Library.Cards
                    .Concat(player.Hand.Cards)
                    .Concat(player.Exile.Cards)
                    .Concat(player.Graveyard.Cards);
                foreach (var card in cards)
                {
                    SetPlayabilityInternal(card, player);
                }

                var permanents = player.Battlefield.Permanents;
                foreach (var permanent in permanents)
                {
                    SetPlayabilityInternal(permanent, player);
                }
            }
        }

        private void SetPlayabilityInternal(Card card, Player player)
        {
            var game = player.Game;
            SetDefaultPlayability(card, player);

            // Granted playability
            foreach (var ability in card.Abilities)
            {
                // Mana ability doesn't require priority but can only be activated when game require mana payment
                if (ability.IsManaAbility && game.IsManaPaymentRequested(player))
                {
                    card.GrantedPlayabilities.AddIfNotSame(ability.GetPlayability(player));
                }
                else
                {
                    if (player.HasPriority())
                    {
                        card.GrantedPlayabilities.AddIfNotSame(ability.GetPlayability(player));
                    }
                }
            }
        }

        private void SetDefaultPlayability(Card card, Player player)
        {
            var game = player.Game;
            if (player != card.Controller)
            {
                return;
            }

            if (player.Library.HasCard(card))
            {
                return;
            }

            if (card.IsLand())
            {
                if (game.Stack.IsEmpty()
                && player.HasPriority()
                    && game.CurrentTurn.IsMainPhase()
                    && game.CurrentTurn.Player == player)
                {
                    card.Playabilities.AddIfNotSame(Playability.PlayAsLand(player));
                }
            }
            else if (card.IsInstant())
            {
                if (player.HasPriority())
                {
                    card.Playabilities.AddIfNotSame(Playability.Cast(card.ManaCost, player));
                }
            }
            else
            {
                if (game.Stack.IsEmpty()
                && player.HasPriority()
                    && game.CurrentTurn.IsMainPhase()
                    && game.CurrentTurn.Player == player)
                {
                    card.Playabilities.AddIfNotSame(Playability.Cast(card.ManaCost, player));
                }
            }
        }

        private void SetPlayabilityInternal(Permanent permanent, Player player)
        {
            foreach (var ability in permanent.Abilities)
            {
                permanent.GrantedPlayabilities.AddIfNotSame(ability.GetPlayability(player));
            }
        }

        public void SetPlayableBy(List<Playability> playabilities, Player player)
        {
            foreach (var playability in playabilities)
            {
                playability.PlayableBy = player;

            }
        }
    }
}
