using UnityEngine;
using System.Collections;

public class HoverButtonScript : MonoBehaviour

{

    static int HoverButtonHash = "HoverButton".GetHashCode();

    private Rect HoverButtonRect = new Rect(100, 100, 100, 100);

    void OnGUI()

    {

        switch (HoverButton(HoverButtonRect, new GUIContent("HoverButton"), "button"))

        {

            case EventType.mouseDown:

                Debug.Log("MouseDown");

                break;

            case EventType.mouseUp:

                Debug.Log("MouseUp");

                break;

            case EventType.mouseDrag:

                HoverButtonRect.x = Input.mousePosition.x - (HoverButtonRect.width / 2);

                HoverButtonRect.y = (Screen.height - Input.mousePosition.y) - (HoverButtonRect.height / 2);

                break;

            case EventType.mouseMove:

                GUI.Button(new Rect(HoverButtonRect.x + 100, HoverButtonRect.y, 50, 50), "Mouse\nis Over");

                break;

        }

    }

    public static EventType HoverButton(Rect position, GUIContent content, GUIStyle style)

    {

        int controlID = GUIUtility.GetControlID(HoverButtonHash, FocusType.Native);

        switch (Event.current.GetTypeForControl(controlID))

        {

            case EventType.mouseDown:

                if (position.Contains(Event.current.mousePosition))

                {

                    GUIUtility.hotControl = controlID;

                    Event.current.Use();

                    return EventType.mouseDown;

                }

                break;

            case EventType.mouseUp:

                if (GUIUtility.hotControl != controlID)

                    return EventType.ignore;

                GUIUtility.hotControl = 0;

                Event.current.Use();

                if (position.Contains(Event.current.mousePosition))

                    return EventType.mouseUp;

                else

                    return EventType.ignore;

            case EventType.mouseDrag:

                if (GUIUtility.hotControl == controlID)

                {

                    Event.current.Use();

                    return EventType.mouseDrag;

                }

                else

                    return EventType.ignore;

            case EventType.repaint:

                style.Draw(position, content, controlID);

                if (position.Contains(Event.current.mousePosition))

                    return EventType.mouseMove;

                else

                    return EventType.repaint;

        }

        if (position.Contains(Event.current.mousePosition))

            return EventType.mouseMove;

        else

            return EventType.ignore;

    }

}