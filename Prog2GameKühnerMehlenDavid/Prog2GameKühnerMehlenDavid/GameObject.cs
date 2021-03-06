﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reggie {
    /// <summary>
    /// abstract class that is base class for most objects in our game.
    /// </summary>
    public abstract class GameObject {

        protected Texture2D gameObjectTexture;
        protected bool pressedLeftKey;
        protected bool pressedRightKey;
        protected bool gravityActive;
        protected bool isStanding;
        protected bool facingDirectionRight;
        public float movementSpeed;
        public Vector2 gravity;
        public Vector2 gameObjectPosition;
        public Vector2 collisionBoxSize;
        public Vector2 collisionBoxPosition;
        public Vector2 changeCollisionBox;
        public Vector2 gameObjectSize;
        public Vector2 velocity;
        public Color color = Color.White;
        public bool isDragged = false;
        public bool getsDrawn = true;
        public int objectID;


        //returns a rectangle that represents the gameobject collisionbox
        public Rectangle collisionRectangle
        {
        get { return new Rectangle((int)collisionBoxPosition.X, (int)collisionBoxPosition.Y, (int)collisionBoxSize.X, (int)collisionBoxSize.Y); }
        }


        //returns a rectangle that contains the location the gameobjects sprite/texture etc
        public Rectangle gameObjectRectangle {
            get { return new Rectangle((int)gameObjectPosition.X, (int)gameObjectPosition.Y, (int)gameObjectSize.X, (int)gameObjectSize.Y); } set{; }
        }

        public GameObject(Texture2D gameObjectTexture, Vector2 gameObejctSize, Vector2 position, int gameObjectID ) {
            this.gameObjectTexture = gameObjectTexture;
            this.gameObjectSize = gameObejctSize;
            this.gameObjectPosition = position;
            this.objectID = gameObjectID;
            
        }

        public Texture2D getTexture() {
            return gameObjectTexture;
        }

        public virtual void Update(GameTime gameTime, List<GameObject> spriteList) { }

        public void DontDrawThisObject() {
            getsDrawn = false;
        }

        public void DrawThisObject() {
            getsDrawn = true;
        }

        public bool IsThisAVisibleObject() {
            return getsDrawn;
        }


        //some draw fucntions for the gameobjects
        public virtual void DrawSpriteBatch(SpriteBatch spriteBatch) {
            spriteBatch.Draw(gameObjectTexture, gameObjectPosition, color);
        }

        public virtual void DrawSpriteBatch(SpriteBatch spriteBatch, Rectangle sourceRectangle, SpriteEffects spriteEffects,Vector2 offset, Color color, Vector2 scale) {
            spriteBatch.Draw(gameObjectTexture, gameObjectPosition + offset, sourceRectangle, color, 0, Vector2.Zero, scale, spriteEffects, 0);
        }

        public virtual void DrawSpriteBatch(SpriteBatch spriteBatch, Rectangle sourceRectangle)
        {
            if (!facingDirectionRight)
            {
                spriteBatch.Draw(gameObjectTexture, gameObjectPosition, sourceRectangle, Color.White, 0, Vector2.Zero, Vector2.One, SpriteEffects.FlipHorizontally, 0);
            }
            else
                spriteBatch.Draw(gameObjectTexture, gameObjectPosition, sourceRectangle, Color.White);
        }

        public virtual void DrawAnimation(SpriteBatch spriteBatch, Texture2D texture, Vector2 position, Rectangle sourceRectangle, Color color) {
            spriteBatch.Draw(texture, position, sourceRectangle, color);
        }

        // GameobjectCollision --> important part to check if 2 intended gameobjects collides with each other
        protected bool IsTouchingLeftSide(GameObject sprite) {
            return collisionRectangle.Right + velocity.X > sprite.gameObjectRectangle.Left
                && collisionRectangle.Left < sprite.gameObjectRectangle.Left
                && collisionRectangle.Bottom > sprite.gameObjectRectangle.Top
                && collisionRectangle.Top < sprite.gameObjectRectangle.Bottom;
        }

        protected bool IsTouchingRightSide(GameObject sprite) {
            return collisionRectangle.Left + velocity.X < sprite.gameObjectRectangle.Right
                && collisionRectangle.Right > sprite.gameObjectRectangle.Right
                && collisionRectangle.Bottom > sprite.gameObjectRectangle.Top
                && collisionRectangle.Top < sprite.gameObjectRectangle.Bottom;
        }

        protected bool IsTouchingTopSide(GameObject sprite, Vector2 Gravity) {
            return collisionRectangle.Bottom + velocity.Y + Gravity.Y >= sprite.gameObjectRectangle.Top
                && collisionRectangle.Top < sprite.gameObjectRectangle.Top
                && collisionRectangle.Right > sprite.gameObjectRectangle.Left
                && collisionRectangle.Left < sprite.gameObjectRectangle.Right;
        }

        protected bool IsTouchingBottomSide(GameObject sprite, Vector2 Gravity) {
            return collisionRectangle.Top + velocity.Y + Gravity.Y <= sprite.gameObjectRectangle.Bottom
                && collisionRectangle.Bottom > sprite.gameObjectRectangle.Bottom
                && collisionRectangle.Right > sprite.gameObjectRectangle.Left
                && collisionRectangle.Left < sprite.gameObjectRectangle.Right;
        }
        
    }
}
