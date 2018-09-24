﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Reggie
{
    public class Projectile : GameObject
    {
        private bool stillExist;
        private float traveltimer;
        protected Player worm;
        protected float damage;
        protected bool snailSlime;
        public Texture2D enemytexture;
        private Vector2 chargingVector;
        private bool tracedPlayerPosition;
        public Projectile(Texture2D projectileTexture, Vector2 projectileSize, Vector2 projectilePosition, int gameObjectID) : base(projectileTexture, projectileSize, projectilePosition, gameObjectID)
        {
            stillExist = true;
            facingDirectionRight = false;
            traveltimer = 0f;
            movementSpeed = 10f;
            snailSlime = false;
            tracedPlayerPosition = false;
            collisionBoxPosition = new Vector2(projectilePosition.X, projectilePosition.Y);
            collisionBoxSize = new Vector2(projectileSize.X, projectileSize.Y-40);
            if (objectID == (int)Enums.ObjectsID.SPIDER)
                damage = 0.09f;
            else if (objectID == (int)Enums.ObjectsID.SNAIL)
                damage = 0.09f;
            gravity = Vector2.Zero;
      
        }
        public void TracedPlayerLocation()
        {

            if (chargingVector == Vector2.Zero)
            {
                if ((worm.collisionRectangle.X / 60 - collisionRectangle.X / 60) == 0)
                    chargingVector.X = 0;
                if ((worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60) == 0)
                    chargingVector.Y = 0;
            }
            if (objectID == (int)Enums.ObjectsID.SNAIL)
            {
                if (Math.Abs(worm.collisionRectangle.X / 60 - collisionRectangle.X / 60) <= Math.Abs(worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60) && worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60 != 0)
                {
                    chargingVector.X = worm.collisionRectangle.X / 60 - collisionRectangle.X / 60;
                    chargingVector.Y = worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60;
                    if ((worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60) != 0)
                        chargingVector.X = chargingVector.X / Math.Abs(chargingVector.Y) * 7;
                    if ((worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60) > 0)
                        chargingVector.Y = 7;
                    else
                        chargingVector.Y = -7;
                }
                else if (Math.Abs(worm.collisionRectangle.X / 60 - collisionRectangle.X / 60) >= Math.Abs(worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60) && worm.collisionRectangle.X / 60 - collisionRectangle.X / 60 != 0)
                {
                    chargingVector.X = worm.collisionRectangle.X / 60 - collisionRectangle.X / 60;
                    chargingVector.Y = worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60;
                    if ((worm.collisionRectangle.X / 60 - collisionRectangle.X / 60) != 0)
                        chargingVector.Y = chargingVector.Y / Math.Abs(chargingVector.X) * 7;
                    if ((worm.collisionRectangle.X / 60 - collisionRectangle.X / 60) > 0)
                        chargingVector.X = 7;
                    else
                        chargingVector.X = -7;
                }
                // calculateCharge = true;
                velocity = chargingVector;
            }
            if (objectID == (int)Enums.ObjectsID.SPIDER)
            {
                if (Math.Abs(worm.collisionRectangle.X / 60 - collisionRectangle.X / 60) <= Math.Abs(worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60) && worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60 != 0)
                {
                    chargingVector.X = worm.collisionRectangle.X / 60 - collisionRectangle.X / 60;
                    chargingVector.Y = worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60;
                    if ((worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60) != 0)
                        chargingVector.X = chargingVector.X / Math.Abs(chargingVector.Y) * 6;
                    if ((worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60) > 0)
                        chargingVector.Y = 6;
                    else
                        chargingVector.Y = -6;
                }
                else if (Math.Abs(worm.collisionRectangle.X / 60 - collisionRectangle.X / 60) >= Math.Abs(worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60) && worm.collisionRectangle.X / 60 - collisionRectangle.X / 60 != 0)
                {
                    chargingVector.X = worm.collisionRectangle.X / 60 - collisionRectangle.X / 60;
                    chargingVector.Y = worm.collisionRectangle.Y / 60 - collisionRectangle.Y / 60;
                    if ((worm.collisionRectangle.X / 60 - collisionRectangle.X / 60) != 0)
                        chargingVector.Y = chargingVector.Y / Math.Abs(chargingVector.X) * 6;
                    if ((worm.collisionRectangle.X / 60 - collisionRectangle.X / 60) > 0)
                        chargingVector.X = 6;
                    else
                        chargingVector.X = -6;
                }
                // calculateCharge = true;
                velocity = chargingVector;
            }
        }

        public void SetPlayer(Player wormPlayer)
        {
            worm = wormPlayer;
        }

        #region CollisionCheck
        public void ProjectileCollisionCheck(List<GameObject> platformList)
        {
            if (HitPlayer()) 
            {
                if (!worm.invincibilityFrames)
                {
                    worm.invincibilityFrames = true;
                    worm.invincibilityFixedTimer = 3f;
                    if (objectID == (int)Enums.ObjectsID.SPIDER)
                        worm.ReducePlayerHP(damage, 6f);
                    else
                        worm.ReducePlayerHP(damage);
                }
                stillExist = false;
            }
            if(stillExist)
                if(objectID == (int)Enums.ObjectsID.SPIDER)
            foreach (var platform in platformList)
            {
                    if (velocity.X > 0 && IsTouchingLeftSide(platform))
                        stillExist = false;
                    else if (velocity.X < 0 && IsTouchingRightSide(platform))
                        stillExist = false;
                    else if (IsTouchingBottomSide(platform, gravity))
                    {
                        stillExist = false;
                        //if (objectID == (int)(Enums.ObjectsID.SNAIL))
                        //    SetSnailSlime();
                    }
                    else if (IsTouchingTopSide(platform, gravity))
                        stillExist = false;
            }
        }

        private void SetSnailSlime()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ProjectileExistance
        public bool ProjectileState()
        {
            return stillExist;
        }
        #endregion

        #region Player hit
        public bool HitPlayer()
        {
            if (collisionRectangle.Right + velocity.X > worm.collisionRectangle.Left &&
                collisionRectangle.Left < worm.collisionRectangle.Left &&
                collisionRectangle.Bottom > worm.collisionRectangle.Top &&
                collisionRectangle.Top < worm.collisionRectangle.Bottom)
                return true;
            else if (collisionRectangle.Left + velocity.X < worm.collisionRectangle.Right &&
              collisionRectangle.Right > worm.collisionRectangle.Right &&
              collisionRectangle.Bottom > worm.collisionRectangle.Top &&
              collisionRectangle.Top < worm.collisionRectangle.Bottom)
                return true;
            else if (collisionRectangle.Bottom + velocity.Y + gravity.Y > worm.collisionRectangle.Top &&
            collisionRectangle.Top < worm.collisionRectangle.Top &&
            collisionRectangle.Right > worm.collisionRectangle.Left &&
            collisionRectangle.Left < worm.collisionRectangle.Right)
                return true;
            else if (collisionRectangle.Top + velocity.Y < worm.collisionRectangle.Bottom &&
           collisionRectangle.Bottom > worm.collisionRectangle.Bottom &&
           collisionRectangle.Right > worm.collisionRectangle.Left &&
           collisionRectangle.Left < worm.collisionRectangle.Right)
                return true;
            else
                return false;
        }
        #endregion

        #region ProjectileMovement
        protected void ProjectileMovement(GameTime gameTime)
        {
            gravity.Y += (float)gameTime.ElapsedGameTime.TotalSeconds;
            collisionBoxPosition = collisionBoxPosition + velocity + gravity;
            gameObjectPosition = collisionBoxPosition;
        }
        #endregion

        #region Update
        public override void Update(GameTime gameTime, List<GameObject> gameObjectList)
        {
            if (stillExist)
            {
                if (objectID == (int)Enums.ObjectsID.SNAIL && !tracedPlayerPosition)
                {
                    TracedPlayerLocation();
                    tracedPlayerPosition = true;
                }
                ProjectileMovement(gameTime);
                ProjectileCollisionCheck(gameObjectList);
                CalculationCooldown(gameTime);
            }
        }
        #endregion

        #region Cooldown
        private void CalculationCooldown(GameTime gameTime)
        {
            traveltimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (traveltimer > 4f && objectID == (int)Enums.ObjectsID.SNAIL)
            {
                traveltimer = 0;
                stillExist = false;
            }
            if (traveltimer > 3f && objectID == (int)Enums.ObjectsID.SPIDER)
            {
                traveltimer = 0;
                stillExist = false;
            }
        }
        #endregion
    }
}
