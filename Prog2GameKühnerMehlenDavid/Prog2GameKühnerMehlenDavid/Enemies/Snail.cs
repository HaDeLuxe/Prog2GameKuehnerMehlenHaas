﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Reggie.Animations;

namespace Reggie.Enemies
{ 
    /// <summary>
    /// Contains moveset for Snail and its attack pattern.
    /// </summary>
    public class Snail : Enemy
    {
        private AnimationManagerEnemy animationManager;
        private List<Projectile> projectileList;
        private bool alreadyShot;
        public Vector2 project;
        Dictionary<string, Texture2D> EnemySpriteSheetsDic;
        public Snail(Texture2D enemyTexture, Vector2 enemySize, Vector2 enemyPosition, int gameObjectID, Dictionary<string, Texture2D> EnemySpriteSheetsDic) : base(enemyTexture, enemySize, enemyPosition, gameObjectID, EnemySpriteSheetsDic)
        {
            enemyHP = 3;
            movementSpeed = 3f;
            knockBackValue = 30f;
            attackDamage = 0.09f;
            attackRange = 400f;
            animationManager = new AnimationManagerEnemy(EnemySpriteSheetsDic);
            projectileList = new List<Projectile>();
            alreadyShot = false;
            this.EnemySpriteSheetsDic = EnemySpriteSheetsDic;
            //enemyAggroAreaSize = new Vector4(500, 500, 1100, 1050);
            //changeCollisionBox = new Vector2(0, 0);
            //enemyAggroArea = new Rectangle((int)(enemyPosition.X - enemyAggroAreaSize.X), (int)(enemyPosition.Y - enemyAggroAreaSize.Y), (int)(enemyAggroAreaSize.Z), (int)(enemyAggroAreaSize.W));
            //collisionBoxPosition = new Vector2(enemyPosition.X + changeCollisionBox.X, enemyPosition.Y + changeCollisionBox.Y);
            //collisionBoxSize = new Vector2(enemySize.X, enemySize.Y);
            //movementDirectionGone = 0;
        }


        public override void EnemyAnimationUpdate(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!facingDirectionRight && !attackAction)
                animationManager.nextAnimation = Enums.EnemyAnimations.SNAIL_MOVE_LEFT;
            else if (facingDirectionRight && !attackAction)
                animationManager.nextAnimation = Enums.EnemyAnimations.SNAIL_MOVE_RIGHT;
            else if (!facingDirectionRight && attackAction)
                animationManager.nextAnimation = Enums.EnemyAnimations.SNAIL_ATTACK_LEFT;
            else if (facingDirectionRight && attackAction)
                animationManager.nextAnimation = Enums.EnemyAnimations.SNAIL_ATTACK_RIGHT;
            animationManager.Animation(gameTime, this, spriteBatch);
        }

        public override void Update(GameTime gameTime, List<GameObject> gameObjectList)
        {
            //ResizeEnemyAggroArea(gameObjectList);
            if (!attackAction && attackCooldown == 0)
            {
                if (DetectPlayer() && !knockedBack)
                    attackAction = true;
                else
                    attackAction = false;
               // if (!DetectPlayer())
                    EnemyNeutralBehaviour(gameObjectList);
            }
            if (attackAction)
                EnemyAttack(gameTime, gameObjectList);
            //CalculationChargingVector();
            if(projectileList.Count() !=0)
            foreach (var projectile in projectileList.ToList())
            {
                //projectile.TracedPlayerLocation();
                projectile.Update(gameTime, gameObjectList);
                if (!projectile.ProjectileState())
                    projectileList.RemoveAt(projectileList.IndexOf(projectile));
            }
            if (attackExecuted)
                CalculationCooldown(gameTime);
            EnemyCheckCollision(gameTime, gameObjectList);
            EnemyPositionCalculation(gameTime);


            if (invincibilityFrames)
                InvincibleFrameState(gameTime);

        }

        private void CalculationCooldown(GameTime gameTime)
        {
            attackCooldown += (float)gameTime.ElapsedGameTime.TotalSeconds * 2;
            if (attackCooldown > 1f)
            {
                attackCooldown = 0;
                attackExecuted = false;
                alreadyShot = false;
            }
        }

        public override void EnemyAttack(GameTime gameTime, List<GameObject> gameObjectList)
        {
            if (!knockedBack)
            {
                attackTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                //if (!calculateCharge)
                if (attackTimer < 1f)
                    CalculationChargingVector();
                if (chargingVector.X < 0)
                    facingDirectionRight = false;
                else if (chargingVector.X > 0)
                    facingDirectionRight = true;
                if (facingDirectionRight && !alreadyShot)
                {
                    projectileList.Add(new Projectile(EnemySpriteSheetsDic["spiderWebProjectile"], new Vector2(111, 93), new Vector2(collisionBoxPosition.X + collisionBoxSize.X, collisionBoxPosition.Y-10), (int)Enums.ObjectsID.SNAIL));
                    projectileList.Last().SetPlayer(worm);
                    velocity.X = 0f;
                    alreadyShot = true;
                }
                else if (!facingDirectionRight && !alreadyShot)
                {
                    projectileList.Add(new Projectile(null, new Vector2(100, 50), new Vector2(collisionBoxPosition.X - collisionBoxSize.X/2, collisionBoxPosition.Y-10), (int)Enums.ObjectsID.SNAIL));
                    projectileList.Last().SetPlayer(worm);
                    velocity.X = 0f;
                    alreadyShot = true;
                }
                else if (attackTimer < 2f)
                {
                    //if (!calculateCharge)
                    //CalculationChargingVector();
                    //foreach (var projectile in projectileList.ToList())
                    //{
                    //    projectile.TracedPlayerLocation();
                    //    projectile.Update(gameTime, gameObjectList);
                    //    if (!projectile.ProjectileState())
                    //        projectileList.RemoveAt(projectileList.IndexOf(projectile));
                    //}
                    if (facingDirectionRight)
                        velocity.X = -1f;
                    else
                        velocity.X = 1f;
                    gravityActive = true;
                    isStanding = false;
                }
                else
                {
                    attackTimer = 0;
                    attackAction = false;
                    // calculateCharge = false;
                    velocity = Vector2.Zero;
                    attackExecuted = true;
                    gravityActive = true;
                    isStanding = false;
                    chargingVector = Vector2.Zero;
                }
            }
            else
            {
                attackTimer = 0;
                attackAction = false;
                calculateCharge = false;
                velocity = Vector2.Zero;
                attackExecuted = true;
                gravityActive = true;
                isStanding = false;
                chargingVector = Vector2.Zero;
            }
        }

        private void CalculationChargingVector()
        {
            if (chargingVector == Vector2.Zero)
            {
                if ((worm.collisionRectangle.X / 60 - collisionRectangle.X / 60) == 0)
                    chargingVector.X = 0;
                if ((worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60) == 0)
                    chargingVector.Y = 0;
            }
            if (Math.Abs(worm.collisionRectangle.X / 60 - collisionRectangle.X / 60) <= Math.Abs(worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60) && worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60 != 0)
            {
                chargingVector.X = worm.collisionRectangle.X / 60 - collisionRectangle.X / 60;
                chargingVector.Y = worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60;
                if ((worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60) != 0)
                    chargingVector.X = chargingVector.X / Math.Abs(chargingVector.Y) * 8;
                if ((worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60) > 0)
                    chargingVector.Y = 8;
                else
                    chargingVector.Y = -8;
            }
            else if (Math.Abs(worm.collisionRectangle.X / 60 - collisionRectangle.X / 60) >= Math.Abs(worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60) && worm.collisionRectangle.X / 60 - collisionRectangle.X / 60 != 0)
            {
                chargingVector.X = worm.collisionRectangle.X / 60 - collisionRectangle.X / 60;
                chargingVector.Y = worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60;
                if ((worm.collisionRectangle.X / 60 - collisionRectangle.X / 60) != 0)
                    chargingVector.Y = chargingVector.Y / Math.Abs(chargingVector.X) * 8;
                if ((worm.collisionRectangle.X / 60 - collisionRectangle.X / 60) > 0)
                    chargingVector.X = 8;
                else
                    chargingVector.X = -8;
            }
           // calculateCharge = true;
        }
        public override void DrawProjectile(SpriteBatch spriteBatch, Color color)
        {
            for (int i = 0; i < projectileList.Count(); i++)
            {
                spriteBatch.Draw(EnemySpriteSheetsDic["spiderWebProjectile"], new Vector2(projectileList[i].collisionRectangle.Left, projectileList[i].collisionRectangle.Top), color);

            }
            
        }
        public override void drawHealthBar(SpriteBatch spriteBatch, Dictionary<string, Texture2D> texturesDictionary)
        {
            if (enemyHP < 3)
            {
                spriteBatch.Draw(texturesDictionary["enemyHBBorder"], this.gameObjectPosition + new Vector2(32, -50), Color.White);
                spriteBatch.Draw(texturesDictionary["enemyHBFill"], this.gameObjectPosition + new Vector2(32, -50), null, Color.White, 0, Vector2.Zero, new Vector2(enemyHP / 3, 1), SpriteEffects.None, 0);
            }
            base.drawHealthBar(spriteBatch, texturesDictionary);
        }
    }
}
