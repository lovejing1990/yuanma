using System.Collections.Concurrent;

namespace LocalCommons.UID
{
    public class Int32UidFactory
    {
        private volatile int _nextUid = 1;
        private readonly ConcurrentQueue<int> _freeUidList = new ConcurrentQueue<int>();

        public Int32UidFactory(int val = 1)
        {
	        this._nextUid = val + 1;
        }

        public int Next()
        {
            int result;
            if (this._freeUidList.TryDequeue(out result))
                return result;

            return ++this._nextUid;
        }

        public void ReleaseUniqueInt(int uid)
        {
            if ((int)uid == 0)
                return;

	        this._freeUidList.Enqueue(uid);
        }
    }
}
