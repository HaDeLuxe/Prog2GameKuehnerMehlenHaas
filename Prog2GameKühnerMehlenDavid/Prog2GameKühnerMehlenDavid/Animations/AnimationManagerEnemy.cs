﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reggie.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reggie.Animations {
    class AnimationManagerEnemy {

        protected Color color = Color.White;
        public Enums.EnemyAnimations currentAnimation = Enums.EnemyAnimations.LADYBUG_FLY_LEFT;
        public Enums.EnemyAnimations nextAnimation = Enums.EnemyAnimations.LADYBUG_FLY_LEFT;
        public Enums.EnemyAnimations previousAnimation = Enums.EnemyAnimations.LADYBUG_FLY_LEFT;

        Dictionary<string, Animation> divAnimationDestRectanglesDic;

        Animation ladybug_Fly_Left = null;
        Animation ladybug_Fly_Right = null;
        Animation ladybug_Attack_Left = null;
        Animation ladybug_Attack_Right = null;


        public AnimationManagerEnemy(Dictionary<string, Texture2D> EnemySpriteSheetsDic) 
        {
            divAnimationDestRectanglesDic = new Dictionary<string, Animation>();
            //Ladybug
            ladybug_Fly_Left = new Animation(true, SpriteEffects.None, 99,65,EnemySpriteSheetsDic["Ladybug_Fly_Spritesheet"],25);
            divAnimationDestRectanglesDic.Add("Ladybug_Fly_Left", ladybug_Fly_Left);
            ladybug_Fly_Right = new Animation(true, SpriteEffects.FlipHorizontally, 99, 65, EnemySpriteSheetsDic["Ladybug_Fly_Spritesheet"], 25);
            divAnimationDestRectanglesDic.Add("Ladybug_Fly_Right", ladybug_Fly_Right);
            ladybug_Attack_Left = new Animation(false, SpriteEffects.None, 99, 65, EnemySpriteSheetsDic["Ladybug_Attack_Spritesheet"], 50);
            ladybug_Attack_Right = new Animation(false, SpriteEffects.FlipHorizontally, 99, 65, EnemySpriteSheetsDic["Ladybug_Attack_Spritesheet"], 50);
        }

        

        public void Animation(GameTime gameTime, Enemy enemy, SpriteBatch spriteBatch) 
        {
            if(currentAnimation == Enums.EnemyAnimations.LADYBUG_FLY_LEFT
                || currentAnimation == Enums.EnemyAnimations.LADYBUG_FLY_RIGHT)
            {
                currentAnimation = nextAnimation;
            }

            if(currentAnimation == Enums.EnemyAnimations.LADYBUG_ATTACK_LEFT
                || currentAnimation == Enums.EnemyAnimations.LADYBUG_ATTACK_RIGHT)
            {
                if(ladybug_Attack_Left.getPlayedOnce()
                    || ladybug_Attack_Right.getPlayedOnce())
                {
                    if(nextAnimation == Enums.EnemyAnimations.LADYBUG_ATTACK_LEFT
                        || nextAnimation == Enums.EnemyAnimations.LADYBUG_ATTACK_RIGHT)
                    {
                        nextAnimation = previousAnimation;
                        currentAnimation = nextAnimation;

                        ladybug_Attack_Left.resetPlayedOnce();
                        ladybug_Attack_Right.resetPlayedOnce();
                    }
                }
            }

            Rectangle tempRec;
            switch (currentAnimation)
            {
                case Enums.EnemyAnimations.LADYBUG_FLY_LEFT:
                    enemy.changeTexture(ladybug_Fly_Left.texture);
                    tempRec = divAnimationDestRectanglesDic["Ladybug_Fly_Left"].Update(gameTime);
                    enemy.DrawSpriteBatch(spriteBatch, tempRec, ladybug_Fly_Left.getSpriteEffects(), new Vector2(0, -30),color);
                    previousAnimation = Enums.EnemyAnimations.LADYBUG_FLY_LEFT;
                    break;
                case Enums.EnemyAnimations.LADYBUG_FLY_RIGHT:
                    enemy.changeTexture(ladybug_Fly_Right.texture);
                    tempRec = divAnimationDestRectanglesDic["Ladybug_Fly_Right"].Update(gameTime);
                    enemy.DrawSpriteBatch(spriteBatch, tempRec, ladybug_Fly_Right.getSpriteEffects(), new Vector2(0, -30), color);
                    previousAnimation = Enums.EnemyAnimations.LADYBUG_FLY_RIGHT;
                    break;
                case Enums.EnemyAnimations.LADYBUG_ATTACK_LEFT:
                    enemy.changeTexture(ladybug_Attack_Left.texture);
                    tempRec = ladybug_Attack_Left.Update(gameTime);
                    enemy.DrawSpriteBatch(spriteBatch, tempRec, ladybug_Attack_Left.getSpriteEffects(), new Vector2(0, -30), color);
                    break;
                case Enums.EnemyAnimations.LADYBUG_ATTACK_RIGHT:
                    enemy.changeTexture(ladybug_Attack_Right.texture);
                    tempRec = ladybug_Attack_Right.Update(gameTime);
                    enemy.DrawSpriteBatch(spriteBatch, tempRec, ladybug_Attack_Right.getSpriteEffects(), new Vector2(0, -30), color);
                    break;

            }
        }


        public void NextAnimation(Enums.EnemyAnimations nextAnimation)
        {
            this.nextAnimation = nextAnimation;
        }
    }


}
