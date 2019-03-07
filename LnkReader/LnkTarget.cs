using System;
using System.Linq;

namespace LnkReader
{
    class LnkTarget
    {
        public readonly int Size;

        public LnkTarget(byte[] tb)
        {
            Size = BitConverter.ToInt16(tb.Take(2).ToArray(), 0) + 2;

            byte[] iidb = tb.Skip(2).Take(Size - 2).ToArray();
            int itemIdSize = BitConverter.ToUInt16(iidb.Take(2).ToArray(), 0);
            while (itemIdSize > 0)
            {
                byte[] itemId = iidb.Skip(2).Take(itemIdSize - 2).ToArray();
                //TODO: do something with this itemId
                iidb = iidb.Skip(itemIdSize).ToArray();
                itemIdSize = BitConverter.ToUInt16(iidb.Take(2).ToArray(), 0);
            }
        }
    }
}
