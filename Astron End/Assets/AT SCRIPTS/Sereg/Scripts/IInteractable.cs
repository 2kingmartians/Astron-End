﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable  {
    string getObjectName();
    void interact(GameObject interactor);

}
