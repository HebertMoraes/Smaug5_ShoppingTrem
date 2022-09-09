using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TouchScreenController : MonoBehaviour
{
    public int valueToSlideTouchScreen;
    public bool CheckSwipTouchToLeft() {
        
        if (Input.touchCount > 0) {
            
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved) {
                if (touch.deltaPosition.x <= -valueToSlideTouchScreen) {
                    return true;
                } else { 
                    return false; 
                }
            } else { 
                return false; 
            }
        } else {
            return false;
        }
    }
    public bool CheckSwipTouchToRight() {
        
        if (Input.touchCount > 0) {
            
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved) {
                if (touch.deltaPosition.x >= valueToSlideTouchScreen) {
                    return true;
                } else { 
                    return false; 
                }
            } else { 
                return false; 
            }
        } else {
            return false;
        }
    }
}
