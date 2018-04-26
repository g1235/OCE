using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeCoreExer
{
    public interface ISongsFetchingService
    {
        itunesSong[] Fetch10RndSongs(string artist);
    }
}


