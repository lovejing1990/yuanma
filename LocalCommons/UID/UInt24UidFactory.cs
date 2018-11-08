/*
  That file part of Code Monsters framework.
  Cerium Unity 2015 © 
*/

using System.Collections.Concurrent;
using LocalCommons.Utilities;

namespace LocalCommons.UID
{
    public class UInt24UidFactory
    {
        private volatile uint _nextUid = 1;
        private readonly ConcurrentQueue<Uint24> _freeUidList = new ConcurrentQueue<Uint24>();

        public UInt24UidFactory(Uint24 val = default(Uint24))
        {
            if(val != 1) this._nextUid = val + 1;
        }

        public Uint24 Next()
        {
            Uint24 result;
            if (this._freeUidList.TryDequeue(out result))
                return result;

            return ++this._nextUid;
        }

        public void ReleaseUniqueInt(Uint24 uid24)
        {
            if ((Uint24)uid24 == 0)
                return;

	        this._freeUidList.Enqueue(uid24);
        }
    }
}
