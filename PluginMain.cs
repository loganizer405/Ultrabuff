using System;
using System.Collections.Generic;
//using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using Terraria;
using Hooks;
using TShockAPI;

namespace Ultrabuff
{
    [APIVersion(1, 12)]
    public class Ultrabuff : TerrariaPlugin
    {
        public override string Author
        {
            get { return "DarkunderdoG & Loganizer"; }
        }
        private bool[] Bunny = new bool[256];
        private bool[] Shine = new bool[256];
        private bool[] Grav = new bool[256];
        private bool[] Thorns = new bool[256];
        private bool[] Archery = new bool[256];
        private bool[] Spelunker = new bool[256];
        private bool[] Ironskin = new bool[256];
        private bool[] Magic = new bool[256];
        private bool[] Regeneration = new bool[256];
        private bool[] Obsidian = new bool[256];
        private bool[] Swiftness = new bool[256];
        private bool[] Featherfall = new bool[256];
        private bool[] Invisibility = new bool[256];
        private bool[] Night = new bool[256];
        private bool[] WaterWalking = new bool[256];
        private bool[] Orb = new bool[256];
        private bool[] Fairy = new bool[256];
        private bool[] WellFed = new bool[256];
        private bool[] Gills = new bool[256];
        private bool[] Battle = new bool[256];
        public override string Description
        {
            get { return "Adds 20 buffs"; }
        }
        private DateTime LastCheck = DateTime.UtcNow;
        public override string Name
        {
            get { return "Ultrabuff"; }
        }
        public override Version Version
        {
            get { return new Version("1.1"); }
        }

        public Ultrabuff(Main game)
            : base(game)
        {
            Order = 1;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                GameHooks.Update -= OnUpdate;
                ServerHooks.Leave -= OnLeave;
            }
        }
        public override void Initialize()
        {
            Commands.ChatCommands.Add(new Command(new List<string>() { "bunny", "buffall" }, BunnyModeCmd, "bunny"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "grav", "buffall" }, GravModeCmd, "grav"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "grav", "buffall" }, ShineModeCmd, "shine"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "thorns", "buffall" }, ThornsModeCmd, "thorns"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "archery", "buffall" }, ArcheryModeCmd, "archery"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "spelunker", "buffall" }, SpelunkerModeCmd, "spelunker"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "ironskin", "buffall" }, IronskinModeCmd, "ironskin"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "magic", "buffall" }, ManaModeCmd, "magic"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "regen", "buffall" }, RegenModeCmd, "regen"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "obsidian", "buffall" }, ObsidianModeCmd, "obsidian"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "swiftness", "buffall" }, SwiftModeCmd, "swiftness"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "featherfall", "buffall" }, FeatherModeCmd, "feather"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "invisibility", "buffall" }, InvisModeCmd, "invis"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "nightowl", "buffall" }, NightModeCmd, "nightowl"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "waterwalk", "buffall" }, WaterWalkModeCmd, "waterwalk"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "orb", "buffall" }, OrbModeCmd, "orb"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "fairy", "buffall" }, FairyModeCmd, "fairy"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "soup", "buffall" }, SoupModeCmd, "wellfed"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "gills", "buffall" }, GillsModeCmd, "gills"));
            Commands.ChatCommands.Add(new Command(new List<string>() { "battle", "buffall" }, BattleModeCmd, "battle"));
            Commands.ChatCommands.Add(new Command("ultrabuff", UltrabuffModeCmd, "ultrabuff"));
            GameHooks.Update += OnUpdate;
            ServerHooks.Leave += OnLeave;
        }


        void OnUpdate()
        {
            if ((DateTime.UtcNow - LastCheck).TotalSeconds > 1)
            {
                LastCheck = DateTime.UtcNow;
                for (int i = 0; i < 256; i++)
                {
                    if (Bunny[i])
                        TShock.Players[i].SetBuff(40, Int16.MaxValue);
                    if (Grav[i])
                        TShock.Players[i].SetBuff(18, Int16.MaxValue);
                    if (Shine[i])
                        TShock.Players[i].SetBuff(11, Int16.MaxValue);
                    if (Thorns[i])
                        TShock.Players[i].SetBuff(14, Int16.MaxValue);
                    if (Archery[i])
                        TShock.Players[i].SetBuff(16, Int16.MaxValue);
                    if (Spelunker[i])
                        TShock.Players[i].SetBuff(9, Int16.MaxValue);
                    if (Ironskin[i])
                        TShock.Players[i].SetBuff(5, Int16.MaxValue);
                    if (Magic[i])
                        TShock.Players[i].SetBuff(6, Int16.MaxValue);
                    if (Magic[i])
                        TShock.Players[i].SetBuff(7, Int16.MaxValue);
                    if (Magic[i])
                        TShock.Players[i].SetBuff(29, Int16.MaxValue);
                    if (Regeneration[i])
                        TShock.Players[i].SetBuff(2, Int16.MaxValue);
                    if (Obsidian[i])
                        TShock.Players[i].SetBuff(1, Int16.MaxValue);
                    if (Swiftness[i])
                        TShock.Players[i].SetBuff(3, Int16.MaxValue);
                    if (Featherfall[i])
                        TShock.Players[i].SetBuff(8, Int16.MaxValue);
                    if (Invisibility[i])
                        TShock.Players[i].SetBuff(10, Int16.MaxValue);
                    if (Night[i])
                        TShock.Players[i].SetBuff(12, Int16.MaxValue);
                    if (WaterWalking[i])
                        TShock.Players[i].SetBuff(15, Int16.MaxValue);
                    if (Orb[i])
                        TShock.Players[i].SetBuff(19, Int16.MaxValue);
                    if (Fairy[i])
                        TShock.Players[i].SetBuff(27, Int16.MaxValue);
                    if (WellFed[i])
                        TShock.Players[i].SetBuff(26, Int16.MaxValue);
                    if (Gills[i])
                        TShock.Players[i].SetBuff(4, Int16.MaxValue);
                    if (Battle[i])
                        TShock.Players[i].SetBuff(13, Int16.MaxValue);
                }
            }
        }

        void OnLeave(int plr)
        {
            Bunny[plr] = false;
            Grav[plr] = false;
            Shine[plr] = false;
            Thorns[plr] = false;
            Archery[plr] = false;
            Spelunker[plr] = false;
            Ironskin[plr] = false;
            Magic[plr] = false;
            Regeneration[plr] = false;
            Obsidian[plr] = false;
            Swiftness[plr] = false;
            Featherfall[plr] = false;
            Invisibility[plr] = false;
            Night[plr] = false;
            WaterWalking[plr] = false;
            Orb[plr] = false;
            Fairy[plr] = false;
            WellFed[plr] = false;
            Gills[plr] = false;
            Battle[plr] = false;
        }

        void BunnyModeCmd(CommandArgs e)
        {
            Bunny[e.Player.Index] = !Bunny[e.Player.Index];
            if (Bunny[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Bunny mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Bunny mode.", Color.Green);
            }
        }

        void GravModeCmd(CommandArgs e)
        {
            Grav[e.Player.Index] = !Grav[e.Player.Index];
            if (Grav[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Gravity mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Gravity mode.", Color.Green);
            }
        }
        void ShineModeCmd(CommandArgs e)
        {
            Shine[e.Player.Index] = !Shine[e.Player.Index];
            if (Shine[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Shine mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Shine mode.", Color.Green);
            }
        }
        void ThornsModeCmd(CommandArgs e)
        {
            Thorns[e.Player.Index] = !Thorns[e.Player.Index];
            if (Thorns[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Thorns mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Thorns mode.", Color.Green);

            }

        }
        void ArcheryModeCmd(CommandArgs e)
        {
            Archery[e.Player.Index] = !Archery[e.Player.Index];
            if (Archery[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Archery mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Archery mode.", Color.Green);
            }
        }
        void SpelunkerModeCmd(CommandArgs e)
        {
            Spelunker[e.Player.Index] = !Spelunker[e.Player.Index];
            if (Spelunker[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Spelunker mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Spelunker mode.", Color.Green);

            }

        }
        void IronskinModeCmd(CommandArgs e)
        {
            Ironskin[e.Player.Index] = !Ironskin[e.Player.Index];
            if (Ironskin[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Ironskin mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Ironskin mode.", Color.Green);
            }
        }
        void ManaModeCmd(CommandArgs e)
        {
            Magic[e.Player.Index] = !Magic[e.Player.Index];
            if (Magic[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Magic mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Magic mode.", Color.Green);

            }

        }
        void RegenModeCmd(CommandArgs e)
        {
            Regeneration[e.Player.Index] = !Regeneration[e.Player.Index];
            if (Regeneration[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Regen mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Regen mode.", Color.Green);
            }
        }
        void ObsidianModeCmd(CommandArgs e)
        {
            Obsidian[e.Player.Index] = !Obsidian[e.Player.Index];
            if (Obsidian[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Obsidian mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Obsidian mode.", Color.Green);
            }
        }
        void SwiftModeCmd(CommandArgs e)
        {
            Swiftness[e.Player.Index] = !Swiftness[e.Player.Index];
            if (Swiftness[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Swiftness mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Swiftness mode.", Color.Green);
            }
        }
        void FeatherModeCmd(CommandArgs e)
        {
            Featherfall[e.Player.Index] = !Featherfall[e.Player.Index];
            if (Featherfall[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Featherfall mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Featherfall mode.", Color.Green);
            }
        }
        void InvisModeCmd(CommandArgs e)
        {
            Invisibility[e.Player.Index] = !Invisibility[e.Player.Index];
            if (Invisibility[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Invisibility mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Invisibility mode.", Color.Green);
            }
        }
        void NightModeCmd(CommandArgs e)
        {
            Night[e.Player.Index] = !Night[e.Player.Index];
            if (Night[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Night Owl mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Night Owl mode.", Color.Green);
            }
        }

        void WaterWalkModeCmd(CommandArgs e)
        {
            WaterWalking[e.Player.Index] = !WaterWalking[e.Player.Index];
            if (WaterWalking[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Water Walking mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Water Walking mode.", Color.Green);
            }
        }
        void OrbModeCmd(CommandArgs e)
        {
            Orb[e.Player.Index] = !Orb[e.Player.Index];
            if (Orb[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Orb of Light mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Orb of Light mode.", Color.Green);
            }
        }
        void FairyModeCmd(CommandArgs e)
        {
            Fairy[e.Player.Index] = !Fairy[e.Player.Index];
            if (Fairy[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Fairy mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Fairy mode.", Color.Green);
            }
        }
        void SoupModeCmd(CommandArgs e)
        {
            WellFed[e.Player.Index] = !WellFed[e.Player.Index];
            if (WellFed[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Well Fed mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Well Fed mode.", Color.Green);
            }
        }
        void GillsModeCmd(CommandArgs e)
        {
            Gills[e.Player.Index] = !Gills[e.Player.Index];
            if (Gills[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Gills mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Gills mode.", Color.Green);
            }
        }
        void BattleModeCmd(CommandArgs e)
        {
            Battle[e.Player.Index] = !Battle[e.Player.Index];
            if (Battle[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Battle mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Battle mode.", Color.Green);
            }
        }
        void UltrabuffModeCmd(CommandArgs e)
        {
           
            Bunny[e.Player.Index] = !Bunny[e.Player.Index];
            Grav[e.Player.Index] = !Grav[e.Player.Index];
            Shine[e.Player.Index] = !Shine[e.Player.Index];
            Thorns[e.Player.Index] = !Thorns[e.Player.Index];
            Archery[e.Player.Index] = !Archery[e.Player.Index];
            Spelunker[e.Player.Index] = !Spelunker[e.Player.Index];
            Ironskin[e.Player.Index] = !Ironskin[e.Player.Index];
            Magic[e.Player.Index] = !Magic[e.Player.Index];
            Regeneration[e.Player.Index] = !Regeneration[e.Player.Index];
            Obsidian[e.Player.Index] = !Obsidian[e.Player.Index];
            Swiftness[e.Player.Index] = !Swiftness[e.Player.Index];
            Night[e.Player.Index] = !Night[e.Player.Index];
            WaterWalking[e.Player.Index] = !WaterWalking[e.Player.Index];
            Fairy[e.Player.Index] = !Fairy[e.Player.Index];
            WellFed[e.Player.Index] = !WellFed[e.Player.Index];


            if (Bunny[e.Player.Index] && Grav[e.Player.Index] && Shine[e.Player.Index] && Thorns[e.Player.Index] && Archery[e.Player.Index] && Spelunker[e.Player.Index] && Ironskin[e.Player.Index] && Magic[e.Player.Index] && Regeneration[e.Player.Index] && Obsidian[e.Player.Index] && Swiftness[e.Player.Index] && Night[e.Player.Index] && WaterWalking[e.Player.Index] && Fairy[e.Player.Index] && WellFed[e.Player.Index])
            {
                e.Player.SendMessage("Enabled Ultrabuff mode.", Color.Green);
            }
            else
            {
                e.Player.SendMessage("Disabled Ultrabuff mode.", Color.Green);
            }
        }
    }
   
}

