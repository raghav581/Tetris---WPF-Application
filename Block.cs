using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffSet { get; }
        public abstract int Id { get; }
        private int rotationState;
        private Position offset;
        public Block()
        {
            offset = new Position(StartOffSet.Row, StartOffSet.Column);
        }
        public IEnumerable<Position> TilePositions()
        {
            foreach(var p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }
        public void RotateCW()
        {
            rotationState = (rotationState +1)%Tiles.Length;
        }
        public void RotateCCW()
        {
            if(rotationState == 0)
                rotationState =  Tiles.Length-1;
            else rotationState--;
        }
        public void Move(int row, int column)
        {
            offset.Row += row;
            offset.Column += column;
        }
        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffSet.Row;
            offset.Column = StartOffSet.Column;
        }
    }
}
