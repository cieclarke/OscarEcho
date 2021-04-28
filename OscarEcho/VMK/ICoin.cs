using System;
using System.Collections;
using System.Collections.Generic;

namespace OscarEcho.VMK
{
    public interface ICoin
    {
        string Name { get; }
        double Worth { get; }
    }
}
