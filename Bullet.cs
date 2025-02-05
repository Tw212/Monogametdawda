using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace Monogametdawda
{
    public class Bullet
    {
         private Texture2D texture;
        private Vector2 position;
        private Rectangle hitbox;

        public Rectangle Hitbox{
            get{return hitbox;}
        }

        public Bullet(Texture2D texture, Vector2 spawnPosition){
            this.texture = texture;
            position = spawnPosition;
            hitbox = new Rectangle((int) position.X, (int) position.Y, 10, 10);
        }

        public void Update(){
            position.Y -= 50*1f/60f;

            hitbox.Location = position.ToPoint();
        }

        public void Draw(SpriteBatch spriteBatch){
            spriteBatch.Draw(texture, hitbox, Color.LimeGreen);
        }
    }
}