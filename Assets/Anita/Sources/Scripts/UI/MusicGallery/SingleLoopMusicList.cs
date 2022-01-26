using System.Collections.Generic;

namespace Anita
{
    public class SingleLoopMusicList : SequentialMusicList
    {
        public SingleLoopMusicList(List<MusicListEntry> entries, int currentIndex) : base(entries, currentIndex) { }

        public override MusicListEntry Step()
        {
            return Current();
        }
    }
}