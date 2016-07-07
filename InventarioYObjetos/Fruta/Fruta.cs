﻿using Microsoft.DirectX;
using TgcViewer.Utils.TgcGeometry;
using TgcViewer.Utils.TgcSceneLoader;

namespace AlumnoEjemplos.NatusVincere
{
    public class Fruta : Crafteable
    {
        public new int uses = 3;
        public new int type = 14;
        private TgcBoundingBox piedraBB;

        public Fruta(TgcMesh mesh, Vector3 position, Vector3 scale) : base(mesh, position, scale)
        {
            this.type = 14;
            this.description = "Fruta";
            this.minimumDistance = 200;
            storable = true;
            consumible = true;
            setBB(position);
        }

        public override void doAction(Human user)
        {
            Vector3 direction = this.getPosition() - user.getPosition();
            direction.Normalize();
            this.move(direction);
        }

        public override float getMinimumDistance()
        {
            return this.minimumDistance;
        }
        public override int getType()
        {
            return this.type;
        }
        
        public override bool getConsumible()
        {
            return this.consumible;
        }
        
        public override void consumir(Human dueño)
        {
            dueño.recuperarVida(20);
        }

        public override TgcBoundingBox getBB()
        {
            return this.piedraBB;
        }

        public override void Render()
        {
            piedraBB.render();
        }

        public override void borrarBB()
        {
            this.piedraBB.dispose();
            this.piedraBB = new TgcBoundingBox(new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f));
        }

        public override void setBB(Vector3 position)
        {
            this.piedraBB = new TgcBoundingBox(new Vector3(position.X - 5, position.Y + 8, position.Z + 10), new Vector3(position.X + 22, position.Y + 28, position.Z));
        }
    }
}
