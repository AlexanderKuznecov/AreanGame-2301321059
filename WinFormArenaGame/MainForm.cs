using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using ArenaGame.Heroes;
using ArenaGame.Weapons;
using ArenaGame;

namespace WinFormArenaGame
{
    public partial class MainForm : Form
    {
        private Hero heroA;
        private Hero heroB;

        public MainForm()
        {
            InitializeComponent();
            LoadHeroOptions();
        }

        private void LoadHeroOptions()
        {
            var heroOptions = new List<string> { "Knight", "Assassin", "Vampire", "Hunter", "Tank", "Magician" };
            comboBox1.Items.AddRange(heroOptions.ToArray());
            comboBox2.Items.AddRange(heroOptions.ToArray());
        }

        private Hero CreateHero(string heroName)
        {
            switch (heroName)
            {
                case "Knight":
                    return new Knight("Knight", 15, 10, new Sword("Sword"));
                case "Assassin":
                    return new Assassin("Assassin", 10, 10, new Dagger("Dagger"));
                case "Vampire":
                    return new Vampire("Vampire", 10, 10, new Blood("Blood"));
                case "Hunter":
                    return new Hunter("Hunter", 5, 10, new Bow("Bow"));
                case "Tank":
                    return new Tank("Tank", 10, 10, new SpikedShield("SpikedShield"));
                case "Magician":
                    return new Magician("Magician", 7, 10, new Spell("Spells"));
                default:
                    Console.WriteLine("Invalid choice, defaulting to Knight.");
                    return new Knight("Knight", 15, 10, new Sword("Sword"));
            }
        }

        private void gameNotification(GameEngine.NotificationArgs args)
        {
            TextBox tbAttacker;
            if (args.Attacker == heroA)
                tbAttacker = tbAssassin;
            else
                tbAttacker = tbKnight;

            tbAttacker.AppendText(
                $"{args.Attacker.Name} attacked {args.Defender.Name} with {Math.Round(args.Attack, 2)} and caused {Math.Round(args.Damage, 2)} damage.\r\n");

            DateTime dt = DateTime.Now;

            while (DateTime.Now - dt < TimeSpan.FromMilliseconds(300))
            {
                Application.DoEvents();
            }
        }

        private void btnNewGame_Click(object sender, EventArgs e)
        {
            lbWinner.Text = "";
            tbAssassin.Text = "";
            tbKnight.Text = "";
            lbWinner.Visible = false;

            string heroAName = comboBox1.SelectedItem?.ToString();
            string heroBName = comboBox2.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(heroAName) || string.IsNullOrEmpty(heroBName))
            {
                MessageBox.Show("Please select both heroes.");
                return;
            }

            heroA = CreateHero(heroAName);
            heroB = CreateHero(heroBName);

            GameEngine gameEngine = new GameEngine()
            {
                HeroA = heroA,
                HeroB = heroB,
                NotificationsCallBack = gameNotification
            };

            imgFight.Enabled = true;
            gameEngine.Fight();
            imgFight.Enabled = false;

            lbWinner.Text = $"The winner is:\n{gameEngine.Winner}";
            lbWinner.Visible = true;
        }

        private void lbWinner_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void tbKnight_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}