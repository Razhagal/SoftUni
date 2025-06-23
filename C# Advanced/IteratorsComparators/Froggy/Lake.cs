using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Froggy
{
    public class Lake : IEnumerable<int>
    {
        private List<int> stones;

        public Lake(params int[] stones)
        {
            this.stones = new List<int>(stones);
            SortStones();
        }

        private void SortStones()
        {
            List<int> evenStones = new List<int>();
            List<int> oddStones = new List<int>();
            for (int i = 0; i < this.stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    evenStones.Add(this.stones[i]);
                }
                else
                {
                    oddStones.Add(this.stones[i]);
                }
            }

            oddStones.Reverse();
            this.stones = evenStones.Concat(oddStones).ToList();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Count; i++)
            {
                yield return this.stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
