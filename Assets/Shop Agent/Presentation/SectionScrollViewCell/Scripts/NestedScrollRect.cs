using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
 
public class NestedScrollRect : ScrollRect {
    private bool shouldDragParents = false;


    public override void OnInitializePotentialDrag (PointerEventData eventData) {
        ForEachParent<IInitializePotentialDragHandler>(
            (parent) => { 
                parent.OnInitializePotentialDrag(eventData); 
            }
        );
        base.OnInitializePotentialDrag (eventData);
    }

    public override void OnBeginDrag (PointerEventData eventData) {
        var wasDxMoreThanDy = Math.Abs(eventData.delta.y) < Math.Abs(eventData.delta.x);
        var wasDyMoreThanDx = Math.Abs(eventData.delta.x) < Math.Abs(eventData.delta.y);

        if (!horizontal && wasDxMoreThanDy || (!vertical && wasDyMoreThanDx)) {
            shouldDragParents = true;
            ForEachParent<IBeginDragHandler>(
                (parent) => { 
                    parent.OnBeginDrag(eventData);
                }
            );
         } else {
             shouldDragParents = false;
             base.OnBeginDrag(eventData);
         }
    }

        public override void OnDrag (PointerEventData eventData) {
        if (shouldDragParents) {
            ForEachParent<IDragHandler>(
                (parent) => { 
                    parent.OnDrag(eventData); 
                }
            );
        } else {
            base.OnDrag(eventData);
        }
    }
 
    public override void OnEndDrag (PointerEventData eventData) {
        if (shouldDragParents) {
            ForEachParent<IEndDragHandler>(
                (parent) => { 
                    parent.OnEndDrag(eventData); 
                }
             );
        } else {
            base.OnEndDrag (eventData);
        }
        shouldDragParents = false;
    }


    private void ForEachParent<T>(Action<T> action) where T: IEventSystemHandler {
        Transform parent = transform.parent;
        while(parent) {
            foreach(var component in parent.GetComponents<Component>()) {
                if(component is T) {
                    action((T) (IEventSystemHandler) component);
                }
            }
            parent = parent.parent;
        }
    }
}