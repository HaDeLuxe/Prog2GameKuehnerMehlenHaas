﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Media; 
using Microsoft.Xna.Framework.Audio; 

namespace Reggie
{
    class Loading {


        public void loadEverything(ContentManager Content, ref Dictionary<string, Texture2D> PlayerSpriteSheets, ref Dictionary<string, Texture2D> texturesDictionary, ref Dictionary<string, Texture2D> EnemySpriteSheets, ref Dictionary<string, Song> songDictionary, ref Dictionary<string, SoundEffect> soundEffectDictionnary) {
            loadPlayerSprites(Content, ref PlayerSpriteSheets);
            loadWorldSprites(Content, ref texturesDictionary);
            loadEnemySprites(Content, ref EnemySpriteSheets);
            loadItemSprites(Content, ref texturesDictionary);
            loadWorldObjects(Content, ref texturesDictionary);
            loadUIElements(Content, ref texturesDictionary);
            loadInteractivePlatforms(Content, ref texturesDictionary);

            //Markus
            loadSongs(Content, ref songDictionary);
        }

        /// <summary>
        /// This method loads all world background images and adds them to the texturesDictionnary
        /// </summary>
        /// <param name="Content"></param>
        private void loadWorldSprites(ContentManager Content, ref Dictionary<string, Texture2D> texturesDictionnary) {
            //Load Tutorial Tiles
            Texture2D Tut_Tile_1 = Content.Load<Texture2D>("Images\\World\\Tut\\Tut_Tile_1");
            texturesDictionnary.Add("Tut_Tile_1", Tut_Tile_1);
            Texture2D Tut_Tile_2 = Content.Load<Texture2D>("Images\\World\\Tut\\Tut_Tile_2");
            texturesDictionnary.Add("Tut_Tile_2", Tut_Tile_2);
            Texture2D Tut_Tile_3 = Content.Load<Texture2D>("Images\\World\\Tut\\Tut_Tile_3");
            texturesDictionnary.Add("Tut_Tile_3", Tut_Tile_3);
            Texture2D Tut_Tile_4 = Content.Load<Texture2D>("Images\\World\\Tut\\Tut_Tile_4");
            texturesDictionnary.Add("Tut_Tile_4", Tut_Tile_4);
            Texture2D Tut_Tile_5 = Content.Load<Texture2D>("Images\\World\\Tut\\Tut_Tile_5");
            texturesDictionnary.Add("Tut_Tile_5", Tut_Tile_5);


            Texture2D Ant_Cave_Background = Content.Load<Texture2D>("Images\\World\\Ameisenhöhle");
            texturesDictionnary.Add("Ant_Cave_Background", Ant_Cave_Background);
            Texture2D Tree_Background = Content.Load<Texture2D>("Images\\World\\Baum");
            texturesDictionnary.Add("Tree_Background", Tree_Background);
            Texture2D Roof_Background = Content.Load<Texture2D>("Images\\World\\Dach");
            texturesDictionnary.Add("Roof_Background", Roof_Background);
            Texture2D Greenhouse_Background = Content.Load<Texture2D>("Images\\World\\Gewächshaus");
            texturesDictionnary.Add("Greenhouse_Background", Greenhouse_Background);
            Texture2D Hub_Background = Content.Load<Texture2D>("Images\\World\\Hub");
            texturesDictionnary.Add("Hub_Background", Hub_Background);
            Texture2D Crown_Background = Content.Load<Texture2D>("Images\\World\\krone");
            texturesDictionnary.Add("Crown_Background", Crown_Background);
            Texture2D Dunghill_Background = Content.Load<Texture2D>("Images\\World\\Misthaufen");
            texturesDictionnary.Add("Dunghill_Background", Dunghill_Background);

            Texture2D InterLevel_1 = Content.Load<Texture2D>("Images\\World\\Inter\\Interlevel_1");
            texturesDictionnary.Add("Interlevel_1", InterLevel_1);
        }


        /// <summary>
        /// This method loads all Player Sprites and adds them to the PlayerSpriteSheets Dictionnary
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="PlayerSpriteSheets"></param>
        private void loadPlayerSprites(ContentManager Content, ref Dictionary<string, Texture2D> PlayerSpriteSheets) {
            Texture2D playerJumpSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Jump_Small");
            PlayerSpriteSheets.Add("playerJumpSpriteSheet", playerJumpSpriteSheet);
            Texture2D playerJumpHatSpritesSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Jump_Hat");
            PlayerSpriteSheets.Add("playerJumpHatSpriteSheet", playerJumpHatSpritesSheet);
            Texture2D playerJumpArmorSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Jump_Armor");
            PlayerSpriteSheets.Add("playerJumpArmorSpriteSheet", playerJumpArmorSpriteSheet);
            Texture2D playerJumpArmorHatSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Jump_Armor_Hat");
            PlayerSpriteSheets.Add("playerJumpArmorHatSpriteSheet", playerJumpArmorHatSpriteSheet);
            Texture2D playerJumpUmbrellaEmptySpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Jump_Umbrella_Empty");
            PlayerSpriteSheets.Add("playerJumpUmbrellaEmptySpriteSheet", playerJumpUmbrellaEmptySpriteSheet);

            Texture2D playerMoveSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Move_Even_Smaller");
            PlayerSpriteSheets.Add("playerMoveSpriteSheet", playerMoveSpriteSheet);
            Texture2D playerMoveHatSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Move_Hat");
            PlayerSpriteSheets.Add("playerMoveHatSpriteSheet", playerMoveHatSpriteSheet);
            Texture2D playerMoveArmorSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Move_Armor");
            PlayerSpriteSheets.Add("playerMoveArmorSpriteSheet", playerMoveArmorSpriteSheet);
            Texture2D playerMoveArmorHatSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Move_Armor_Hat");
            PlayerSpriteSheets.Add("playerMoveArmorHatSpriteSheet", playerMoveArmorHatSpriteSheet);
            Texture2D playerMoveUmbrellaEmptySpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Move_Umbrella_Empty");
            PlayerSpriteSheets.Add("playerMoveUmbrellaEmptySpriteSheet", playerMoveUmbrellaEmptySpriteSheet);

            Texture2D playerAttackSpritesheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Attack");
            PlayerSpriteSheets.Add("playerAttackSpriteSheet", playerAttackSpritesheet);
            Texture2D playerAttackHatSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Attack_Hat");
            PlayerSpriteSheets.Add("playerAttackHatSpriteSheet", playerAttackHatSpriteSheet);
            Texture2D playerAttackArmorSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Attack_Armor");
            PlayerSpriteSheets.Add("playerAttackArmorSpriteSheet", playerAttackArmorSpriteSheet);
            Texture2D playerAttackArmorHatSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Attack_Armor_Hat");
            PlayerSpriteSheets.Add("playerAttackArmorHatSpritesheet", playerAttackArmorHatSpriteSheet);
            Texture2D playerAttackUmbrellaEmptySpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Attack_Umbrella");
            PlayerSpriteSheets.Add("playerAttackUmbrellaEmptySpriteSheet", playerAttackUmbrellaEmptySpriteSheet);

            Texture2D playerJumpShovelSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Jump_Shovel");
            PlayerSpriteSheets.Add("playerJumpShovelSpriteSheet", playerJumpShovelSpriteSheet);
            Texture2D playerWalkShovelSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Move_Shovel");
            PlayerSpriteSheets.Add("playerWalkShovelSpriteSheet", playerWalkShovelSpriteSheet);
            Texture2D playerAttackShovelSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Attack_Shovel");
            PlayerSpriteSheets.Add("playerAttackShovelSpriteSheet", playerAttackShovelSpriteSheet);
            Texture2D playerFloatShovelSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Float_Shovel");
            PlayerSpriteSheets.Add("playerFloatShovelSpriteSheet", playerFloatShovelSpriteSheet);

            Texture2D playerJumpScissorsSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Jump_Scirssors");
            PlayerSpriteSheets.Add("playerJumpScissorsSpriteSheet", playerJumpScissorsSpriteSheet);
            Texture2D playerWalkScissorsSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Move_Scissors");
            PlayerSpriteSheets.Add("playerWalkScissorsSpriteSheet", playerWalkScissorsSpriteSheet);
            Texture2D playerAttackScissorsSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Attack_Scissors");
            PlayerSpriteSheets.Add("playerAttackScissorsSpriteSheet", playerAttackScissorsSpriteSheet);
            Texture2D playerFloatScissorsSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Float_Scissors");
            PlayerSpriteSheets.Add("playerFloatScissorsSpriteSheet", playerFloatScissorsSpriteSheet);

            Texture2D playerJumpGoldenSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Jump_Umbrella_Golden");
            PlayerSpriteSheets.Add("playerJumpGoldenSpriteSheet", playerJumpGoldenSpriteSheet);
            Texture2D playerWalkGoldenSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Move_Umbrella_Golden");
            PlayerSpriteSheets.Add("playerWalkGoldenSpriteSheet", playerWalkGoldenSpriteSheet);
            Texture2D playerAttackGoldenSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Attack_Umbrella_Golden");
            PlayerSpriteSheets.Add("playerAttackGoldenSpriteSheet", playerAttackGoldenSpriteSheet);
            Texture2D playerFloatGoldenSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Float_Golden");
            PlayerSpriteSheets.Add("playerFloatGoldenSpriteSheet", playerFloatGoldenSpriteSheet);

            Texture2D playerFloatingSpriteSheet = Content.Load<Texture2D>("Images\\PlayerSpriteSheets\\Reggie_Float_Umbrella");
            PlayerSpriteSheets.Add("playerFloatSpriteSheet", playerFloatingSpriteSheet);

            
        }

        /// <summary>
        /// This method loads all enemy sprite sheets and adds them to the EnemySpriteSheetsDictionnary
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="EnemySpriteSheets"></param>
        private void loadEnemySprites(ContentManager Content, ref Dictionary<string, Texture2D> EnemySpriteSheets) {
            Texture2D Ladybug_Fly = Content.Load<Texture2D>("Images\\Enemies Sprite Sheets\\ladybug_floating_Left_Small");
            EnemySpriteSheets.Add("Ladybug_Fly_Spritesheet", Ladybug_Fly);
            Texture2D Ladybug_Attack = Content.Load<Texture2D>("Images\\Enemies Sprite Sheets\\Ladybug_Attack_Small");
            EnemySpriteSheets.Add("Ladybug_Attack_Spritesheet", Ladybug_Attack);
        }


        /// <summary>
        /// This method laods all item sprite sheets and adds them to the texturesDictionnary
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="texturesDictionary"></param>
        private void loadItemSprites(ContentManager Content, ref Dictionary<string, Texture2D> texturesDictionary)
        {
            Texture2D snailShell = Content.Load<Texture2D>("Images\\Schneckenhaus");
            texturesDictionary.Add("SnailShell", snailShell);
            Texture2D scissors = Content.Load<Texture2D>("Images\\Schere");
            texturesDictionary.Add("Scissors_64x64", scissors);
            Texture2D armor = Content.Load<Texture2D>("Images\\Rüstung");
            texturesDictionary.Add("Armor_64x64", armor);
            Texture2D shovel = Content.Load<Texture2D>("Images\\Schaufel");
            texturesDictionary.Add("Shovel_64x64", shovel);
            Texture2D healthItem = Content.Load<Texture2D>("Images\\healthPotion");
            texturesDictionary.Add("HealthItem", healthItem);
            Texture2D jumpPotion = Content.Load<Texture2D>("Images\\jumpPotion");
            texturesDictionary.Add("JumpPotion", jumpPotion);
            Texture2D strengthPotion = Content.Load<Texture2D>("Images\\StrengthPotion");
            texturesDictionary.Add("PowerPotion", strengthPotion);
            Texture2D goldenUmbrella = Content.Load<Texture2D>("Images\\GoldenUmbrella");
            texturesDictionary.Add("GoldenUmbrella", goldenUmbrella);
        }

        /// <summary>
        /// This method loads all interactive game objects sprites and adds them to the texturesDictionnary
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="texturesDictionary"></param>
        private void loadInteractivePlatforms(ContentManager Content, ref Dictionary<string, Texture2D> texturesDictionary)
        {
            Texture2D vineDoor = Content.Load<Texture2D>("Images\\WorldObjects\\VineDOORBLOCK_Reggie");
            texturesDictionary.Add("VineDoor", vineDoor);
            Texture2D spiderWeb = Content.Load<Texture2D>("Images\\WorldObjects\\SpiderWeb");
            texturesDictionary.Add("Spiderweb_64x64", spiderWeb);
        }

        /// <summary>
        /// This method loads all World Objects sprites and adds them to the texturesDictionnary
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="texturesDictionnary"></param>
        private void loadWorldObjects(ContentManager Content, ref Dictionary<string, Texture2D> texturesDictionnary) {
            Texture2D Transparent_Wall_512x64 = Content.Load<Texture2D>("Images\\Transparent_Wall_512x64");
            texturesDictionnary.Add("Transparent_500x50", Transparent_Wall_512x64);
            Texture2D Transparent_Wall_64x64 = Content.Load<Texture2D>("Images\\WorldObjects\\Transparent - 64x64");
            texturesDictionnary.Add("Transparent_64x64", Transparent_Wall_64x64);
            Texture2D Transparent_Wall_1024x64 = Content.Load<Texture2D>("Images\\Transparent_Wall_1024x64");
            texturesDictionnary.Add("Transparent_1000x50", Transparent_Wall_1024x64);
            Texture2D ClimbinPlant_38_64 = Content.Load<Texture2D>("Images\\WorldObjects\\plantLeaves_1");
            texturesDictionnary.Add("Climbingplant_38x64", ClimbinPlant_38_64);
        }


        /// <summary>
        /// This method loads all UI Elements ands adds them to the texturesDictionnary
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="texturesDictionnary"></param>
        private void loadUIElements(ContentManager Content, ref Dictionary<string, Texture2D> texturesDictionnary) {
            Texture2D levelEditorUIBackButton = Content.Load<Texture2D>("Images\\UI\\LvlEdtorSaveButton");
            texturesDictionnary.Add("LevelEditorUIBackButton", levelEditorUIBackButton);
            Texture2D UserInterface = Content.Load<Texture2D>("Images\\UI\\UI");
            texturesDictionnary.Add("UI", UserInterface);
            Texture2D playerHealthbar = Content.Load<Texture2D>("Images\\UI\\Healthbar");
            texturesDictionnary.Add("Healthbar", playerHealthbar);
            Texture2D L1ButtonIcon = Content.Load<Texture2D>("Images\\UI\\buttonL1");
            texturesDictionnary.Add("buttonL1", L1ButtonIcon);
            Texture2D L2ButtonIcon = Content.Load<Texture2D>("Images\\UI\\buttonL2");
            texturesDictionnary.Add("buttonL2", L2ButtonIcon);
            Texture2D R1ButtonIcon = Content.Load<Texture2D>("Images\\UI\\buttonR1");
            texturesDictionnary.Add("buttonR1", R1ButtonIcon);
            Texture2D R2ButtonIcon = Content.Load<Texture2D>("Images\\UI\\buttonR2");
            texturesDictionnary.Add("buttonR2", R2ButtonIcon);

            //Minimap loading thingis
            Texture2D Minimap = Content.Load<Texture2D>("Images\\Minimap\\MiniMap");
            texturesDictionnary.Add("Minimap", Minimap);
            Texture2D Point = Content.Load<Texture2D>("Images\\Minimap\\Point");
            texturesDictionnary.Add("Point", Point);

            //LoadMenuPic
            Texture2D MainMenu1 = Content.Load<Texture2D>("Images\\MainMenu\\HauptMenu-1");
            texturesDictionnary.Add("MainMenu1", MainMenu1);
            Texture2D MainMenu2 = Content.Load<Texture2D>("Images\\MainMenu\\HauptMenu-2");
            texturesDictionnary.Add("MainMenu2", MainMenu2);
            Texture2D MainMenu3 = Content.Load<Texture2D>("Images\\MainMenu\\HauptMenu-3");
            texturesDictionnary.Add("MainMenu3", MainMenu3);
            Texture2D MainMenu4 = Content.Load<Texture2D>("Images\\MainMenu\\HauptMenu-4");
            texturesDictionnary.Add("MainMenu4", MainMenu4);
            Texture2D MainMenu5 = Content.Load<Texture2D>("Images\\MainMenu\\HauptMenu-5");
            texturesDictionnary.Add("MainMenu5", MainMenu5);
        }


        private void loadSongs(ContentManager Content, ref Dictionary<string, Song> songDictionnary)
        {
            Song temp = Content.Load<Song>("Audio\\houseChord");
            songDictionnary.Add("houseChord", temp);

            //MediaPlayer.Play(testSong);
            //MediaPlayer.IsRepeating = true;
        }

        private void loadSoundEffects(ContentManager Content, ref Dictionary<string, SoundEffect> soundEffectDictionnary)
        {
            SoundEffect temp = Content.Load<SoundEffect>("Audio\\houseChord");
            soundEffectDictionnary.Add("houseChord", temp);
        }
    }
}
