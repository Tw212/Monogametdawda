using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Monogametdawda
{
    public class Player
    {
        private Texture2D texture;
        private Vector2 position;
        private Rectangle hitbox;
        public Rectangle Hitbox{
            get{return hitbox;}
        }
        private KeyboardState newKState;
        private KeyboardState oldKState;
        private List<Bullet> bullets = new List<Bullet>();

        public List<Bullet> Bullets{
            get{return bullets;}
        }
        public Player(Texture2D texture, Vector2 position, int pixelSize){
            this.texture = texture;
            this.position = position;
            hitbox = new Rectangle((int)position.X,(int)position.Y,pixelSize,pixelSize);
        }

        public void Update(){
            newKState = Keyboard.GetState();
            Move();
            Shoot();
            oldKState = newKState; 

            foreach (Bullet b in bullets)
            {
                b.Update();
            }
        }

        private void Shoot(){
            
            if(newKState.IsKeyDown(Keys.Space)&& oldKState.IsKeyUp(Keys.Space)){
                Bullet bullet = new Bullet(texture,position);
                bullets.Add(bullet); 
            }
        }
        private void Move(){
            

            if(newKState.IsKeyDown(Keys.A)&& position.X > 0){
                position.X -= 10;
            }
            if(newKState.IsKeyDown(Keys.D)&& position.X< 750){
                position.X += 10;
            }
            if(newKState.IsKeyDown(Keys.W)&& position.Y > 0){
                position.Y -= 10;
            }
            if(newKState.IsKeyDown(Keys.S)&& position.Y < 430){
                position.Y += 10;
            }
            hitbox.Location = position.ToPoint();
        }

        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture,hitbox,Color.White);
            foreach(Bullet b in bullets){
                b.Draw(spriteBatch);
            }
        }
    }
}