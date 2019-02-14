using System.Collections.Generic;
using UnityEngine;

#if false
namespace Ruyi.Unity
{
    /// <summary>
    /// Drop-in replacement for Unity's static input class
    /// </summary>
    /// <remarks>
    /// <code>
    /// using UnityEngine;
    /// #if SUBOR
    /// using Input = Ruyi.Unity.Input;
    /// #endif
    /// </code>
    /// <seealso cref="https://docs.unity3d.com/ScriptReference/Input.html"/>
    /// </remarks>
    public sealed class Input
    {
#region Properties
        public static Vector3 acceleration
        {
            get { return UnityEngine.Input.acceleration; }
        }

        public static int accelerationEventCount
        {
            get { return 0; }
        }

        public static AccelerationEvent[] accelerationEvents
        {
            get { return noAccelerationEvents; }
        }
        static readonly AccelerationEvent[] noAccelerationEvents = new AccelerationEvent[0];

        public static bool anyKey
        {
            get { throw null; }
        }

        public static bool anyKeyDown
        {
            get { throw null; }
        }

        public static bool backButtonLeavesApp
        {
            get { return UnityEngine.Input.backButtonLeavesApp; }
            set { UnityEngine.Input.backButtonLeavesApp = value; }
        }

        public static Compass compass
        {
            get { return noCompass; }
        }
        static readonly Compass noCompass = new Compass();

        public static bool compensateSensors
        {
            get { return UnityEngine.Input.compensateSensors; }
            set { UnityEngine.Input.compensateSensors = value; }
        }

        public static Vector2 compositionCursorPos
        {
            get { return UnityEngine.Input.compositionCursorPos; }
            set { UnityEngine.Input.compositionCursorPos = value; }
        }

        public static string compositionString
        {
            get { return UnityEngine.Input.compositionString; }
        }

        public static DeviceOrientation deviceOrientation
        {
            get { return UnityEngine.Input.deviceOrientation; }
        }

        public static Gyroscope gyro
        {
            get { return UnityEngine.Input.gyro; }
        }

        public static IMECompositionMode imeCompositionMode
        {
            get { return UnityEngine.Input.imeCompositionMode; }
            set { UnityEngine.Input.imeCompositionMode = value; }
        }

        public static bool imeIsSelected
        {
            get { return UnityEngine.Input.imeIsSelected; }
        }

        public static string inputString
        {
            get { throw null; }
        }

        public static LocationService location
        {
            get { return UnityEngine.Input.location; }
        }

        public static Vector3 mousePosition
        {
            get { return UnityEngine.Input.mousePosition; }
        }

        public static bool mousePresent
        {
            get { return UnityEngine.Input.mousePresent; }
        }

        public static Vector2 mouseScrollDelta
        {
            get { return UnityEngine.Input.mouseScrollDelta; }
        }

        public static bool multiTouchEnabled
        {
            get { return UnityEngine.Input.multiTouchEnabled; }
            set { UnityEngine.Input.multiTouchEnabled = value; }
        }

        public static bool simulateMouseWithTouches
        {
            get { return UnityEngine.Input.simulateMouseWithTouches; }
            set { UnityEngine.Input.simulateMouseWithTouches = value; }
        }

        public static bool stylusTouchSupported
        {
            get { return UnityEngine.Input.stylusTouchSupported; }
        }

        public static int touchCount
        {
            get { return UnityEngine.Input.touchCount; }
        }

        public static Touch[] touches
        {
            get { return UnityEngine.Input.touches; }
        }

        public static bool touchPressureSupported
        {
            get { return UnityEngine.Input.touchPressureSupported; }
        }

        public static bool touchSupported
        {
            get { return UnityEngine.Input.touchSupported; }
        }

#endregion

#region Methods

        public static AccelerationEvent GetAccelerationEvent(int index)
        {
            return noAcceleration;
        }
        static readonly AccelerationEvent noAcceleration = new AccelerationEvent();

        public static float GetAxis(string axisName)
        {
            throw null;
        }

        public static float GetAxisRaw(string axisName)
        {
            throw null;
        }

        public static bool GetButton(string buttonName)
        {

        }

        public static bool GetButtonDown(string buttonName)
        {

        }

        public static bool GetButtonUp(string buttonName)
        {

        }

        public static string[] GetJoystickNames()
        {

        }

        public static bool GetKey(string name)
        {

        }
        public static bool GetKey(KeyCode key)
        {

        }

        public static bool GetKeyDown(string name)
        {

        }

        public static bool GetKeyDown(KeyCode key)
        {

        }

        public static bool GetKeyUp(string name)
        {

        }

        public static bool GetKeyUp(KeyCode key)
        {

        }

        public static bool GetMouseButton(int button)
        {
            return UnityEngine.Input.GetMouseButton(button);
        }

        public static bool GetMouseButtonDown(int button)
        {
            return UnityEngine.Input.GetMouseButtonDown(button);
        }

        public static bool GetMouseButtonUp(int button)
        {
            return UnityEngine.Input.GetMouseButtonUp(button);
        }

        public static Touch GetTouch(int index)
        {
            return UnityEngine.Input.GetTouch(index);
        }

        public static bool IsJoystickPreconfigured(string joystickName)
        {
            return UnityEngine.Input.IsJoystickPreconfigured(joystickName);
        }

        public static void ResetInputAxes()
        {

        }
#endregion
    }

    class InputHelper
    {
        public void AddHandler(Ruyi.Layer0.SubscribeClient subscribeClient)
        {
            subscribeClient.AddMessageHandler<Ruyi.SDK.InputManager.RuyiGamePadInput>((_, msg) =>
            {
                lock (sync)
                {
                    inputMessages.Add(msg);
                }
            });
        }

        object sync = new object();
        List<Ruyi.SDK.InputManager.RuyiGamePadInput> inputMessages = new List<SDK.InputManager.RuyiGamePadInput>();
    }

    public class InputBehaviour : MonoBehaviour
    {

    }
}
#endif