using System;

namespace Assets.Scripts.Logic
{
    internal enum CellSpace
    {
        Empty,
        DarkBedrock,
        LightBedrock,
        DestroyableBedrock,
        DestroyedBedrock,
        Platform
    }

    internal enum Occupant
    {
        Nobody,
        Player,
        Enemy
    }

    internal class Cell
    {
        public CellSpace Space { get; private set; }
        public Occupant Occupant { get; private set; }

        public Cell(CellSpace space)
        {
            Space = space;
        }

        public void Occupy(Occupant occupant)
        {
            Occupant = occupant; 
        }
    }
}
