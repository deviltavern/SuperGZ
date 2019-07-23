﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StrategyMaster {

    void endStrategy();
    void endStrategy(Strategy strategy);

    void changeStrategy(Strategy strategy);

    void getStretegyRevalue(ViewInfo info);
}
